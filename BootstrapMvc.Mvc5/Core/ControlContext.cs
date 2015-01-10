using System;

namespace BootstrapMvc.Core
{
    public class ControlContext : IControlContext
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public bool IsRequired { get; set; }

        public string[] Errors { get; set; }

        public bool HasErrors { get; set; }

        public bool HasWarning { get; set; }
    }
}
