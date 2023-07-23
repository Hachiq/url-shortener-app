using Api.Models;

namespace Api.Services.AboutService
{
    public class AboutService : IAboutService
    {
        public AboutViewModel GetModel()
        {
            return new AboutViewModel
            {
                Description = File.ReadAllText("about.txt")
            };
        }

        public void SetModel(AboutViewModel model)
        {
            File.WriteAllText("about.txt", model.Description);
        }
    }
}
