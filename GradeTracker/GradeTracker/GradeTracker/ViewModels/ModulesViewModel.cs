using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace GradeTracker.ViewModels
{
    public class ModulesViewModel : BaseViewModel
    {
        #region == Public Properties == 
        private string _module;
        public string module
        {
            get { return _module; }
            set { SetValue(ref _module, value); }
        }
        public int numOfExams { get; set; }
        public List<string> examNames { get; set; }
        public List<int> examWeight { get; set; } //Toal must equal 100
        public List<double> examPercent { get; set; }
        public double currPercent { get; set; }
        #endregion

        #region == Methods ==
        public static ObservableCollection<ModulesViewModel> ReadModulesListData()
        {
            ObservableCollection<ModulesViewModel> myModules = new ObservableCollection<ModulesViewModel>();
            string jsonText;

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, Utils.Utils.JSON_MODULES_FILE);

                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                }
            }
            catch
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;

                Stream stream = assembly.GetManifestResourceStream("GradeTracker.Data.theModules.txt");
                
                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                }
            }

            myModules = JsonConvert.DeserializeObject<ObservableCollection<ModulesViewModel>>(jsonText);
            return myModules;
        }

        public static void AddNewModule(Modules newModule,ObservableCollection<ModulesViewModel> currentModules)
        {        
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, Utils.Utils.JSON_MODULES_FILE);

            //Get Current Modules and newModule as a string
            string jsonTextCurrent = JsonConvert.SerializeObject(currentModules);
            string jsonTextNew = JsonConvert.SerializeObject(newModule);

            //Remove empty string files
            jsonTextNew = jsonTextNew.Remove((jsonTextNew.Length - 73));
            jsonTextNew += "}";

            //Take out the closing bracket "]"
            jsonTextCurrent = jsonTextCurrent.Remove(jsonTextCurrent.Length - 1);
            jsonTextCurrent = jsonTextCurrent + ", " + jsonTextNew + "]";

            using (var writer = new StreamWriter(filename, false))
            {                
                writer.WriteLine(jsonTextCurrent);
            }
        }

        public static void SetData(Modules newModule)
        {
            Debug.WriteLine("Check here: "+newModule.examNamesString+"|| "+newModule.examWeightString+"|| "+newModule.examPercentString);

            //Fill Lists with respective data
            newModule.examNames = Modules.SetNamesList(newModule.examNamesString, newModule.examNames);
            newModule.examWeight = Modules.SetWeightList(newModule.examWeightString, newModule.examWeight);
            newModule.examPercent = Modules.SetPercentList(newModule.examPercentString, newModule.examPercent);

            //Calculate Current Percentage
            newModule.currPercent = Modules.CalculatePercentage(newModule.numOfExams, newModule.examWeight, newModule.examPercent);
        }

        public static bool CheckEntryValidity(Modules newModule, bool valid)
        {
            //Check that all List data has number of items equal to NumOfExams 
            if (newModule.examNames.Count != newModule.numOfExams)
            {
                valid = false;
            }

            if (newModule.examWeight.Count != newModule.numOfExams)
            {
                valid = false;
            }

            if (newModule.examPercent.Count != newModule.numOfExams)
            {
                valid = false;
            }

            newModule.examNamesString = null;
            newModule.examWeightString = null;
            newModule.examPercentString = null;

            return valid;
        }
        #endregion
    }
}
