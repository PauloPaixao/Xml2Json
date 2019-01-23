using CommandLine;

namespace Xml2JsonConsole
{
   public class Options
   {
      [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.", Default = false)]
      public bool Verbose { get; set; }

      [Option('f', "filename", Required = false, HelpText = "Filename of the file to convert to JSON.")]
      public string Filename { get; set; }

      [Option('d', "directory", Required = false, HelpText = "Directory with .xml files to convert to json.")]
      public string Directory { get; set; }

      [Option('s', "suffix", Required = false, HelpText = "Suffix for the JSON files.", Default = ".json")]
      public string JsonSuffix { get; set; }

   }
}
