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
             throw new System.NotImplementedException();
         }

         private static void WriteActual(MemberHeaderEntry entry, SerializationContext context)
         {
             context.FindConverter(entry.Id.GetType()).Convert(entry.Id, context.DestinationStream);
         }

         private static void WriteActual(ConvertationEntry entry, SerializationContext context)
         {
             context.FindConverter(entry.Type).Convert(entry.Value, context.DestinationStream);
         }

         private static void WriteActual(MemberEndingEntry entry, SerializationContext context)
         {
             context.DestinationStream.WriteByte(0x00);
         }
     }
 }