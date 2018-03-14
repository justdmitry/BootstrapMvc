using System;

namespace BootstrapMvc
{
    public interface IDisableable
    {
        void SetDisabled(bool disabled = true);

        bool Disabled();
    }
}
