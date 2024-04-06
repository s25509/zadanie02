namespace LegacyApp
{
    public interface IClientRepository
    {
        /// <returns>Returning client object</returns>
        IClient GetById(int clientId);
    }
}