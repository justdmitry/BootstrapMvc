using System;

namespace BootstrapMvc
{
    public struct GridSize
    {
        public static readonly byte ColumnsCount = 12;

        private byte xs;

        private byte sm;

        private byte md;

        private byte lg;

        public GridSize(byte xs, byte sm, byte md, byte lg)
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
            this.xs = xs;
            this.sm = sm;
            this.md = md;
            this.lg = lg;
        }

        public string ToCssClass()
        {
            return (xs == 0 ? string.Empty : " col-xs-" + xs)
                 + (sm == 0 ? string.Empty : " col-sm-" + sm)
                 + (md == 0 ? string.Empty : " col-md-" + md)
                 + (lg == 0 ? string.Empty : " col-lg-" + lg);
        }

        public string ToOffsetCssClass()
        {
            return (xs == 0 ? string.Empty : " col-xs-offset-" + xs)
                 + (sm == 0 ? string.Empty : " col-sm-offset-" + sm)
                 + (md == 0 ? string.Empty : " col-md-offset-" + md)
                 + (lg == 0 ? string.Empty : " col-lg-offset-" + lg);
        }

        public GridSize Invert()
        {
            return new GridSize(
                (byte)(xs == 0 ? 0 : ColumnsCount - xs),
                (byte)(sm == 0 ? 0 : ColumnsCount - sm),
                (byte)(md == 0 ? 0 : ColumnsCount - md),
                (byte)(lg == 0 ? 0 : ColumnsCount - lg));
        }
    }
}
