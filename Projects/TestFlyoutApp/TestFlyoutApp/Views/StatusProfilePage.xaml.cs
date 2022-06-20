using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TestFlyoutApp.Views
{
    public partial class StatusProfilePage : ContentPage
    {
        public StatusProfilePage()
        {
            InitializeComponent();

            Title = "ステータス登録";
        }

        public void NextPage_Clicked(object sender, System.EventArgs e) => this.Navigation.PushAsync(new ProfilePage1());
    }
}
