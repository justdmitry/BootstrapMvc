using System;

namespace BootstrapMvc.Core
{
    public interface IControlContextHolder
    {
        void SetControlContext(IControlContext context);
    }
}
