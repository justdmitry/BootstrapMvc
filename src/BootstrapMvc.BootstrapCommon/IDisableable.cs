namespace BootstrapMvc
{
    using System;

    public interface IDisableable
    {
        void SetDisabled(bool disabled = true);

        bool Disabled();
    }
}
