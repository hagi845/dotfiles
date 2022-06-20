using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TestFlyoutApp.Services;
using TestFlyoutApp.Views;

namespace TestFlyoutApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
