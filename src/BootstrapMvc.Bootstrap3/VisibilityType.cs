namespace BootstrapMvc
{
    using System;

    public enum VisibilityType : byte
    {
        VisibleXsBlock,
        VisibleXsInline,
        VisibleXsInlineBlock,

        VisibleSmBlock,
        VisibleSmInline,
        VisibleSmInlineBlock,

        VisibleMdBlock,
        VisibleMdInline,
        VisibleMdInlineBlock,

        VisibleLgBlock,
        VisibleLgInline,
        VisibleLgInlineBlock,

        HiddenXs,
        HiddenSm,
        HiddenMd,
        HiddenLg,

        [Obsolete("Use VisibleXsBlock")]
        VisibleXs = VisibleXsBlock,
        [Obsolete("Use VisibleSmBlock")]
        VisibleSm = VisibleSmBlock,
        [Obsolete("Use VisibleMdBlock")]
        VisibleMd = VisibleMdBlock,
        [Obsolete("Use VisibleLgBlock")]
        VisibleLg = VisibleLgBlock
    }
}
