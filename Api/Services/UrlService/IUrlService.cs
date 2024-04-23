namespace Api.Services.UrlService
{
    public interface IUrlService
    {
        Task<string> GenerateUniqueCode();
    }
}
