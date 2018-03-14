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

#if BOOTSTRAP4
        private byte xl;
#endif

#if BOOTSTRAP4
        [Obsolete("Use new constructor with 'xl' param")]
        public GridSize(byte xs, byte sm, byte md, byte lg)
            : this(xs, sm, md, lg, lg)
        {
            // Nothing
        }
#endif

#if BOOTSTRAP4
        public GridSize(byte xs, byte sm, byte md, byte lg, byte xl)
#else
        public GridSize(byte xs, byte sm, byte md, byte lg)
#endif
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

            this.xs = xs;
            this.sm = sm;
            this.md = md;
            this.lg = lg;

#if BOOTSTRAP4
            if (xl > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException(nameof(xl));
            }

            this.xl = xl;
#endif
        }

        public string ToCssClass()
        {
            return ((xs == 0 ? string.Empty : " col-xs-" + xs)
                 + (sm == 0 ? string.Empty : " col-sm-" + sm)
                 + (md == 0 ? string.Empty : " col-md-" + md)
                 + (lg == 0 ? string.Empty : " col-lg-" + lg)
#if BOOTSTRAP4
                 + (xl == 0 ? string.Empty : " col-xl-" + xl)
#endif
                 ).Trim();
        }

        public string ToOffsetCssClass()
        {
            return (" offset-xs-" + xs
                 + " offset-sm-" + sm
                 + " offset-md-" + md
                 + " offset-lg-" + lg
#if BOOTSTRAP4
                 + " offset-xl-" + xl
#endif
                 ).Trim();
        }

        public GridSize Invert()
        {
            return new GridSize(
                (byte)(xs == 0 ? 0 : ColumnsCount - xs),
                (byte)(sm == 0 ? 0 : ColumnsCount - sm),
                (byte)(md == 0 ? 0 : ColumnsCount - md),
                (byte)(lg == 0 ? 0 : ColumnsCount - lg)
#if BOOTSTRAP4
                ,
                (byte)(xl == 0 ? 0 : ColumnsCount - xl)
#endif
                );
        }

        public bool IsEmpty()
        {
            return xs == 0 && sm == 0 && md == 0 && lg == 0
#if BOOTSTRAP4
                && xl == 0
#endif
                ;
        }
    }
}
