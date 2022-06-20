using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestFlyoutApp.Views
{
    public partial class ProfilePage1 : ContentPage
    {
        public ProfilePage1()
        {
            InitializeComponent();
        }

        public void NextPage_Clicked(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new ProfilePage1());
        }
    }

}
