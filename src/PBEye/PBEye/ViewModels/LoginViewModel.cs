using System;
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
	    public bool IsBusy { get; set; }
	    public bool LoginFailed { get; set; }
	    public double BusyOpacity => IsBusy ? 1 : 0;

	    public bool CanLogin => 
			!IsBusy && 
			!string.IsNullOrEmpty(Organization) && 
			!string.IsNullOrEmpty(Username) &&
			!string.IsNullOrEmpty(Password);

	    public Command Login
        {
            get
            {
                return new Command(async () =>
                {
	                try
	                {
						LoginFailed = false;

						IsBusy = true;

						await _vsService.Login(Organization, Username, Password);

						await CoreMethods.PushPageModel<WorkItemListViewModel>();

						CoreMethods.RemoveFromNavigation();
					}
	                catch (Exception ex)
	                {
						// TODO: logging
		                LoginFailed = true;
	                }
	                finally
	                {
						IsBusy = false;
					}
                });
            }
        }
    }
}