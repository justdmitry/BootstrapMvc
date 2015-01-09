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

        private byte offset_xs;

        private byte offset_sm;

        private byte offset_md;

        private byte offset_lg;
        
        public GridSize(byte xs, byte sm, byte md, byte lg)
            : this(xs, sm, md, lg, 0, 0, 0, 0)
        {
            // Nothing
        }

        public GridSize(byte xs, byte sm, byte md, byte lg, byte offset_xs, byte offset_sm, byte offset_md, byte offset_lg)
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
            if ((xs + offset_xs) > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("offset_xs");
            }
            if ((sm + offset_sm) > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("offset_sm");
            }
            if ((md + offset_md) > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("offset_md");
            }
            if ((lg + offset_lg) > ColumnsCount)
            {
                throw new ArgumentOutOfRangeException("offset_lg");
            }
            this.xs = xs;
            this.sm = sm;
            this.md = md;
            this.lg = lg;
            this.offset_xs = offset_xs;
            this.offset_sm = offset_sm;
            this.offset_md = offset_md; 
            this.offset_lg = offset_lg;
        }

        public string ToCssClass()
        {
            return (xs == 0 ? string.Empty : " col-xs-" + xs)
                 + (sm == 0 ? string.Empty : " col-sm-" + sm)
                 + (md == 0 ? string.Empty : " col-md-" + md)
                 + (lg == 0 ? string.Empty : " col-lg-" + lg)
                 + (offset_xs == 0 ? string.Empty : " col-offset-xs-" + offset_xs)
                 + (offset_sm == 0 ? string.Empty : " col-offset-sm-" + offset_sm)
                 + (offset_md == 0 ? string.Empty : " col-offset-md-" + offset_md)
                 + (offset_lg == 0 ? string.Empty : " col-offset-lg-" + offset_lg)
                ;
        }

        public GridSize Invert()
        {
            return new GridSize(
                (byte)(xs == 0 ? 0 : ColumnsCount - xs),
                (byte)(sm == 0 ? 0 : ColumnsCount - sm),
                (byte)(md == 0 ? 0 : ColumnsCount - md),
                (byte)(lg == 0 ? 0 : ColumnsCount - lg)
                );
        }

        public GridSize Offset(GridSize value)
        {
            return new GridSize(xs, sm, md, lg, value.xs, value.sm, value.md, value.lg);
        }
    }
}
