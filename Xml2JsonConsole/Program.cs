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
                           CreateJson(o.Filename, o.Verbose, o.JsonSuffix);
                        }
                        else
                        {
                           Logger.Warning("Inexisting file: {Filename}.", o.Filename);
                        }
                     }

                     if (!string.IsNullOrEmpty(o.Directory))
                     {
                        CreateJsonDirectory(o.Directory, o.Verbose, o.JsonSuffix);
                     }
                  });
      }

      private static void CreateJsonDirectory(string directory, bool verbose, string jsonSuffix)
      {
         if (Directory.Exists(directory))
         {
            foreach(var file in Directory.GetFiles(directory, "*.xml"))
            {
               CreateJson(file, verbose, jsonSuffix);
            }
         }
         else
         {
            Logger.Warning("Inexisting directory: {Directory}", directory);
         }
      }
      private static void CreateJson(string filename, bool verbose = true, string jsonSuffix = ".json")
      {
         var xml = File.ReadAllText(filename);
         XmlDocument doc = new XmlDocument();
         doc.LoadXml(xml);

         var builder = new StringBuilder();
         JsonSerializer.Create().Serialize(new CustomJsonWriter(new StringWriter(builder)), doc);
         var serialized = builder.ToString();
         var outputFile = filename + jsonSuffix;
         if (verbose)
         {
            Logger.Information("{InputFile} -> {OutputFile}", filename, outputFile);
         }

         File.WriteAllText(outputFile, serialized, Encoding.UTF8);
      }
   }
}
