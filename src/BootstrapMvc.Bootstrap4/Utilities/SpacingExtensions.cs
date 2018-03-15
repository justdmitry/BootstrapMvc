namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class SpacingExtensions
    {
        public static readonly byte MaxValue = 5;

        public static readonly byte AutoValue = 255;

        public static IItemWriter<T> Padding<T>(this IItemWriter<T> target, SpacingSide side, byte value)
            where T : Element, IWritableItem
        {
            if (value > MaxValue && value != AutoValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            target.Item.AddCssClass("p" + side.ToCssClassSubstring() + "-" + (value == AutoValue ? "auto" : value.ToString()));
            return target;
        }

        public static IItemWriter<T, TContent> Padding<T, TContent>(this IItemWriter<T, TContent> target, SpacingSide side, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            if (value > MaxValue && value != AutoValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            target.Item.AddCssClass("p" + side.ToCssClassSubstring() + "-" + (value == AutoValue ? "auto" : value.ToString()));
            return target;
        }

        public static IItemWriter<T> Margin<T>(this IItemWriter<T> target, SpacingSide side, byte value)
            where T : Element, IWritableItem
        {
            if (value > MaxValue && value != AutoValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            target.Item.AddCssClass("m" + side.ToCssClassSubstring() + "-" + (value == AutoValue ? "auto" : value.ToString()));
            return target;
        }

        public static IItemWriter<T, TContent> Margin<T, TContent>(this IItemWriter<T, TContent> target, SpacingSide side, byte value)
            where T : ContentElement<TContent>
            where TContent : DisposableContent
        {
            if (value > MaxValue && value != AutoValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            target.Item.AddCssClass("m" + side.ToCssClassSubstring() + "-" + (value == AutoValue ? "auto" : value.ToString()));
            return target;
        }
    }
}
