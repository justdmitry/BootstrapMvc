using BootstrapMvc.Core;
using System;
using System.Collections.Generic;

namespace BootstrapMvc.Forms
{
    public class FormContent<T> : FormContent
    {
        public new IBootstrapContext<T> Context { get; private set; }

        public FormContent(IBootstrapContext<T> context)
            : base(context)
        {
            this.Context = context;
        }
    }
}
