using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Controls
{
    public interface IFormControl : IControlContextHolder, IWritable, IDisableable
    {
        // Nothing more
    }
}
