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

                //assembly.GetType().Assembly.GetManifestResourceNames();
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

            //Take out the closing bracket "]"
             jsonTextCurrent = jsonTextCurrent.Remove(jsonTextCurrent.Length - 1);
             jsonTextCurrent = jsonTextCurrent + ", " + jsonTextNew + "]";

             Debug.WriteLine(newModule.module);

             using (var writer = new StreamWriter(filename, false))
             {                
                 writer.WriteLine(jsonTextCurrent);
             }

           /* Debug.WriteLine(jsonTextNew);

            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(filename))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, newModule);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }*/
        }
        #endregion
    }
}
