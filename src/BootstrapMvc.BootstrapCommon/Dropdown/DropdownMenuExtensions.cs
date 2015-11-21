namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class DropdownMenuExtensions
    {
        public static IItemWriter<T, DropdownMenuContent> RightAlign<T>(this IItemWriter<T, DropdownMenuContent> target, bool value = true) 
            where T : DropdownMenu
        {
            target.Item.RightAlign = value;
            return target;
        }

        #region Generating

        public static IItemWriter<DropdownMenu, DropdownMenuContent> DropdownMenu(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<DropdownMenu, DropdownMenuContent>();
        }

        #endregion
    }
}
