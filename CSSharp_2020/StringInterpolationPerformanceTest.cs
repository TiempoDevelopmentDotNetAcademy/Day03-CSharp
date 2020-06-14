using NUnit.Framework;
using System.Diagnostics;
using System.Text;

namespace CSSharp_2020
{
    [TestFixture, Parallelizable]
    public class StringInterpolationPerformanceTest
    {
        Stopwatch stopWatch;
        int length = 10000;
        string concatString;

        [SetUp]
        public void SetUp()
        {
            stopWatch = new Stopwatch();
            concatString = string.Empty;
            stopWatch.Start();
        }

        [TearDown]
        public void TearDown()
        {
            stopWatch.Stop();
        }

        [Test, Parallelizable]
        public void string_concat_performance()
        {
            for (int i = 0; i < length; i++)
            {
                concatString += "a";
            }
        }

        [Test, Parallelizable]
        public void string_interpolation_performance()
        {
            for (int i = 0; i < length; i++)
            {
                concatString = $"{concatString}a";
            }
        }

        [Test, Parallelizable]
        public void string_builder_performance()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append("a");
            }
            stringBuilder.ToString();
        }
    }
}