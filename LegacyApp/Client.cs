namespace LegacyApp
{
    public class Client : IClient
    {
        public string Name { get; init; }
        public int ClientId { get; init; }
        public string Email { get; init; }
        public string Address { get; init; }
        public string Type { get; init; }
    }
}