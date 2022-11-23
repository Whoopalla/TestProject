using TestProject.Server.Core.Services;
using Xunit;

namespace TestProject.Server.UnitTests {
    public class ArraySumFinderTests {

        private ArraySumFinder GetArraySumFinder() {
            return new ArraySumFinder();
        }

        [Fact]
        public void WithRigthInput() {
            var arraySumFinder = GetArraySumFinder();
            var input = new long[] { 1, 3, 1, 3 };

            var result = arraySumFinder.GetSum(input);
            var expected = 6;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void WithRightInput() {
            var arraySumFinder = GetArraySumFinder();
            var input = new long[] { };

            var result = arraySumFinder.GetSum(input);
            var expected = 0;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void OwerflowExepthion() {
            var arraySumFinder = GetArraySumFinder();
            var input = new long[] { 1, long.MaxValue, 1, 1 };
            Assert.Throws<OverflowException>(() => arraySumFinder.GetSum(input));
        }

    }
}
