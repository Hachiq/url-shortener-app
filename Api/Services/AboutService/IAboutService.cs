using Api.Models;

namespace Api.Services.AboutService
{
    public interface IAboutService
    {
        AboutViewModel GetModel();
        void SetModel(AboutViewModel model);
    }
}
