using System;

namespace Phlogopite
{
    internal static class FormattingHelpers
    {
        internal static int EstimateCapacity(string text, ReadOnlySpan<NamedProperty> userProperties,
            ReadOnlySpan<NamedProperty> attachedProperties)
        {
            const int levelLength = 1; // “I”
            const int timeLength = 13; // “ 21:46:30.992”
            const int tagDelimitersLength = 4; // “ [Program.Main]”
            int textLength = 1 + (text?.Length).GetValueOrDefault(); // “ Hello, world!”
            int userPropertiesDelimitersLength = 4 * userProperties.Length; // “, name: value”
            int capacity = levelLength + timeLength + tagDelimitersLength + textLength + userPropertiesDelimitersLength;
            for (int i = 0; i != attachedProperties.Length; ++i)
                capacity += (attachedProperties[i].AsString?.Length).GetValueOrDefault();

            for (int i = 0; i != userProperties.Length; ++i)
            {
                capacity += (userProperties[i].Name?.Length).GetValueOrDefault() +
                    (userProperties[i].AsString?.Length ?? 16);
            }

            return capacity;
        }
    }
}
