namespace BootstrapMvc
{
    using System;

    public struct GridSize
    {
        public static readonly byte ColumnsCount = 12;

        public static readonly byte Auto = 255;

        private readonly byte xs;

        private readonly byte sm;

        private readonly byte md;

        private readonly byte lg;

        private readonly byte xl;

        public GridSize(byte size)
            : this(size, size, size, size, size)
        {
            // Nothing
        }

        [Obsolete("Use new constructor with 'xl' param")]
        public GridSize(byte xs, byte sm, byte md, byte lg)
            : this(xs, sm, md, lg, lg)
        {
            // Nothing
        }

        public GridSize(byte xs, byte sm, byte md, byte lg, byte xl)
        {
            if (xs > ColumnsCount && xs != Auto)
            {
                throw new ArgumentOutOfRangeException(nameof(xs));
            }

            if (sm > ColumnsCount && sm != Auto)
            {
                throw new ArgumentOutOfRangeException(nameof(sm));
            }

            if (md > ColumnsCount && md != Auto)
            {
                throw new ArgumentOutOfRangeException(nameof(md));
            }

            if (lg > ColumnsCount && lg != Auto)
            {
                throw new ArgumentOutOfRangeException(nameof(lg));
            }

            if (xl > ColumnsCount && xl != Auto)
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
            if (IsEmpty())
            {
                return string.Empty;
            }

            if (xs == sm && sm == md && md == lg && lg == xl)
            {
                return xs == Auto ? string.Empty : "col-" + xs;
            }

            var clss = (xs == Auto ? " col-xs-auto" : (xs == 0 ? string.Empty : " col-xs-" + xs))
                     + (sm == Auto ? " col-sm-auto" : (sm == 0 ? string.Empty : " col-sm-" + sm))
                     + (md == Auto ? " col-md-auto" : (md == 0 ? string.Empty : " col-md-" + md))
                     + (lg == Auto ? " col-lg-auto" : (lg == 0 ? string.Empty : " col-lg-" + lg))
                     + (xl == Auto ? " col-xl-auto" : (xl == 0 ? string.Empty : " col-xl-" + xl))
                     ;

            return clss.Trim();
        }

        public string ToOffsetCssClass()
        {
            if (IsEmpty())
            {
                return string.Empty;
            }

            var clss = (xs == Auto ? string.Empty : " offset-xs-" + xs)
                     + (sm == Auto ? string.Empty : " offset-sm-" + sm)
                     + (md == Auto ? string.Empty : " offset-md-" + md)
                     + (lg == Auto ? string.Empty : " offset-lg-" + lg)
                     + (xl == Auto ? string.Empty : " offset-xl-" + xl)
                     ;

            return clss.Trim();
        }

//        public GridSize Invert()
//        {
//            return new GridSize(
//                (byte)(xs == 0 ? 0 : ColumnsCount - xs),
//                (byte)(sm == 0 ? 0 : ColumnsCount - sm),
//                (byte)(md == 0 ? 0 : ColumnsCount - md),
//                (byte)(lg == 0 ? 0 : ColumnsCount - lg)
//#if BOOTSTRAP4
//                ,
//                (byte)(xl == 0 ? 0 : ColumnsCount - xl)
//#endif
//                );
//        }

        public bool IsEmpty()
        {
            return xs == 0 && sm == 0 && md == 0 && lg == 0 && xl == 0;
        }
    }
}
