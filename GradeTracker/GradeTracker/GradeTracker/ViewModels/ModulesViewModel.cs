using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace GradeTracker.ViewModels
{
    class ModulesViewModel : BaseViewModel
    {
        #region == Public Properties == 
        public string module { get; set; }
        public double currGrade { get; set; }

        //Exam 
        public int numOfExams { get; set; }
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
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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

        public static void SaveModuleList(ObservableCollection<ModulesViewModel> saveList)
        {

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filename = Path.Combine(path, Utils.Utils.JSON_MODULES_FILE);
            

            using (var writer = new StreamWriter(filename, false))
            {
                /*JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer,saveList);*/
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
                writer.Close();
            }
        }
        #endregion
    }
}
