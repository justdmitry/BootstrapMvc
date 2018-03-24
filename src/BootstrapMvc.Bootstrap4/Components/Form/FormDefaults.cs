namespace BootstrapMvc.Forms
{
    using System;
    using System.IO;
    using BootstrapMvc.Core;

    /// <summary>
    /// Class specially for default form type property. Nothing more.
    /// </summary>
    public abstract class FormDefaults
    {
        public static FormType Type = FormType.DefaultNone;

        public static GridSize HorizontalLabelWidth = new GridSize(0, 4, 4, 4, 4);

        public static GridSize InputNumberSize = new GridSize(0, 2, 2, 2, 2);

        public static GridSize InputDateSize = new GridSize(0, 3, 3, 3, 3);

        public static GridSize InputDateTimeSize = new GridSize(0, 6, 5, 5, 5);

        public static GridSize InputTimeSize = InputDateSize;
    }
}
