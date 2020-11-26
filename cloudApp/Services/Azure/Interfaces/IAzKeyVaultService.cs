namespace cloudApp.Services.Azure.Interfaces
{
    public interface IAzKeyVaultService
    {
        string GetSecret(string name);
    }
}
