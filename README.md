# DataMiner Visual Studio templates

This repository contains DataMiner templates that can be used with Visual Studio and the dotnet CLI.

## Available templates

The following section lists the currently available Visual Studio templates.

### Connector solution

Template that creates a new connector Visual Studio solution.

Short name: `dataminer-connector-solution`

### Automation script project

Template that creates a new Automation script Visual Studio project.

Short name: `dataminer-automation-project`

### Automation script library project

Template that creates a new Automation script library Visual Studio project.

Short name: `dataminer-automation-library-project`

### User-defined API project

Template that creates a new User-Defined API Visual Studio project.

Short name: `dataminer-user-defined-api-project`

### GQI ad hoc data source project

Template that creates a new GQI ad hoc data source Visual Studio project.

Short name: `dataminer-gqi-ad-hoc-data-source-project`

### Package project

Template that creates a new DataMiner package Visual Studio project.

Short name: `dataminer-package-project`

### Test package project

Template that creates a new DataMiner test package Visual Studio project.

Short name: `dataminer-test-package-project`

## Available templates for Internal

### BPA solution

Visual Studio template that creates a new DataMiner Best Practices Analyzer (BPA) solution.

### DataMiner Extension Module solution

Visual Studio template that creates a new DataMiner Extension Module (DxM) solution.

### NuGet solution

Visual Studio template that creates a Solution containing pre-filled meta-data to handle NuGet creation.

### NuGet project

Visual Studio template that creates a Project containing pre-filled meta-data to handle NuGet creation.

### .NET Tool solution

Visual Studio template that creates a Solution containing pre-filled meta-data to handle .NET Tool creation.

### .NET Tool project

Visual Studio template that creates a Project containing pre-filled meta-data to handle .NET Tool creation.

### Scripted connector project

Creates a Python based connector script project.

Language: Python

Short name: `dataminer-connector-script`

## How to install

As of version 2.42, DataMiner Integration Studio (DIS) automatically installs the latest template package when you open Visual Studio. If you don't have this version of DIS, then follow these steps:

1. Install the latest [.NET](https://dot.net)
2. Run 'dotnet new install Skyline.DataMiner.VisualStudioTemplates.Internal' to install the templates.

> **Note**
> *New to DIS?* If you haven’t used DIS before and want to find out all about this extension for Microsoft Visual Studio, visit our  [DIS expert Hub](https://community.dataminer.services/exphub-dis/) on DataMiner Dojo for more detailed information, downloads, and more.

## How to use

### Using Visual Studio

1. Select DataMiner from the project type drop down.
2. Select the template you want to install and follow the instructions.

![Visual Studio New Project Window](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/images/VisualStudio-NewProject.png)

### Using the CLI

1. Choose a project template i.e. `dataminer-connector-solution`.
2. Run `dotnet new dataminer-connector-solution --help` to see the available options.
3. Run `dotnet new dataminer-connector-solution` with the required options along with any other options to create a solution from the template.

## How to contribute

To add additional templates:

1. Create your new template.
2. Place it in the `working/templates` folder.

For more details on creating templates, refer to:

- [learn microsoft](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates)

- [DotNet Templating](https://github.com/dotnet/templating/wiki)

## License

This project is licensed under the [MIT License](https://github.com/SkylineCommunications/Skyline.DataMiner.VisualStudioTemplates/blob/main/LICENSE). See the file for details.

### Testing Locally

1. Open the CLI in the `working` directory.
2. Pack the project:
   ```bash
   dotnet pack
   ```
3. Uninstall the current template (if applicable):
   ```bash
   dotnet new uninstall skyline.dataminer.visualstudiotemplates.Internal
   ```
4. Install the new package:
   ```bash
   dotnet new install "bin\Release\Skyline.DataMiner.VisualStudioTemplates.Internal.0.0.1-beta.nupkg"
   ```
5. Test the template to ensure it works as expected.
