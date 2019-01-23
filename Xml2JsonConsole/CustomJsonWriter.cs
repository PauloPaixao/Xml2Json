using Newtonsoft.Json;
using System.IO;

namespace Xml2JsonConsole
{
   public class CustomJsonWriter : JsonTextWriter
   {
      public CustomJsonWriter(TextWriter writer) : base(writer) { }

      public override void WritePropertyName(string name)
      {
         if (!string.IsNullOrEmpty(name))
         {
            name = name.Replace('-', '_');
         }
         
         if (name.StartsWith("@")
            || name.StartsWith("#")
            || name.StartsWith("?"))
         {
            base.WritePropertyName(name.Substring(1));
         }
         else
         {
            base.WritePropertyName(name);
         }
      }
   }
}
