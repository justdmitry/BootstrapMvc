using System;
using System.ComponentModel.DataAnnotations;

namespace Bootstrap4Mvc6.Sample.Models
{
    public class DemoModelOne
    {
        [Display(Name = "Some string")]
        public string StringField { get; set; }

        [Display(Name = "Some bool")]
        public bool BooleanField { get; set; }

        [Display(Name = "Some int")]
        public int IntegerField { get; set; }

        public DateTimeOffset DateTimeOffsetField { get; set; } = DateTimeOffset.Now;

        public string FieldWithError { get; set; }

        public bool BooleanFieldWithError { get; set; }
    }
}