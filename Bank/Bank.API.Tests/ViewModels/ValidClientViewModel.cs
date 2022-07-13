using Bank.Models.Client;

namespace Bank.API.Tests.ViewModels
{
    public class ValidClientViewModel
    {
        public static IEnumerable<ClientViewModel> InitListClient = new List<ClientViewModel>
        {
            new() { Id = 1, FirstName = "Vlad", SecondName = "Zagorsky", PhoneNumber = "+375293710904" }
        };

        public static ClientViewModel ClientViewModel =
            new() { Id = 1, FirstName = "Vlad", SecondName = "Zagorsky", PhoneNumber = "+375293710904" };

        public static AddClientViewModel AddClientViewModel = new()
        {
            FirstName = "Dimon",
            SecondName = "Dimoooon",
            PhoneNumber = "+375555555555"
        };

        public static ShortClientViewModel ShortClientViewModel = new()
        {
            FirstName = "Vlad",
            SecondName = "Zagorsky",
            PhoneNumber = "+375555555555"
        };
    }
}