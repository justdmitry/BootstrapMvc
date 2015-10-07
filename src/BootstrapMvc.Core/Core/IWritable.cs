using System;
using System.IO;

namespace BootstrapMvc.Core
{
    public interface IWritable
    {
        void WriteTo(TextWriter writer, IBootstrapContext context);
    }
}
