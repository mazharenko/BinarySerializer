using System;
using BinarySerializer.Serialization.Entries;

namespace BinarySerializer.Serialization.Stream
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
             context.GetConverter(entry.Id.GetType()).Write(entry.Id, context.Stream);
         }

         private static void WriteActual(ConvertationEntry entry, SerializationContext context)
         {
             context.GetConverter(entry.Type).Write(entry.Value, context.Stream);
         }

         private static void WriteActual(MemberEndingEntry entry, SerializationContext context)
         {
             context.GetConverter(Constants.MemberEndMark.GetType()).Write(Constants.MemberEndMark, context.Stream);
         }
     }
 }