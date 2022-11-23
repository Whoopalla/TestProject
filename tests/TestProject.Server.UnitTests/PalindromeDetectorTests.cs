using TestProject.Server.Core.Services;
using Xunit;

namespace TestProject.Server.UnitTests {
    public class PalindromeDetectorTests {
        private PalindromeDetector GetPalindromeDetector() {
            return new PalindromeDetector();
        }

        [Fact]
        public void InputWithoutPalindrome() {
            var detector = GetPalindromeDetector();
            var input = "aab";

            var result = detector.IsPalindrome(input);
            var expected = false;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void InputWithPalindrome() {
            var detector = GetPalindromeDetector();
            var input = "LoL";

            var result = detector.IsPalindrome(input);
            var expected = true;

            Assert.Equal(expected, result);
        }
    }
}
