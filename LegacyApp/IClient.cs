namespace LegacyApp
{
    public interface IClient
    {
        string Name { get; }
        int ClientId { get; }
        string Email { get; }
        string Address { get; }
        string Type { get; }
    }
}