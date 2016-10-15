using FreshMvvm;
using PBEye.Service;
using PBEye.ViewModels;
using Xamarin.Forms;

namespace PBEye
{
    public class App : Application, INavigationManager
    {
	    private readonly FreshNavigationContainer _navigationContainer;

        public App()
        {
            RegisterDependencies();
            FreshPageModelResolver.PageModelMapper = new PageModelMapper();
            var view = FreshPageModelResolver.ResolvePageModel<LoginViewModel>();

			_navigationContainer = new FreshNavigationContainer(view)
			{
				BarBackgroundColor = Constants.Colors.NavigationBarColor,
				BarTextColor = Color.White,
            };

            MainPage = _navigationContainer;
        }

		public void SetNavigationBarColor(Color color)
		{
			_navigationContainer.BarBackgroundColor = color;
		}

        private void RegisterDependencies()
        {
            FreshIOC.Container.Register(VsServiceFactory.GetService());
	        FreshIOC.Container.Register<INavigationManager>(this);
        }
    }
}