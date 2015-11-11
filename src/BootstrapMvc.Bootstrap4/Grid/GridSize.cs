namespace BootstrapMvc
{
    using System;

    public struct GridSize
    {
        public static readonly byte ColumnsCount = 12;

        private byte xs;

        private byte sm;

        private byte md;

        private byte lg;

        private byte xl;

        public GridSize(byte xs, byte sm, byte md, byte lg, byte xl)
        {
            if (xs > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(xs));
            }
            if (sm > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(sm));
            }
            if (md > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(md));
            }
            if (lg > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(lg));
            }
            if (xl > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(xl));
            }
            this.xs = xs;
            this.sm = sm;
            this.md = md;
            this.lg = lg;
            this.xl = xl;
        }

        public string ToCssClass()
        {
            return ((xs == 0 ? string.Empty : " col-xs-" + xs)
                 + (sm == 0 ? string.Empty : " col-sm-" + sm)
                 + (md == 0 ? string.Empty : " col-md-" + md)
                 + (lg == 0 ? string.Empty : " col-lg-" + lg)
                 + (xl == 0 ? string.Empty : " col-xl-" + xl))
                 .Trim();
        }

        public string ToOffsetCssClass()
        {
            return ((" col-xs-offset-" + xs)
                 + (" col-sm-offset-" + sm)
                 + (" col-md-offset-" + md)
                 + (" col-lg-offset-" + lg)
                 + (" col-xl-offset-" + lg))
                 .Trim();
        }

        public string ToPushCssClass()
        {
            return ((" col-xs-push-" + xs)
                 + (" col-sm-push-" + sm)
                 + (" col-md-push-" + md)
                 + (" col-lg-push-" + lg)
                 + (" col-xl-push-" + lg))
                 .Trim();
        }

        public string ToPullCssClass()
        {
            return ((" col-xs-pull-" + xs)
                 + (" col-sm-pull-" + sm)
                 + (" col-md-pull-" + md)
                 + (" col-lg-pull-" + lg)
                 + (" col-xl-pull-" + lg))
                 .Trim();
        }

        public GridSize Invert()
        {
            return new GridSize(
                (byte)(xs == 0 ? 0 : ColumnsCount - xs),
                (byte)(sm == 0 ? 0 : ColumnsCount - sm),
                (byte)(md == 0 ? 0 : ColumnsCount - md),
                (byte)(lg == 0 ? 0 : ColumnsCount - lg),
                (byte)(xl == 0 ? 0 : ColumnsCount - xl));
        }

        public bool IsEmpty()
        {
            return xs == 0 && sm == 0 && md == 0 && lg == 0 && xl == 0;
        }
    }
}
