# Xml2JsonConsole

Command line tool to generate `json` file from `xml` file.

## Usage 

`> Xml2JsonConsole.exe --help`

	Xml2JsonConsole 1.0.0.0
    Copyright c  2019
      -v, --verbose      Set output to verbose messages.
      -f, --filename     Filename of the file to convert to JSON.
      -d, --directory    Directory with .xml files to convert to json.
      --help             Display this help screen.
      --version          Display version information.


To convert `example.xml` to `example.xml.json` run:

`> Xml2JsonConsole.exe -f example.xml`

Example of input `xml` file.

    <?xml version="1.0" encoding="utf-8"?>
    <card>
        <name>Paulo P.</name>
        <title>Software Engineer</title>
        <email>pssp25@hotmail.com</email>
        <phone>(202) 000-0123</phone>
        <logo url="widget.gif"/>
    </card>

Converted to `json` format.

    {
      "xml": {
        "version": "1.0",
        "encoding": "utf-8"
      },
      "card": {
        "name": "Paulo P.",
        "title": "Software Engineer",
        "email": "pssp25@hotmail.com",
        "phone": "(202) 000-0123",
        "logo": {
          "url": "widget.gif"
        }
      }
    }



