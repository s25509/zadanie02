using System;

namespace LegacyApp
{
    public interface IUser
    {
        object Client { get; }
        DateTime DateOfBirth { get; }
        string EmailAddress { get; }
        string FirstName { get; }
        string LastName { get; }
        bool HasCreditLimit { get; }
        int CreditLimit { get; }
    }
}