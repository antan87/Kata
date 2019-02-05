// Your task in order to complete this Kata is to write a function which formats a duration, given as a number of seconds, in a human-friendly way.

// The function must accept a non-negative integer. If it is zero, it just returns "now". Otherwise, the duration is expressed as a combination of years, days, hours, minutes and seconds.

// It is much easier to understand with an example:

// formatDuration(62)    // returns "1 minute and 2 seconds"
// formatDuration(3662)  // returns "1 hour, 1 minute and 2 seconds"
// For the purpose of this Kata, a year is 365 days and a day is 24 hours.

// Note that spaces are important.

// Detailed rules
// The resulting expression is made of components like 4 seconds, 1 year, etc. In general, a positive integer and one of the valid units of time, separated by a space. The unit of time is used in plural if the integer is greater than 1.

// The components are separated by a comma and a space (", "). Except the last component, which is separated by " and ", just like it would be written in English.

// A more significant units of time will occur before than a least significant one. Therefore, 1 second and 1 year is not correct, but 1 year and 1 second is.

// Different components have different unit of times. So there is not repeated units like in 5 seconds and 1 second.

// A component will not appear at all if its value happens to be zero. Hence, 1 minute and 0 seconds is not valid, but it should be just 1 minute.

// A unit of time must be used "as much as possible". It means that the function should not return 61 seconds, but 1 minute and 1 second instead. Formally, the duration specified by of a component must not be greater than any valid more significant unit of time.
using System.Collections.Generic;
using System.Linq;
using kata;
using NUnit.Framework;
namespace kata {

    public static class Kata6 {

        public static (string durationTxt, int remaningSeconds) GetDurationValue (string txt, int timeDuration, int seconds) {

            int count = 0;
            while (seconds >= timeDuration) {

                seconds -= timeDuration;
                count++;
            }
            string textResult = string.Empty;
            if (count != 0)
                textResult = $"{count} {txt}";

            if (count > 1)
                textResult += "s";

            return (durationTxt: textResult, remaningSeconds: seconds);
        }
        public static string FormatDuration (int seconds) {
            if (seconds == 0)
                return "now";

            List<string> results = new List<string> ();
            Dictionary<string, int> durations = new Dictionary<string, int> { { "year", 31536000 },
                { "day", 86400 },
                { "hour", 3600 },
                { "minute", 60 },
                { "second", 1 }
            };

            foreach (var duration in durations) {
                var value = GetDurationValue (duration.Key, duration.Value, seconds);
                seconds = value.remaningSeconds;

                if (!string.IsNullOrWhiteSpace (value.durationTxt))
                    results.Add (value.durationTxt);
            }

            var lastItem = results.Last ();
            results.Remove (lastItem);

            if (results.Count () > 0) {
                lastItem = $" and {lastItem}";
            }

            return string.Join (", ", results) + lastItem;
        }
    }

    [TestFixture]
    public sealed class Tests6 {

        [TestCase ("1 minute and 2 seconds", 62)]
        [TestCase ("1 hour, 1 minute and 2 seconds", 3662)]
        public void FormatDuration (string result, int seconds) => Assert.AreEqual (result, Kata6.FormatDuration (seconds));
    }
}