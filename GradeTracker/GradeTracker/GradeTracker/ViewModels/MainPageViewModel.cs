using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GradeTracker.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region == Command Properties ==
        // ICommand is an interface with two methods
        // can execute and execute
        public ICommand ReadListCommand { get; private set; }
        public ICommand DeleteFromListCommand { get; private set; }
        #endregion

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

        public string msg = "";
        #endregion

        #region == Public Events == 

        private readonly IPageService _pageService;
        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ReadList();
            ReadListCommand = new Command(ReadList);
            DeleteFromListCommand = new Command<ModulesViewModel>(DeleteFromList);
        }

        public void ReadList()
        {
            ModulesList = ModulesViewModel.ReadModulesListData();
        }

        public void DeleteFromList(ModulesViewModel m)
        {
            ModulesList.Remove(m);
            SelectedModule = null;
            ModulesViewModel.SaveListData(ModulesList);
        }

        public async Task SelectOneModule(ModulesViewModel module)
        {
            if (modulesList == null)
                return;

            await _pageService.PushAsnyc(new ModuleInformationPage(module));
        }
        #endregion
    }
}
