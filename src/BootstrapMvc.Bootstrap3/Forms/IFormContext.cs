using System;

namespace BootstrapMvc.Forms
{
    public interface IFormContext
    {
        SubmitMethod MethodValue { get; }

        FormEnctype EnctypeValue { get; }

        FormType TypeValue { get; }

        string HrefValue { get; }

        GridSize LabelWidthValue { get; }

        GridSize ControlsWidthValue { get; }
    }
}
