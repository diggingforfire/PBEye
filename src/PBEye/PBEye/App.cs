using FreshMvvm;
using PBEye.Service;
using PBEye.ViewModels;
using Xamarin.Forms;

namespace PBEye
{
    public class App : Application
    {
        public App()
        {
            RegisterDependencies();
            FreshPageModelResolver.PageModelMapper = new PageModelMapper();
            var view = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();
            MainPage = new FreshNavigationContainer(view);
        }

        private void RegisterDependencies()
        {
            FreshIOC.Container.Register(VsServiceFactory.GetService());
        }
    }
}