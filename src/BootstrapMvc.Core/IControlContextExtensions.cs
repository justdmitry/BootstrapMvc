namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class IControlContextExtensions
    {
        public static TWriter FieldName<TWriter, TItem>(this TWriter target, string name)
            where TWriter : IItemWriter<TItem>
            where TItem : IControlContext
        {
            target.Item.FieldName = name;
            return target;
        }

        public static TWriter FieldValue<TWriter, TItem>(this TWriter target, object value)
            where TWriter : IItemWriter<TItem>
            where TItem : IControlContext
        {
            target.Item.FieldValue = value;
            return target;
        }

        public static TWriter Required<TWriter, TItem>(this TWriter target, bool required = true)
            where TWriter : IItemWriter<TItem>
            where TItem : IControlContext
        {
            target.Item.IsRequired = required;
            return target;
        }
        
        public static TWriter Errors<TWriter, TItem>(this TWriter target, string[] errors)
            where TWriter : IItemWriter<TItem>
            where TItem : IControlContext
        {
            target.Item.Errors = errors;
            target.Item.HasErrors = (errors != null && errors.Length > 0);
            return target;
        }
    }
}
