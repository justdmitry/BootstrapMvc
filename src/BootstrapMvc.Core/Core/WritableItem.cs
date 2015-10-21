namespace BootstrapMvc.Core
{
    using System;
    using System.IO;

    public abstract partial class WritableItem : IWritableItem
    {
        public IWritableItem Parent { get; set; }

        public bool WithWhitespaceSuffix { get; set; }

        public IWritingHelper Helper { get; set; }
        
        public void WriteTo(TextWriter writer)
        {
            WriteSelf(writer);
            if (WithWhitespaceSuffix)
            {
                writer.Write(" ");
            }
        }

        protected abstract void WriteSelf(TextWriter writer);

        public T GetNearestParent<T>() where T : class, IWritableItem
        {
            if (Parent == null)
            {
                return null;
            }
            var parentAsT = Parent as T;
            if (parentAsT != null)
            {
                return parentAsT;
            }
            return Parent.GetNearestParent<T>();
        }
    }
}
