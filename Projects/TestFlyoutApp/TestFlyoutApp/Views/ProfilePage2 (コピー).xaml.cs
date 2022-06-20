using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestFlyoutApp.Views
{
    public partial class ProfilePage2 : ContentPage
    {
        public ProfilePage2()
        {
            InitializeComponent();
        }

        public void NextPage_Clicked(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new ProfilePage1());
        }
    }

}
