namespace BootstrapMvc.Forms
{
    using System;
    using BootstrapMvc.Core;

    public interface IForm : IWritableItem
    {
        SubmitMethod Method { get; }

        FormEnctype Enctype { get; }

        FormType Type { get; }

        string Href { get; }

        GridSize LabelWidth { get; }

        GridSize ControlsWidth { get; }
    }
}
