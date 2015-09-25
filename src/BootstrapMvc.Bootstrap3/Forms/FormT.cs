using System;
using System.Collections.Generic;
using BootstrapMvc.Core;

namespace BootstrapMvc.Forms
{
    public class Form<T> : Form
    {
        public new IBootstrapContext<T> Context { get; private set; }

        public Form(IBootstrapContext<T> context)
            : base(context)
        {
            this.Context = context;
        }

        public new FormContent<T> BeginContent()
        {
            return (FormContent<T>)base.BeginContent();
        }

        protected override FormContent CreateContentContext()
        {
            return new FormContent<T>(Context);
        }
    }
}
