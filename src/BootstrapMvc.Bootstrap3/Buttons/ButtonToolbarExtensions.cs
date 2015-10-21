using System;
using BootstrapMvc.Core;
using BootstrapMvc.Buttons;

namespace BootstrapMvc
{
    public static class ButtonToolbarExtensions
    {
        #region Generation

        public static IItemWriter<ButtonToolbar, ButtonToolbarContent> ButtonToolbar(this IAnyContentMarker contentHelper)
        {
            return contentHelper.CreateWriter<ButtonToolbar, ButtonToolbarContent>();
        }

        public static ButtonToolbarContent BeginButtonToolbar(this IAnyContentMarker contentHelper)
        {
            return ButtonToolbar(contentHelper).BeginContent();
        }

        #endregion 
    }
}
