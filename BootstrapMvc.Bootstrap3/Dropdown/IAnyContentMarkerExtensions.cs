using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static partial class IAnyContentMarkerExtensions
    {
        #region ButtonToolbar

        public static ButtonToolbar ButtonToolbar(this IAnyContentMarker contentHelper)
        {
            return new ButtonToolbar(contentHelper.Context);
        }

        public static ButtonToolbarContent BeginButtonToolbar(this IAnyContentMarker contentHelper)
        {
            return new ButtonToolbar(contentHelper.Context).BeginContent();
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
            return new ButtonGroup(contentHelper.Context).BeginContent();
        }

        public static ButtonGroupContent BeginButtonGroup(this IAnyContentMarker contentHelper, ButtonSize size)
        {
            return new ButtonGroup(contentHelper.Context).Size(size).BeginContent();
        }

        #endregion

        public static Button Button(this IAnyContentMarker contentHelper, object content)
        {
            return (Button)new Button(contentHelper.Context).AddContent(content);
        }

        public static Button Button(this IAnyContentMarker contentHelper, ButtonType type, object content)
        {
            return (Button)new Button(contentHelper.Context).Type(type).AddContent(content);
        }

        public static Button Button(this IAnyContentMarker contentHelper, ButtonType type, params object[] contents)
        {
            return (Button)new Button(contentHelper.Context).Type(type).AddContent(contents);
        }

        public static Button Button(this IAnyContentMarker contentHelper, IconType iconType, object content)
        {
            return (Button)new Button(contentHelper.Context).AddContent(new Icon().Type(iconType), content);
        }

        public static Button Button(this IAnyContentMarker contentHelper, ButtonType type, IconType iconType, object content)
        {
            return (Button)new Button(contentHelper.Context).Type(type).AddContent(new Icon().Type(iconType), content);
        }

        public static DropdownMenu DropdownMenu(this IAnyContentMarker contentHelper)
        {
            return new DropdownMenu(contentHelper.Context);
        }
    }
}
