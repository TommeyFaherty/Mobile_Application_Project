using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GradeTracker.ViewModels
{
    class AddModulePageViewModel : BaseViewModel
    {

        #region== Private Fields ==
        private ObservableCollection<ModulesViewModel> modulesList;
        private ModulesViewModel selectedModule; //data to be bound
        #endregion

        #region == Command Properties ==
        public ICommand SaveListCommand { get; private set; }
        #endregion

        #region== public properties ==
        private readonly IPageService _pageService;
        public AddModulePageViewModel(IPageService pageService)
        {
            _pageService = pageService;          
            SaveListCommand = new Command(SaveList);
        }

        public ObservableCollection<ModulesViewModel> ModulesList
        {
            get { return modulesList; }
            set { SetValue(ref modulesList, value); }
        }

        public ModulesViewModel SelectedModule
        {
            get { return selectedModule; }
            set { SetValue(ref selectedModule, value); }
        }
        #endregion


        #region == Public Events ==
        private void SaveList()
        {
            //ModulesViewModel.SaveModuleList(ModulesList);
        }
        #endregion
    }
}
