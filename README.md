# Frank.Templates

A collection of templates for things and stuff

___
[![GitHub License](https://img.shields.io/github/license/frankhaugen/Frank.Reflection)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/Frank.Reflection.svg)](https://www.nuget.org/packages/Frank.Reflection)
[![NuGet](https://img.shields.io/nuget/dt/Frank.Reflection.svg)](https://www.nuget.org/packages/Frank.Reflection)

![GitHub contributors](https://img.shields.io/github/contributors/frankhaugen/Frank.Reflection)
![GitHub Release Date - Published_At](https://img.shields.io/github/release-date/frankhaugen/Frank.Reflection)
![GitHub last commit](https://img.shields.io/github/last-commit/frankhaugen/Frank.Reflection)
![GitHub commit activity](https://img.shields.io/github/commit-activity/m/frankhaugen/Frank.Reflection)
![GitHub pull requests](https://img.shields.io/github/issues-pr/frankhaugen/Frank.Reflection)
![GitHub issues](https://img.shields.io/github/issues/frankhaugen/Frank.Reflection)
![GitHub closed issues](https://img.shields.io/github/issues-closed/frankhaugen/Frank.Reflection)
___

## Templates

| Template                        | Description                                                   | Usage                                           |
|---------------------------------|---------------------------------------------------------------|-------------------------------------------------|
| Frank.Templates.Generator       | A template for a solution that contains a generator           | `dotnet new -i Frank.Templates.Generator`       |
| Frank.Templates.Microservice    | A template for a microservice                                 | `dotnet new -i Frank.Templates.Microservice`    |
| Frank.Templates.MonoGame        | A template for a MonoGame solution                            | `dotnet new -i Frank.Templates.MonoGame`        |
| Frank.Templates.NoXaml.App      | A template for a WPF app project without XAML                 | `dotnet new -i Frank.Templates.NoXaml.App`      |
| Frank.Templates.NoXaml.Solution | A template for a solution with a WPF app project without XAML | `dotnet new -i Frank.Templates.NoXaml.Solution` |
| Frank.Templates.NugetSolution   | A template for a solution with a NuGet package project        | `dotnet new -i Frank.Templates.NugetSolution`   |
| Frank.Templates.SemanticKernel  | A template for a SemanticKernel project                       | `dotnet new -i Frank.Templates.SemanticKernel`  |

## How to use

### Install

To install a template, use the following command:

```bash
dotnet new install Frank.Templates::<version>
```

### Uninstall

To uninstall a template, use the following command:

```bash
dotnet new uninstall Frank.Templates::<version>
```