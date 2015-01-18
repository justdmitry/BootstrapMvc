# BootstrapMvc

Extendable packages pack for simplifying Bootstrap markup in your ASP.MVC projects. 

## Packages list

* [BootstrapMvc.Core](https://www.nuget.org/packages/BootstrapMvc.Core/) - core library, containing base clasess only;
* [BootstrapMvc.Bootstrap3](https://www.nuget.org/packages/BootstrapMvc.Bootstrap3/) - helper classes for Bootstrap 3.3 (not complete at this moment), not bound to any MVC version;
* [BootstrapMvc.Mvc5](https://www.nuget.org/packages/BootstrapMvc.Mvc5/) - classes for integrating with ASP.MVC5 infrastructure;
* **[BootstrapMvc.Bootstrap3Mvc5](https://www.nuget.org/packages/BootstrapMvc.Bootstrap3Mvc5/) - empty package (but with correct dependencies) for using in your MVC5 projects.**

In the future, *BootstrapMvc.Mvc6* and *BootstrapMvc.Bootstrap3Mvc6* will be added.

## Key features

1. **Library decomposition** - allows creating different packages for different Bootstrap and/or Mvc versions with minimal code duplicating and without unneeded dependencies;
2. **Highly extendable** - you can add helper methods to modify/extend existing classes, or add new classes, directly in your MVC project, not in package sources;
3. **Fluent** - write short and efficient code;  
4. **TextWriter-based** - internally, all HTML is written directry to `TextWriter-s`, minimizing String allocation and concatenation;
5. **Open source** - fork it, extend it, use it!

## Installation

### 1. Install package via NuGet

Install [BootstrapMvc.Bootstrap3Mvc5](https://www.nuget.org/packages/BootstrapMvc.Bootstrap3Mvc5/) package from NuGet to your ASP.MVC5 project.

### 2. Modify `Views\web.config` file

Modify your `Views\Web.config` file (and all `Areas\<Area>\Views\Web.config` too), replace base class for views (in `<system.web.webPages.razor>` section), instead:

    <pages pageBaseType="System.Web.Mvc.WebViewPage">

write

    <pages pageBaseType="BootstrapMvc.Core.BootstrapViewPage">

And add one more `namespace` to namespaces list:

    <add namespace="BootstrapMvc" />

### 3. Clean and Rebuild your project

Clean and Rebuild you project to activate changes and activate intellisence. Rarely, a Visual Studio restart also needed.

## Using

Just one sample - toolbar with button with dropdown menu. You remember how much markup you should write. Now you can: 

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
    
Of course you can do more than simple buttons and create URLs better than using string values - look for more extension methods.
