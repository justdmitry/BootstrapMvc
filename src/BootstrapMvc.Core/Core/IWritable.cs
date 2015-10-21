namespace BootstrapMvc.Core
{
    using System;
    using System.IO;

    public interface IWritable
    {
        void WriteTo(TextWriter writer);
    }
}
