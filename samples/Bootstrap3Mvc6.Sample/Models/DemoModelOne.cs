using System;

namespace Bootstrap3Mvc6.Sample.Models
{
    public class DemoModelOne
    {
        public string StringField { get; set; }

        public bool BooleanField { get; set; }

        public int IntegerField { get; set; } = 2;

        public DateTimeOffset DateTimeOffsetField { get; set; } = DateTimeOffset.Now;
    }
}