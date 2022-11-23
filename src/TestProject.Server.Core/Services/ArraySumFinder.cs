namespace TestProject.Server.Core.Services {
    public class ArraySumFinder : IArraySumFinder {
        public long GetSum(IEnumerable<long> numbers) {
            var oddNumbers = numbers.Where(number => number % 2 != 0).ToArray();
            long result = 0;

            try {
                for (int i = 0; i < oddNumbers.Length; i++) {
                    if (i > 0 && i % 2 != 0) {
                        checked {
                            result += oddNumbers[i];
                        }
                    }
                }
            }
            catch (OverflowException e) {
                throw;
            }

            return result;
        }
    }
}
