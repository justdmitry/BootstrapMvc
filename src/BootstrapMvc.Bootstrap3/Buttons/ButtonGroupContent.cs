using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc.Buttons
{
    public class ButtonGroupContent : DisposableContent
    {
        public ButtonGroupContent(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        #region ButtonGroup

        public ButtonGroup ButtonGroup()
        {
            return new ButtonGroup(Context);
        }

        public ButtonGroupContent BeginButtonGroup()
        {
            return new ButtonGroup(Context).BeginContent();
        }

        #endregion

        #region Button

        public Button Button()
        {
            return new Button(Context);
        }

        public Button Button(object content)
        {
            return new Button(Context).Content(content);
        }

        public Button Button(ButtonType type, object content)
        {
            return new Button(Context).Type(type).Content(content);
        }

        public Button Button(ButtonType type, params object[] contents)
        {
            return new Button(Context).Type(type).Content(contents);
        }

        public Button Button(IconType iconType)
        {
            return new Button(Context).Content(new Icon(Context).Type(iconType));
        }

        public Button Button(IconType iconType, object content)
        {
            return new Button(Context).Content(new Icon(Context).Type(iconType), content);
        }

        public Button Button(ButtonType type, IconType iconType)
        {
            return new Button(Context).Type(type).Content(new Icon(Context).Type(iconType));
        }

        public Button Button(ButtonType type, IconType iconType, object content)
        {
            return new Button(Context).Type(type).Content(new Icon(Context).Type(iconType), content);
        }

        #endregion
    }
}
