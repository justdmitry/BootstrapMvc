namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class DropdownMenuContentExtensions
    {
        public static IItemWriter<DropdownMenuItemLink, AnyContent> Link(this DropdownMenuContent target, IconType iconType, object content)
        {
            var link = target.Link();
            link.Content(link.Helper.CreateWriter<Icon>(link.Item).Type(iconType), content);
            return link;
        }
    }
}
