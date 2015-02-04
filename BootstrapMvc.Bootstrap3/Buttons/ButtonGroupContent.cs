using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc.Buttons
{
    public class ButtonGroupContent : DisposableContext
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
            var b = new Button(Context);
            b.Content(content);
            return b;
        }

        public Button Button(ButtonType type, object content)
        {
            var b = new Button(Context).Type(type);
            b.Content(content);
            return b;
        }

        public Button Button(ButtonType type, params object[] contents)
        {
            var b = new Button(Context).Type(type);
            b.Content(contents);
            return b;
        }

        public Button Button(ButtonType type, IconType iconType, object content)
        {
            var b = new Button(Context).Type(type);
            b.Content(new Icon(Context).Type(iconType), content);
            return b;
        }

        #endregion
    }
}
