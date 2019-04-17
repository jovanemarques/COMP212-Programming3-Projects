using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalRestuarentMobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NavigationPageView : ContentPage
	{
		public NavigationPageView ()
		{
			InitializeComponent ();
		}

        private async void HomePageButton_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new Helpers.HomePageView());
        }

        private void LocalRestaurantOverviewButton_Clicked(object sender, EventArgs e)
        {
          //  await this.Navigation.PushAsync(new Helpers.LocalOverviewPage());
        }

        private async void ContactUsButton_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new Helpers.ContactusView());
        }
    }
}