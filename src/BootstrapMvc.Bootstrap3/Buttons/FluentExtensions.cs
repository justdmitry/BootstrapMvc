using BootstrapMvc.Buttons;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        #region Button

        public static Button Type(this Button target, ButtonType value)
        {
            target.TypeValue = value;
            return target;
        }

        public static Button Size(this Button target, ButtonSize value)
        {
            target.SizeValue = value;
            return target;
        }

        public static Button BlockSize(this Button target, bool value = true)
        {
            target.BlockSizeValue = value;
            return target;
        }

        public static Button Disabled(this Button target, bool value = true)
        {
            target.DisabledValue = value;
            return target;
        }

        #endregion

        #region ButtonGroup

        public static ButtonGroup Size(this ButtonGroup target, ButtonSize value) 
        {
            target.SizeValue = value;
            return target;
        }

        public static ButtonGroup Vertical(this ButtonGroup target, bool value = true)
        {
            target.VerticalValue = value;
            return target;
        }

        public static ButtonGroup Justified(this ButtonGroup target, bool value = true)
        {
            target.JustifiedValue = value;
            return target;
        }

        public static ButtonGroup DropUp(this ButtonGroup target, bool value = true) 
        {
            target.DropUpValue = value;
            return target;
        }

        #endregion
    }
}
