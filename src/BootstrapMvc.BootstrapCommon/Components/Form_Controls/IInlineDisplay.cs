namespace BootstrapMvc.Controls
{
    using System;

    public interface IInlineDisplay
    {
        void SetInline(bool inline = true);

        bool IsInline();
    }
}
