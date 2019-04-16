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
            this.BindingContext = new MainPageViewModel(new PageService());
        }

        private void AddModulePage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddModulePage());
        }

        private void DeleteItem_Clicked(object sender, EventArgs e)
        {
            ModulesViewModel module = (sender as MenuItem).CommandParameter as ModulesViewModel;
            (BindingContext as MainPageViewModel).DeleteFromListCommand.Execute(module);
        }

        private async void ListViewModuleSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await (BindingContext as MainPageViewModel).SelectOneModule(e.SelectedItem as ModulesViewModel);
        }

    }
}
