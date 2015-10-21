namespace BootstrapMvc.Dropdown
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Elements;

    public class DropdownMenuContent : DisposableContent
    {
        public DropdownMenuContent(IBootstrapContext context, DropdownMenu parent)
        {
            this.Context = context;
            this.Parent = parent;
        }

        private IBootstrapContext Context { get; set; }

        private DropdownMenu Parent { get; set; }

        public IItemWriter<DropdownMenuItemLink, AnyContent> Link()
        {
            return Context.Helper.CreateWriter<DropdownMenuItemLink, AnyContent>(Parent);
        }

        public IItemWriter<DropdownMenuItemLink, AnyContent> Link(object content)
        {
            return Link().Content(content);
        }

        public IItemWriter<DropdownMenuItemLink, AnyContent> Link(IconType iconType, object content)
        {
            var link = Link();
            link.Content(Context.Helper.CreateWriter<Icon>(link.Item).Type(iconType), content);
            return link;
        }

        public IItemWriter<DropdownMenuItemLink, AnyContent> Link(params object[] contents)
        {
            return Link().Content(contents);
        }

        public IItemWriter<DropdownMenuItemDivider> Divider()
        {
            return Context.Helper.CreateWriter<DropdownMenuItemDivider>(Parent);
        }

        public IItemWriter<DropdownMenuItemHeader, AnyContent> Header(object content)
        {
            return Context.Helper.CreateWriter<DropdownMenuItemHeader, AnyContent>(Parent).Content(content);
        }

        public IItemWriter<DropdownMenuItemHeader, AnyContent> Header(params object[] contents)
        {
            return Context.Helper.CreateWriter<DropdownMenuItemHeader, AnyContent>(Parent).Content(contents);
        }

        public AnyContent BeginLink()
        {
            return Link().BeginContent();
        }
    }
}
