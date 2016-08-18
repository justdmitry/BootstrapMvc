using System;

namespace Bootstrap4Mvc6.Sample.Models
{
    public class DemoModelOne
    {
        public string StringField { get; set; }

        public bool BooleanField { get; set; }

        public int IntegerField { get; set; }

        public DateTimeOffset DateTimeOffsetField { get; set; } = DateTimeOffset.Now;

        public string FieldWithError { get; set; }

        public bool BooleanFieldWithError { get; set; }
    }
}