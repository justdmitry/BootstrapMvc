using System;

namespace BootstrapMvc.Core
{
    public interface IWritable
    {
        void WriteTo(System.IO.TextWriter writer);
    }
}
