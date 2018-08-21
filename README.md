![Build status](https://ci.appveyor.com/api/projects/status/github/andrey-igumnov/badapi?branch=master&svg=true&passingText=build%20-%20OK)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

# BadApi

## Test assignment
See [Test assignment](TEST.md).

## Requirements
.net core 2.1

## Usage
* Fork
* Clone
* Build
* Run console client application
* Result can be found in `result.json` file into `bin` directory

## Settings
Client settings can be modified in `appsettings.json` file.

|Settings name |Type  |Description |
|--|--|--|
|serviceUri |System.Uri  |Bad API service URI |
|requestTimeout |System.TimeSpan |HTTP Request timeout |
|output |System.String |Result file output path |
|startDate |System.DateTime |Default start date |
|endDate |System.DateTime |Default end date |

## Command line options
Console application could be started with command line options:
```
  -o, --output    Output result file path.
  -s, --start     Start date.
  -e, --end       End date.
  --help          Display this help screen.
  --version       Display version information.
  ```
  
  Example:
  `dotnet .\BadApi.Client.Console.dll -o res.txt -s "2017.01.01" -e "2017.02.01"`
