using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public class DropdownMenuContent : DisposableContent
    {
        public DropdownMenuItemLink Link()
        {
            return new DropdownMenuItemLink(Context);
        }

        public DropdownMenuItemLink Link(object content)
        {
            return (DropdownMenuItemLink)new DropdownMenuItemLink(Context).AddContent(content);
        }

        public DropdownMenuItemLink Link(IconType iconType, object content)
        {
            return (DropdownMenuItemLink)new DropdownMenuItemLink(Context).AddContent(new Icon().Type(iconType)).AddContent(content);
        }

        public DropdownMenuItemLink Link(params object[] contents)
        {
            return (DropdownMenuItemLink)new DropdownMenuItemLink(Context).AddContent(contents);
        }

        public DropdownMenuItemDivider Divider()
        {
            return new DropdownMenuItemDivider();
        }

        public DropdownMenuItemHeader Header(object content)
        {
            return (DropdownMenuItemHeader)new DropdownMenuItemHeader(Context).AddContent(content);
        }

        public DropdownMenuItemHeader Header(params object[] contents)
        {
            return (DropdownMenuItemHeader)new DropdownMenuItemHeader(Context).AddContent(contents);
        }

        public AnyContent BeginItem()
        {
            return new DropdownMenuItemLink(Context).BeginContent();
        }
    }
}
