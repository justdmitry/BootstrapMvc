namespace BootstrapMvc.Dropdown
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Elements;

    public partial class DropdownMenuContent : DisposableContent
    {
        public IItemWriter<DropdownMenuItemLink, AnyContent> Link(IconType iconType, object content)
        {
            var link = Link();
            link.Content(Context.Helper.CreateWriter<Icon>(link.Item).Type(iconType), content);
            return link;
        }
    }
}
