using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GradeTracker.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Modules> modulesList
        { get; private set; } = new ObservableCollection<Modules>();

  //data to be bound
        private Modules selectedModule;

        //private void OnPropertyChanged method

        #region == Public Events == 
        public MainPageViewModel()
        {
            ReadList();
        }

        public void ReadList()
        {
            modulesList = Modules.ReadModulesListData();
        }


        #endregion
    }
}
