namespace BootstrapMvc
{
    using System;
    using BootstrapMvc.Core;

    public static class BootstrapContextExtensions
    {
        public static string GetMessage(this IBootstrapContext context, MessageType messageType)
        {
            return context.Helper.GetMessage((int)messageType);
        }
    }
}
