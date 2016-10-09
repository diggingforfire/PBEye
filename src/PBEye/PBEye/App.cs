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

			var navigationContainer = new FreshNavigationContainer(view)
			{
				BarBackgroundColor = Constants.Colors.NavigationBarColor,
				BarTextColor = Constants.Colors.SecondaryAccentColor,
            };

            MainPage = navigationContainer;

        }

		public void SetNavigationBarColor(Color color)
		{
			((FreshNavigationContainer)MainPage).BarBackgroundColor = color;
		}

        private void RegisterDependencies()
        {
            FreshIOC.Container.Register(VsServiceFactory.GetService());
			FreshIOC.Container.Register(this);
        }
    }
}