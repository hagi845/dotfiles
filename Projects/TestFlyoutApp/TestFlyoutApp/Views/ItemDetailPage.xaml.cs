using System.ComponentModel;
using Xamarin.Forms;
using TestFlyoutApp.ViewModels;

namespace TestFlyoutApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
