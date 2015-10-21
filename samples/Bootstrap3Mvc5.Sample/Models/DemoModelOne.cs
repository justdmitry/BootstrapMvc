using System;

namespace Bootstrap3Mvc5.Sample.Models
{
    public class DemoModelOne
    {
        public string StringField { get; set; }

        public bool BooleanField { get; set; }

        public int IntegerField { get; set; }

        public DateTimeOffset DateTimeOffsetField { get; set; }

        public string FieldWithError { get; set; }
    }
}