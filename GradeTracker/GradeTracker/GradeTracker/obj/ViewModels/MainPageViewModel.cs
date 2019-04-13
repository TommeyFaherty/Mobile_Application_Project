using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GradeTracker.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region== Private Fields ==
        private ObservableCollection<ModulesViewModel> modulesList;
        private ModulesViewModel selectedModule; //data to be bound
        #endregion

        #region== public properties ==
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

        //private void OnPropertyChanged method

        #region == Public Events == 
        public MainPageViewModel()
        {
            ReadList();
        }

        public void ReadList()
        {
            ModulesList = ModulesViewModel.ReadModulesListData();
        }


        #endregion
    }
}
