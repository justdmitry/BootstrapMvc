using BootstrapMvc.Lists;

namespace BootstrapMvc
{
    public static partial class FluentExtensions
    {
        #region DefinitionList

        public static DefinitionList Horizontal(this DefinitionList target, bool value = true)
        {
            target.HorizontalValue = value;
            return target;
        }

        #endregion

        #region List

        public static List Type(this List target, ListType value)
        {
            target.TypeValue = value;
            return target;
        }

        #endregion
    }
}
