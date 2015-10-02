using System;
using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuContent : DisposableContent
    {
        public DropdownMenuContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        public IWriter2<DropdownMenuItemLink, AnyContent> Link()
        {
            return Context.CreateWriter<DropdownMenuItemLink, AnyContent>();
        }

        public IWriter2<DropdownMenuItemLink, AnyContent> Link(object content)
        {
            return Context.CreateWriter<DropdownMenuItemLink, AnyContent>().Content(content);
        }

        public IWriter2<DropdownMenuItemLink, AnyContent> Link(IconType iconType, object content)
        {
            return Context.CreateWriter<DropdownMenuItemLink, AnyContent>().Content(Context.CreateWriter<Icon>().Type(iconType), content);
        }

        public IWriter2<DropdownMenuItemLink, AnyContent> Link(params object[] contents)
        {
            return Context.CreateWriter<DropdownMenuItemLink, AnyContent>().Content(contents);
        }

        public IWriter<DropdownMenuItemDivider> Divider()
        {
            return Context.CreateWriter<DropdownMenuItemDivider>();
        }

        public IWriter2<DropdownMenuItemHeader, AnyContent> Header(object content)
        {
            return Context.CreateWriter<DropdownMenuItemHeader, AnyContent>().Content(content);
        }

        public IWriter2<DropdownMenuItemHeader, AnyContent> Header(params object[] contents)
        {
            return Context.CreateWriter<DropdownMenuItemHeader, AnyContent>().Content(contents);
        }

        public AnyContent BeginLink()
        {
            return Link().BeginContent();
        }
    }
}
