using TestProject.Server.Core.Services;

namespace TestProject.Server.Web {
    public static class CustomServicesRegistration {
        public static void RegisterServices(IServiceCollection servicesCollection) {
            servicesCollection.AddSingleton<IArraySumFinder, ArraySumFinder>();
            servicesCollection.AddSingleton<ILinkedListAddingService, TwoLinkedListsAddingService>();
            servicesCollection.AddSingleton<IPalindromeDetector, PalindromeDetector>();
        }
    }
}