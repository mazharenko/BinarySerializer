using System;
using System.Collections.Generic;
using System.Linq;
using BinarySerializer.Exceptions;
using BinarySerializer.Stream.Entries;

 namespace BinarySerializer.Stream
 {
     // ReSharper disable UnusedParameter.Local
     public class SerializationStreamWriter : ISerializationStreamWriter
     {
         public void Write(ISerializationStreamEntry entry, SerializationContext context)
         {
             WriteActual((dynamic)entry, context);
         }
         private static void WriteActual(object entry, SerializationContext context)
         {
             throw new NotImplementedException();
         }

         private static void WriteActual(MemberHeaderEntry entry, SerializationContext context)
         {
             context.FindConverter(entry.Id.GetType()).Write(entry.Id, context.Stream);
         }

         private static void WriteActual(ConvertationEntry entry, SerializationContext context)
         {
             context.FindConverter(entry.Type).Write(entry.Value, context.Stream);
         }

         private static void WriteActual(MemberEndingEntry entry, SerializationContext context)
         {
             context.FindConverter(Constants.MemberEndMark.GetType()).Write(Constants.MemberEndMark, context.Stream);
         }
     }

     public static class Constants
     {
         public const int MemberEndMark = 0;
     }

     public interface IDeserializationStreamReader
     {
         void Read(ObjectAdapter objectAdapter, ICollection<ContractMemberAdapter> members, DeserializationContext context);
     }

     public class DeserializationStreamReader : IDeserializationStreamReader
     {
         public void Read(ObjectAdapter objectAdapter, ICollection<ContractMemberAdapter> members, DeserializationContext context)
         {
             var singleAdapter = members.OfType<ContractSingleObjectAdapter>().SingleOrDefault();
             if (singleAdapter != null)
             {
                 ReadSingle(singleAdapter, context);
             }
             else
             {
                 ReadRoot(objectAdapter, members, context);
             }
         }

         private void ReadSingle(ContractSingleObjectAdapter singleObject, DeserializationContext context)
         {
             var converter = context.FindConverter(singleObject.Type);
             if (converter == null)
                 throw new UnknownTypeException(singleObject.Type);
             singleObject.SetValue(converter.Read(context.Stream));
         }

         private void ReadRoot(ObjectAdapter objectAdapter, ICollection<ContractMemberAdapter> members, DeserializationContext context)
         {
             objectAdapter.SetValue(CreateContract(objectAdapter.Type));
             while (context.Stream.Position < context.Stream.Length)
             {
                 var id = (int)context.FindConverter(typeof(int)).Read(context.Stream);
                 var member = members.FirstOrDefault(m => m.Id == id);
                 if (member == null)
                     throw new StreamReaderException("An unexpected member id appeared in the input stream");

                 var converter = context.FindConverter(member.Type);
                 if (converter == null)
                 {
                     member.SetValue(CreateContract(member.Type));
                     ReadSubObject(member.Children, context);
                 }
                 else
                 {
                     member.SetValue(converter.Read(context.Stream));
                 }
             }
         }

         private void ReadSubObject(ICollection<ContractMemberAdapter> members, DeserializationContext context)
         {
             while (true)
             {
                 var id = (int)context.FindConverter(typeof(int)).Read(context.Stream);
                 if (id == Constants.MemberEndMark)
                     break;

                 var member = members.FirstOrDefault(m => m.Id == id);
                 if (member == null)
                     throw new StreamReaderException("An unexpected member id appeared in the input stream");

                 var converter = context.FindConverter(member.Type);
                 if (converter == null)
                 {
                     member.SetValue(CreateContract(member.Type));
                     ReadSubObject(member.Children, context);
                 }
                 else
                 {
                     member.SetValue(converter.Read(context.Stream));
                 }
             }
         }

         private object CreateContract(Type type)
         {
             if (type.GetConstructor(new Type[0]) == null)
                 throw new InvalidConfigurationException($"The specified type can't be either instantiated or converted - {type}");

             return Activator.CreateInstance(type);
         }
     }
 }