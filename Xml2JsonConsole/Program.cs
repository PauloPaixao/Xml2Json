using CommandLine;
using Newtonsoft.Json;
using Serilog;
using System.IO;
using System.Text;
using System.Xml;

namespace Xml2JsonConsole
{
   internal static class Program
   {
      private static ILogger Logger { get; set; }

      static void Main(string[] args)
      {
         Logger = new LoggerConfiguration()
           .WriteTo.ColoredConsole()
           .CreateLogger();

         Parser.Default.ParseArguments<Options>(args)
                  .WithParsed<Options>(o =>
                  {
                     if (!string.IsNullOrEmpty(o.Filename))
                     {
                        if (File.Exists(o.Filename))
                        {
                           CreateJson(o.Filename);
                        }
                        else
                        {
                           Logger.Warning("Inexisting file: {Filename}.", o.Filename);
                        }
                     }

                     if (!string.IsNullOrEmpty(o.Directory))
                     {
                        CreateJsonDirectory(o.Directory);
                     }
                  });
      }


      private static void CreateJsonDirectory(string directory)
      {
         if (Directory.Exists(directory))
         {
            var files = Directory.GetFiles(directory, "*.xml");
            foreach(var file in files)
            {
               CreateJson(file);
            }
         }
         else
         {
            Logger.Warning("Inexisting directory: {Directory}", directory);
         }
      }
      private static void CreateJson(string filename)
      {
         var xml = File.ReadAllText(filename);
         XmlDocument doc = new XmlDocument();
         doc.LoadXml(xml);

         var builder = new StringBuilder();
         JsonSerializer.Create().Serialize(new CustomJsonWriter(new StringWriter(builder)), doc);
         var serialized = builder.ToString();
         var outputFile = filename + ".json";
         Logger.Information("{InputFile} -> {OutputFile}", filename, outputFile);

         File.WriteAllText(outputFile, serialized, Encoding.UTF8);
      }
   }
}
