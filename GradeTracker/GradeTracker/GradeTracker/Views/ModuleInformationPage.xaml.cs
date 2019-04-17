using GradeTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GradeTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModuleInformationPage : ContentPage
	{
		public ModuleInformationPage ()
		{
			InitializeComponent ();
		}

        ModulesViewModel _module;

        public ModuleInformationPage (ModulesViewModel module)
        {
            InitializeComponent();
            _module = module;
            this.Title = _module.module;
            this.BindingContext = _module; //Binds SelectedModule data to this page

            //Set temp lists for ListView
            List<string> tempNames = _module.examNames;
            List<int> tempWeight = _module.examWeight;
            List<double> tempPercent = _module.examPercent;

            examsNames.ItemsSource = tempNames;
            examsWeight.ItemsSource = tempWeight;
            examsPercent.ItemsSource = tempPercent;

            NotifyIfWeightNot100(tempWeight);
        }

        public void NotifyIfWeightNot100(List<int> weight)
        {
            int total = 0;
            string message = "";

            total = weight.Sum();

            if (total < 100)
            {
                message = (100-total)+"% is not accounted for in this module as it was not entered when inputing the module";
                warningMsg.BindingContext = message;
            }
            if(total > 100)
            {
                message = "You have "+(total - 100) + "% extra input for this module";
                warningMsg.BindingContext = message;
            }
            else
                return;           
        }

        private void MainPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}