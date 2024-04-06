using LegacyApp;

namespace LegacyAppTests;

public class UserCreditServiceTests
{
    [Theory]
    [InlineData("Kowalski")]
    [InlineData("Malewski")]
    [InlineData("Smith")]
    [InlineData("Doe")]
    [InlineData("Kwiatkowski")]
    public void GetCreditLimit_Should_Return_Limit_For_Known_User(string lastName)
    {
        //Arrange
        var service = new UserCreditService();
        
        //Act
        var result = service.GetCreditLimit(lastName);

        //Assert
        Assert.IsType<int>(result);
    }
    
    [Fact]
    public void GetCreditLimit_Should_Throw_Exception_For_Unknown_User()
    {
        //Arrange
        var service = new UserCreditService();

        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = service.GetCreditLimit("Nieznany");
        });
    }
}