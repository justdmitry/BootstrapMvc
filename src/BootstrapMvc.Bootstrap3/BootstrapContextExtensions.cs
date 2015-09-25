using System;
using BootstrapMvc.Core;

namespace BootstrapMvc
{
    public static class BootstrapContextExtensions
    {
        public static string GetMessage(this IBootstrapContext context, MessageType messageType)
        {
            return context.GetMessage((int)messageType);
        }
    }
}
