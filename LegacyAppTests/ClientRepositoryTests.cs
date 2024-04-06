using LegacyApp;

namespace LegacyAppTests;

public class ClientRepositoryTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    public void GetById_Should_Return_A_Client_Object_For_Existing_Ids(int id)
    {
        //Arrange
        var repository = new ClientRepository();
        
        //Act
        var result = repository.GetById(id);

        //Assert
        Assert.IsType<Client>(result);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    [InlineData(123)]
    [InlineData(666)]
    public void GetById_Should_Throw_Exception_For_Non_Existing_Ids(int id)
    {
        //Arrange
        var repository = new ClientRepository();

        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = repository.GetById(id);
        });
    }
}