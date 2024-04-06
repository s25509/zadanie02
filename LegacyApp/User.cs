using System;

namespace LegacyApp
{
    public class User : IUser
    {
        public object Client { get; init; }
        public DateTime DateOfBirth { get; init; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }
    }
}