using System;
using System.Collections.Generic;
using System.Linq;

namespace BootstrapMvc.Core
{
    public abstract class Element : WritableBlock
    {
        private IList<string> additionalClasses;

        private IDictionary<string, string> additionalAttributes;

        public Element(IBootstrapContext context)
            : base(context)
        {
            // Nothing
        }

        public void AddCssClass(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }
            if (additionalClasses == null)
            {
                additionalClasses = new List<string>();
            }
            if (!additionalClasses.Contains(value, StringComparer.OrdinalIgnoreCase))
            {
                additionalClasses.Add(value);
            }
        }

        public void MergeAttribute(string key, string value)
        {
            if (additionalAttributes == null)
            {
                additionalAttributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            }
            additionalAttributes[key] = value;
        }

        protected void ApplyCss(ITagBuilder tag)
        {
            if (additionalClasses == null)
            {
                return;
            }
            foreach (var value in additionalClasses)
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tag.AddCssClass(value);
                }
            }
        }

        protected void ApplyAttributes(ITagBuilder tag)
        {
            if (additionalAttributes == null)
            {
                return;
            }
            foreach (var attr in additionalAttributes)
            {
                if (!string.IsNullOrWhiteSpace(attr.Value))
                {
                    tag.MergeAttribute(attr.Key, attr.Value);
                }
            }
        }
    }
}
