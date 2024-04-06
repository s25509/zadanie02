using System;

namespace LegacyApp
{
    public class UserService : IUserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!ValidateUserData(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            SetCreditLimit(client, user);
            
            if (!ValidateUserCredit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private static bool ValidateUserData(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains('@') && !email.Contains('.'))
            {
                return false;
            }

            var age = CalculateAge(dateOfBirth);
            return age >= Constants.RegistrationSettings.LegalAge;
        }

        private static bool ValidateUserCredit(User user)
        {
            return !user.HasCreditLimit || user.CreditLimit >= Constants.RegistrationSettings.MinimumCredit;
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
                age--;
            return age;
        }

        private static void SetCreditLimit(IClient client, User user)
        {
            var userCreditService = new UserCreditService();
            
            if (client.Type == Constants.CreditTypes.VeryImportantClient)
            {
                user.HasCreditLimit = false;
            }
            else
            {
                user.HasCreditLimit = true;
                var creditLimit = userCreditService.GetCreditLimit(user.LastName);
                if (client.Type == Constants.CreditTypes.ImportantClient)
                {
                    creditLimit *= Constants.RegistrationSettings.ImportantClientCreditMultiplier;
                }

                user.CreditLimit = creditLimit;
            }
        }
    }
}