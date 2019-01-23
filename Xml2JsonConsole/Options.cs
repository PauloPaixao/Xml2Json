using CommandLine;

namespace Xml2JsonConsole
{
   public class Options
   {
      [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
      public bool Verbose { get; set; }

      [Option('f', "filename", Required = false, HelpText = "Filename of the file to convert to JSON.")]
      public string Filename { get; set; }

      [Option('d', "directory", Required = false, HelpText = "Directory with .xml files to convert to json.")]
      public string Directory { get; set; }

   }
}
