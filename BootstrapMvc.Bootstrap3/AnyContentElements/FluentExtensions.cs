using System;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        #region Alert

        public static Alert Type(this Alert target, AlertType value)
        {
            target.TypeValue = value;
            return target;
        }

        public static Alert Closable(this Alert target, bool value = true)
        {
            target.ClosableValue = value;
            return target;
        }

        #endregion

        #region Label

        public static Label Type(this Label target, LabelType value)
        {
            target.TypeValue = value;
            return target;
        }

        #endregion
    }
}
