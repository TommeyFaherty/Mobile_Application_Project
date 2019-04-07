using GradeTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GradeTracker
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        private void AddModulePage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddModulePage());
        }
    }
}
