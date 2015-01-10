using System;
using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc.Dropdown
{
    public class DropdownMenuContent : DisposableContent
    {
        public DropdownMenuContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public DropdownMenuItemLink Link()
        {
            return new DropdownMenuItemLink(Context);
        }

        public DropdownMenuItemLink Link(object content)
        {
            return (DropdownMenuItemLink)new DropdownMenuItemLink(Context).Content(content);
        }

        public DropdownMenuItemLink Link(IconType iconType, object content)
        {
            return (DropdownMenuItemLink)new DropdownMenuItemLink(Context).Content(new Icon(Context).Type(iconType), content);
        }

        public DropdownMenuItemLink Link(params object[] contents)
        {
            return (DropdownMenuItemLink)new DropdownMenuItemLink(Context).Content(contents);
        }

        public DropdownMenuItemDivider Divider()
        {
            return new DropdownMenuItemDivider(Context);
        }

        public DropdownMenuItemHeader Header(object content)
        {
            return (DropdownMenuItemHeader)new DropdownMenuItemHeader(Context).Content(content);
        }

        public DropdownMenuItemHeader Header(params object[] contents)
        {
            return (DropdownMenuItemHeader)new DropdownMenuItemHeader(Context).Content(contents);
        }

        public AnyContent BeginLink()
        {
            return new DropdownMenuItemLink(Context).BeginContent();
        }
    }
}
