# BootstrapMvc

Extendable packages pack for simplifying Bootstrap markup in your ASP.MVC projects. 

## Packages list

* [BootstrapMvc.Core](https://www.nuget.org/packages/BootstrapMvc.Core/) - core library, containing base clasess only;
* [BootstrapMvc.Bootstrap3](https://www.nuget.org/packages/BootstrapMvc.Bootstrap3/) - helper classes for Bootstrap 3.3 (not complete at this moment), not bound to any MVC version;
* [BootstrapMvc.Mvc5](https://www.nuget.org/packages/BootstrapMvc.Mvc5/) - classes for integrating with ASP.MVC5 infrastructure;
* [BootstrapMvc.Mvc6](https://www.nuget.org/packages/BootstrapMvc.Mvc6/) - classes for integrating with ASP.NET Core / MVC6 infrastructure;
* **[BootstrapMvc.Bootstrap3Mvc5](https://www.nuget.org/packages/BootstrapMvc.Bootstrap3Mvc5/) - 'use-this' package (with correct dependencies) for using in your MVC5 projects.**
* **[BootstrapMvc.Bootstrap3Mvc6](https://www.nuget.org/packages/BootstrapMvc.Bootstrap3Mvc6/) - 'use-this' package (with correct dependencies) for using in your ASP.NET Core / MVC6 projects.**

## Key features

1. **Library decomposition** - allows creating different packages for different Bootstrap and/or Mvc versions with minimal code duplicating and without unneeded dependencies;
2. **Highly extendable** - you can add helper methods to modify/extend existing classes, or add new classes, directly in your MVC project, not in package sources;
3. **Fluent** - write short and efficient code;  
4. **TextWriter-based** - internally, all HTML is written directry to `TextWriter-s`, minimizing String allocation and concatenation;
5. **Open source** - fork it, extend it, use it!

## Usage

Just one sample - toolbar with button with dropdown menu. You remember how much markup you should write. Now you can: 

```csharp
using (Bootstrap.BeginButtonToolbar()) 
{
    using (Bootstrap.BeginButtonGroup(ButtonSize.Small))
    {
        @Bootstrap.Button(ButtonType.SuccessGreen, IconType.Ok, "Hello, world!").Href("/hello.html")
        @using (var dropdown = Bootstrap.Button(ButtonType.InfoCyan, "This is dropdown").BeginDropdown()) 
        {
            @dropdown.Link(IconType.Plus_Sign, "Link 1").Href("/page1.html")
            @dropdown.Divider()
            @dropdown.Link(IconType.Plus_Sign, "Link 2").Href("/page2.html")
        }
    }
}
```
    
Of course you can do more than simple buttons and create URLs better than using string values - look for more extension methods.

Also, view sample sites for [ASP.NET MVC5](http://bootstrap3mvc5.azurewebsites.net/) and [ASP.NET Core / MVC6](http://bootstrap3mvc6.azurewebsites.net/)

## Installation for MVC5

### 1. Install package via NuGet

Install [BootstrapMvc.Bootstrap3Mvc5](https://www.nuget.org/packages/BootstrapMvc.Bootstrap3Mvc5/) package from NuGet to your ASP.MVC5 project.

### 2. Modify `Views\web.config` file

Modify your `Views\Web.config` file (and all `Areas\<Area>\Views\Web.config` too), replace base class for views (in `<system.web.webPages.razor>` section), instead:

```xml
<pages pageBaseType="System.Web.Mvc.WebViewPage">
```

write

```xml
<pages pageBaseType="BootstrapMvc.Core.BootstrapViewPage">
```

And add one more `namespace` to namespaces list:

```xml
<add namespace="BootstrapMvc" />
```

### 3. Clean and Rebuild your project

Clean and Rebuild you project to activate changes and activate intellisence. Rarely, a Visual Studio restart also needed.

## Installation for ASP.NET Core

### 1. Add dependency to `project.json`

```json
"dependencies": {
    ...
    "BootstrapMvc.Bootstrap3Mvc6": "2.2.0"
}
```

**RTM** build of ASP.NET Core / MVC6 is supported.

### 2. Update `Views\_ViewImports.cshtml` file

Add two lines to `Views\_ViewImports.cshtml` file (create it if not exists):

```
@using BootstrapMvc
@inject BootstrapMvc.Mvc6.BootstrapHelper<TModel> Bootstrap
```

### 3. Register in DI container

Append to `ConfigureServices()` method in `Startup.cs` file:
   
```csharp 
services.AddTransient(typeof(BootstrapMvc.Mvc6.BootstrapHelper<>));
```