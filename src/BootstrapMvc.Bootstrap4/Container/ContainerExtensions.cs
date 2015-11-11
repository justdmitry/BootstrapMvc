namespace BootstrapMvc
{
    using System;
    using Core;

    public static class ContainerExtensions
    {
        #region Fluent

        public static IItemWriter<T, AnyContent> Fluid<T>(this IItemWriter<T, AnyContent> target, bool fluid = true) 
            where T : Container
        {
            target.Item.Fluid = fluid;
            return target;
        }

        #endregion

        public static IItemWriter<Container, AnyContent> Container(this IAnyContentMarker contentHelper, bool fluid = false)
        {
            return contentHelper.CreateWriter<Container, AnyContent>().Fluid(fluid);
        }

        public static AnyContent BeginContainer(this IAnyContentMarker contentHelper, bool fluid = false)
        {
            return Container(contentHelper).Fluid(fluid).BeginContent();
        }
    }
}
