using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSSharp_2020
{
    [TestFixture, Parallelizable]
    public class CyclesPerformanceTest
    {
        const int SAMPLE_SIZE = 10000000;
        int[] nums;
        int total;
        Stopwatch watch;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            nums = Enumerable.Range(0, SAMPLE_SIZE).ToArray();
        }

        [SetUp]
        public void SetUp()
        {
            total = 0;
            watch = new Stopwatch();
            watch.Start();
        }

        [TearDown]
        public void TearDown()
        {
            watch.Stop();
            //WriteLine($"Time: {watch.ElapsedTicks:N0}");
            System.GC.Collect();
        }

        [Test, Parallelizable]
        public void Test_Foreach()
        {
            foreach (var num in nums)
            {
                IsPrime(num);
                total += num;
            }
        }

        [Test, Parallelizable]
        public void Test_For()
        {
            for (int i = 0; i < nums.Length; i++)
            {
                IsPrime(nums[i]);
                total += nums[i];
            }
        }

        [Test, Parallelizable]
        public void Test_ForParallel()
        {
            Parallel.For(0, nums.Length, (i) =>
             {
                 IsPrime(nums[i]);
                 Interlocked.Add(ref total, nums[i]);
             });
        }

        [Test, Parallelizable]
        public void Test_ForeachParallel()
        {
            Parallel.ForEach(nums, (num) =>
            {
                IsPrime(num);
                Interlocked.Add(ref total, num);
            });
        }

        bool IsPrime(int candidate)
        {
            //forcing workload
            _IsPrime(candidate);
            _IsPrime(candidate);
            return _IsPrime(candidate);
        }

        static bool _IsPrime(int candidate)
        {
            if ((candidate & 1) == 0)
                return candidate == 2;

            for (int i = 3; (i * i) <= candidate; i += 2)
                if ((candidate % i) == 0)
                    return false;

            return candidate != 1;
        }
    }
}