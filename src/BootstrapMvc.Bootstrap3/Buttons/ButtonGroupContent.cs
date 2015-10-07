using BootstrapMvc.Core;
using BootstrapMvc.Elements;

namespace BootstrapMvc.Buttons
{
    public class ButtonGroupContent : DisposableContent
    {
        public ButtonGroupContent(IBootstrapContext context)
        {
            this.Context = context;
        }

        public IBootstrapContext Context { get; private set; }

        #region ButtonGroup

        public IWriter2<ButtonGroup, ButtonGroupContent> ButtonGroup()
        {
            return Context.CreateWriter<ButtonGroup, ButtonGroupContent>();
        }

        public ButtonGroupContent BeginButtonGroup()
        {
            return ButtonGroup().BeginContent();
        }

        #endregion

        #region Button

        public IWriter2<Button, AnyContent> Button()
        {
            return Context.CreateWriter<Button, AnyContent>();
        }

        public IWriter2<Button, AnyContent> Button(object content)
        {
            return Context.CreateWriter<Button, AnyContent>().Content(content);
        }

        public IWriter2<Button, AnyContent> Button(ButtonType type, object content)
        {
            return Context.CreateWriter<Button, AnyContent>().Type(type).Content(content);
        }

        public IWriter2<Button, AnyContent> Button(ButtonType type, params object[] contents)
        {
            return Context.CreateWriter<Button, AnyContent>().Type(type).Content(contents);
        }

        public IWriter2<Button, AnyContent> Button(IconType iconType)
        {
            return Context.CreateWriter<Button, AnyContent>().Content(Context.CreateWriter<Icon>().Type(iconType));
        }

        public IWriter2<Button, AnyContent> Button(IconType iconType, object content)
        {
            return Context.CreateWriter<Button, AnyContent>().Content(Context.CreateWriter<Icon>().Type(iconType), content);
        }

        public IWriter2<Button, AnyContent> Button(ButtonType type, IconType iconType)
        {
            return Context.CreateWriter<Button, AnyContent>().Type(type).Content(Context.CreateWriter<Icon>().Type(iconType));
        }

        public IWriter2<Button, AnyContent> Button(ButtonType type, IconType iconType, object content)
        {
            return Context.CreateWriter<Button, AnyContent>().Type(type).Content(Context.CreateWriter<Icon>().Type(iconType), content);
        }

        #endregion
    }
}
