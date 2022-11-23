namespace TestProject.Server.Core.Services {
    public class PalindromeDetector : IPalindromeDetector {
        public bool IsPalindrome(string input) {
            var leftIndex = 0;
            var rigthIndex = input.Length - 1;

            while (leftIndex < rigthIndex) {
                if (Char.IsLetterOrDigit(input[leftIndex]) == false) {
                    leftIndex++;
                    continue;
                }

                if (Char.IsLetterOrDigit(input[rigthIndex]) == false) {
                    rigthIndex--;
                    continue;
                }

                if (Char.ToLower(input[leftIndex]) != Char.ToLower(input[rigthIndex])) {
                    return false;
                }

                leftIndex++;
                rigthIndex--;
            }

            return true;
        }
    }
}
