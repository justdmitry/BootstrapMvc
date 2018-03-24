namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;
    using BootstrapMvc.Buttons;

    public static partial class ButtonGroupExtensions
    {
        #region Fluent

        public static IItemWriter<T, ButtonGroupContent> Vertical<T>(this IItemWriter<T, ButtonGroupContent> target, bool value = true) where T : ButtonGroup
        {
            target.Item.Vertical = value;
            return target;
        }

        public static IItemWriter<T, ButtonGroupContent> DropUp<T>(this IItemWriter<T, ButtonGroupContent> target, bool value = true) where T : ButtonGroup
        {
            target.Item.DropUp = value;
            return target;
        }

        public static IItemWriter<T, ButtonGroupContent> AddButton<T, TButton>(this IItemWriter<T, ButtonGroupContent> target, IItemWriter<TButton, AnyContent> button)
            where T : ButtonGroup
            where TButton : Button
        {
            target.Item.AddButton(button.Item);
            return target;
        }

        public static IItemWriter<T, ButtonGroupContent> AddButton<T, TButton>(this IItemWriter<T, ButtonGroupContent> target, params IItemWriter<TButton, AnyContent>[] buttons)
            where T : ButtonGroup
            where TButton : Button
        {
            foreach (var button in buttons)
            {
                AddButton(target, button);
            }
            return target;
        }

        #endregion

        public static IItemWriter<ButtonGroup, ButtonGroupContent> ButtonGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ButtonGroup, ButtonGroupContent>();
        }

        public static IItemWriter<ButtonGroup, ButtonGroupContent> ButtonGroup(this IAnyContentMarker contentHelper, ControlSize size)
        {
            return contentHelper.CreateWriter<ButtonGroup, ButtonGroupContent>().Size(size);
        }

        public static ButtonGroupContent BeginButtonGroup(this IAnyContentMarker contentHelper)
        {
            return ButtonGroup(contentHelper).BeginContent();
        }

        public static ButtonGroupContent BeginButtonGroup(this IAnyContentMarker contentHelper, ControlSize size)
        {
            return ButtonGroup(contentHelper).Size(size).BeginContent();
        }
    }
}
