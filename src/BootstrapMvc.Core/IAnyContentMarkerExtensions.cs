namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class IAnyContentMarkerExtensions
    {
        public static IItemWriter<T> CreateWriter<T>(this IAnyContentMarker target)
            where T : IWritableItem, new()
        {
            return target.Context.Helper.CreateWriter<T>(target.Context.GetCurrentParent());
        }

        public static IItemWriter<T, TContent> CreateWriter<T, TContent>(this IAnyContentMarker target)
            where T : ContentElement<TContent>, IWritableItem, new()
            where TContent : DisposableContent
        {
            return target.Context.Helper.CreateWriter<T, TContent>(target.Context.GetCurrentParent());
        }
    }
}
