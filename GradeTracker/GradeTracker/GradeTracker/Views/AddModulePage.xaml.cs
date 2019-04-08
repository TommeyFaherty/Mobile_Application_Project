using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GradeTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddModulePage : ContentPage
    {
        public AddModulePage()
        {
            InitializeComponent();
        }

        private void MainPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}