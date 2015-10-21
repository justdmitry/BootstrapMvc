namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class AnyContentElementExtensions
    {
        public static IItemWriter<T, AnyContent> Content<T>(
            this IItemWriter<T, AnyContent> target,
            object value)
            where T : AnyContentElement
        {
            var itemWriter = value as IItemWriter;
            if (itemWriter != null)
            {
                target.Item.AddContent(itemWriter.Item);
            }
            else
            {
                var block = new SimpleBlock();
                block.Value = value;
                block.Helper = target.Helper;
                target.Item.AddContent(block);
            }
            return target;
        }

        public static IItemWriter<T, AnyContent> Content<T>(
            this IItemWriter<T, AnyContent> target,
            params string[] values)
            where T : AnyContentElement
        {
            return Content(target, (object)string.Concat(values));
        }

        public static IItemWriter<T, AnyContent> Content<T>(
            this IItemWriter<T, AnyContent> target,
            params object[] values)
            where T : AnyContentElement
        {
            foreach (var value in values)
            {
                target.Content(value);
            }
            return target;
        }
    }
}
