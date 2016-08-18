﻿using System;

namespace BootstrapMvc
{
    public struct GridSize
    {
        public static readonly byte ColumnsCount = 12;

        private byte xs;

        private byte sm;

        private byte md;

        private byte lg;

        private byte xl;

        [Obsolete("Use new constructor with 'xl' param")]
        public GridSize(byte xs, byte sm, byte md, byte lg)
            : this(xs, sm, md, lg, lg)
        {
            // Nothing
        }

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
            return ((xs == 0 ? string.Empty : " offset-xs-" + xs)
                 + (sm == 0 ? string.Empty : " offset-sm-" + sm)
                 + (md == 0 ? string.Empty : " offset-md-" + md)
                 + (lg == 0 ? string.Empty : " offset-lg-" + lg)
                 + (xl == 0 ? string.Empty : " offset-xl-" + xl))
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
