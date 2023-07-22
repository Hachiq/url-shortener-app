using Api.Models;

namespace Api.Services.About
{
    public interface IAboutService
    {
        AboutViewModel GetModel();
        void SetModel(AboutViewModel model);
    }
}
