using System;

namespace BootstrapMvc.Core
{
    public class BootstrapHelper<TModel> : BootstrapHelper, IAnyContentMarker<TModel>
    {
        public BootstrapHelper(IBootstrapContext<TModel> context)
            : base(context)
        {
            this.Context = context;
        }

        public new IBootstrapContext<TModel> Context { get; protected set; }
    }
}
