using FreshMvvm;
using PropertyChanged;
using Xamarin.Forms;

namespace PBEye.ViewModels
{
    [ImplementPropertyChanged]
    public class LoginViewModel : FreshBasePageModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Command Login
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PushPageModel<WorkItemListViewModel>();
                });
            }
        }
    }
}