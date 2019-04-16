using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GradeTracker.ViewModels
{
    public class AddModulePageViewModel : BaseViewModel
    {

        #region== Private Fields ==
        private ObservableCollection<ModulesViewModel> modulesList;
        private Modules newModule = new Modules();
        private string errorMsg = null;
        #endregion

        #region == Command Properties ==
        public ICommand SaveListCommand { get; private set; }
        #endregion

        #region== public properties ==
        private readonly IPageService _pageService;
        public AddModulePageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ModulesList = ModulesViewModel.ReadModulesListData();
            SaveListCommand = new Command(AddModule);
            //Debug.WriteLine(this.SelectedModule.module);
        }

        public ObservableCollection<ModulesViewModel> ModulesList
        {
            get { return modulesList; }
            set { SetValue(ref modulesList, value); }
        }

        public Modules NewModule
        {
            get { return newModule; }
            set { SetValue(ref newModule, value); }
        }

        public string ErrorMsg
        {
            get { return errorMsg; }
            set { SetValue(ref errorMsg, value); }
        }
        #endregion


        #region == Public Events ==
        private void AddModule()
        {
            bool validEntry = true;
            ModulesViewModel.SetData(newModule);
            validEntry = ModulesViewModel.CheckEntryValidity(newModule, validEntry);

            //if still valid method continues and new Module is saved
            if (validEntry == false)
            {
                ErrorMsg = ErrorMessage();
                return;
            }

            ModulesViewModel.AddNewModule(NewModule, ModulesList);
        }

        public string ErrorMessage()
        {
            string msg = "";
            return msg = "Number of exams is not consistent with Names, Weight and percent";
        }
        #endregion
    }
}
