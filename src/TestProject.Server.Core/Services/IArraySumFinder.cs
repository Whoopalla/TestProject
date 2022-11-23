namespace TestProject.Server.Core.Services {
    public interface IArraySumFinder {
        long GetSum(IEnumerable<long> numbers);
    }
}
