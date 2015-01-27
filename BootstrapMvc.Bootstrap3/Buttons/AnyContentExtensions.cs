using System;
using BootstrapMvc.Buttons;
using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc
{
    public static partial class AnyContentExtensions
    {
        #region ButtonToolbar

        public static ButtonToolbar ButtonToolbar(this IAnyContentMarker contentHelper)
        {
            return new ButtonToolbar(contentHelper.Context);
        }

        public static ButtonToolbarContent BeginButtonToolbar(this IAnyContentMarker contentHelper)
        {
            return ButtonToolbar(contentHelper).BeginContent();
        }

        #endregion 

        #region ButtonGroup

        public static ButtonGroup ButtonGroup(this IAnyContentMarker contentHelper)
        {
            return new ButtonGroup(contentHelper.Context);
        }

        public static ButtonGroup ButtonGroup(this IAnyContentMarker contentHelper, ButtonSize size)
        {
            return new ButtonGroup(contentHelper.Context).Size(size);
        }

        public static ButtonGroupContent BeginButtonGroup(this IAnyContentMarker contentHelper)
        {
            return ButtonGroup(contentHelper).BeginContent();
        }

        public static ButtonGroupContent BeginButtonGroup(this IAnyContentMarker contentHelper, ButtonSize size)
        {
            return ButtonGroup(contentHelper).Size(size).BeginContent();
        }

        #endregion

        public static Button Button(this IAnyContentMarker contentHelper, object content)
        {
            return new Button(contentHelper.Context).Content(content);
        }

        public static Button Button(this IAnyContentMarker contentHelper, ButtonType type, object content)
        {
            return new Button(contentHelper.Context).Type(type).Content(content);
        }

        public static Button Button(this IAnyContentMarker contentHelper, ButtonType type, params object[] contents)
        {
            return new Button(contentHelper.Context).Type(type).Content(contents);
        }

        public static Button Button(this IAnyContentMarker contentHelper, IconType iconType, object content)
        {
            return new Button(contentHelper.Context).Content(new Icon(contentHelper.Context).Type(iconType), content);
        }

        public static Button Button(this IAnyContentMarker contentHelper, ButtonType type, IconType iconType, object content)
        {
            return new Button(contentHelper.Context).Type(type).Content(new Icon(contentHelper.Context).Type(iconType), content);
        }
    }
}
