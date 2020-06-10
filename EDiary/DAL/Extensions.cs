using System;

namespace Common
{
    public static class Extensions
    {
        public class EnumStringAttribute : Attribute
        {
            public EnumStringAttribute(string stringValue)
            {
                this.StringValue = stringValue;
            }

            public string StringValue { get; set; }
        }
    }
}
