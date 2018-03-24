using System;
using System.ComponentModel.DataAnnotations;

namespace Bootstrap4Mvc6.Sample.Models
{
    public class DemoModelOne
    {
        [Display(Name = "Some string")]
        public string StringField { get; set; } = "String value";

        [Display(Name = "Some bool")]
        public bool BooleanField { get; set; } = true;

        [Display(Name = "Some int")]
        public int IntegerField { get; set; } = 42;

        public DateTimeOffset DateTimeOffsetField { get; set; } = DateTimeOffset.Now;

        public string FieldWithError { get; set; } = "Invalid value";

        public bool BooleanFieldWithError { get; set; }
    }
}