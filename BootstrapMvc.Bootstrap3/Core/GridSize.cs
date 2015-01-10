using System;

namespace BootstrapMvc.Core
{
    public struct GridSize
    {
        public static readonly byte ColumnsCount = 12;

        private byte xs;

        private byte sm;

        private byte md;

        private byte lg;

        private byte xsOffset;

        private byte smOffset;

        private byte mdOffset;

        private byte lgOffset;

        public GridSize(byte xs, byte sm, byte md, byte lg)
            : this(xs, sm, md, lg, 0, 0, 0, 0)
        {
            // Nothing
        }

        public GridSize(byte xs, byte sm, byte md, byte lg, byte xsOffset, byte smOffset, byte mdOffset, byte lgOffset)
        {
            if (xs > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("xs");
            }
            if (sm > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("sm");
            }
            if (md > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("md");
            }
            if (lg > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("lg");
            }
            if ((xs + xsOffset) > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("xsOffset");
            }
            if ((sm + smOffset) > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("smOffset");
            }
            if ((md + mdOffset) > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("mdOffset");
            }
            if ((lg + lgOffset) > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("lgOffset");
            }
            this.xs = xs;
            this.sm = sm;
            this.md = md;
            this.lg = lg;
            this.xsOffset = xsOffset;
            this.smOffset = smOffset;
            this.mdOffset = mdOffset;
            this.lgOffset = lgOffset;
        }

        public string ToCssClass()
        {
            return (xs == 0 ? string.Empty : " col-xs-" + xs)
                 + (sm == 0 ? string.Empty : " col-sm-" + sm)
                 + (md == 0 ? string.Empty : " col-md-" + md)
                 + (lg == 0 ? string.Empty : " col-lg-" + lg)
                 + (xsOffset == 0 ? string.Empty : " col-offset-xs-" + xsOffset)
                 + (smOffset == 0 ? string.Empty : " col-offset-sm-" + smOffset)
                 + (mdOffset == 0 ? string.Empty : " col-offset-md-" + mdOffset)
                 + (lgOffset == 0 ? string.Empty : " col-offset-lg-" + lgOffset);
        }

        public GridSize Invert()
        {
            return new GridSize(
                (byte)(xs == 0 ? 0 : ColumnsCount - xs),
                (byte)(sm == 0 ? 0 : ColumnsCount - sm),
                (byte)(md == 0 ? 0 : ColumnsCount - md),
                (byte)(lg == 0 ? 0 : ColumnsCount - lg));
        }

        public GridSize Offset(GridSize value)
        {
            return new GridSize(xs, sm, md, lg, value.xs, value.sm, value.md, value.lg);
        }
    }
}
