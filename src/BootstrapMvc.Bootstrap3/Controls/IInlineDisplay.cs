using System;

namespace BootstrapMvc.Controls
{
    public interface IInlineDisplay
    {
        void SetInline(bool inline = true);

        bool IsInline();
    }
}
