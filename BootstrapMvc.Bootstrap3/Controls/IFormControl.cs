using System;
using BootstrapMvc.Core;

namespace BootstrapMvc.Controls
{
    public interface IFormControl : IWritable
    {
        void SetControlContext(IControlContext context);
    }
}
