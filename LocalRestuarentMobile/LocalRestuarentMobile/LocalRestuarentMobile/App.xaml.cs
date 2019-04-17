using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LocalRestuarentMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new ContentPageView();
            //MainPage = new NavigationPage(new NavigationPageView());
            //MainPage = new TabbedPageView();
            // MainPage = new MasterDetailPageView();
            //MainPage = new CarousalPageView();
            MainPage = new StackLayoutPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
