using FreshMvvm;
using PBEye.Service;
using PropertyChanged;
using Xamarin.Forms;

namespace PBEye.ViewModels
{
    [ImplementPropertyChanged]
    public class LoginViewModel : FreshBasePageModel
    {
	    private readonly IVsService _vsService;

		public LoginViewModel(IVsService vsService)
		{
			_vsService = vsService;
		}

	    public string Organization { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Command Login
        {
            get
            {
                return new Command(async () =>
                {
					_vsService.Login(Organization, Username, Password);

                    await CoreMethods.PushPageModel<WorkItemListViewModel>();
                    CoreMethods.RemoveFromNavigation();
                });
            }
        }
    }
}