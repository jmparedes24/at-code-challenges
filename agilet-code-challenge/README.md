# agilet-code-challenge

## Overview

This is an .NET Core API that sort names array in base a order array provide

## Pre requirements

- .Net 6 Installation
  - Link [.Net_6_Sdk https://dotnet.microsoft.com/en-us/download/dotnet/6.0]

## Execution

### Development

- On folder **agilet-code-challenge** (that contains project agilet-code-challenge.csproj) run the following commands
  - **dotnet restore** (optional) it will install the necessary packages but this command is implicit on dotnet build
  - **dotnet build** to build the application
  - **dotnet watch run** it launches the site and that API detects any change on code automatically and refresh the site
  - **dotnet run** it launches the site on port specified on file .\Properties\lauchSettings.json (https://localhost:7143)
  - Application can be test using swagger on https://localhost:7137/swagger/index.html
