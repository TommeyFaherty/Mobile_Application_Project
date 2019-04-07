using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using Utils;

namespace GradeTracker
{
    class Modules : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region == Public Properties == 
        //Module variables
        public string module { get; set; }
        public double currGrade { get; set; }

        //Exam 
        public int numOfExams { get; set; }
        public List<int> examWeight { get; set; } //Toal must equal 100
        public List<double> examPercent { get; set; }
        public double currPercent { get; set; }
        #endregion

        #region == Constructors ==
        public Modules()
        {

        }

        public Modules(string m, int num, List<int> ew, List<double> ep, double curr)
        {
            m = module; numOfExams = num; examWeight = ew;
            examPercent = ep; currPercent = curr;
        }
        #endregion

        #region == Methods ==
        public static ObservableCollection<Modules> ReadModulesListData()
        {
            ObservableCollection<Modules> myModules = new ObservableCollection<Modules>();
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

                Console.WriteLine("here!"); //dsgadsgasdfdfasssssssssssssss

                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("GradeTracker.Data.Modules.txt");

                //assembly.GetType().Assembly.GetManifestResourceNames();

                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    
                }
            }

            myModules = JsonConvert.DeserializeObject<ObservableCollection<Modules>>(jsonText);
            return myModules;
        }
        #endregion

    }
}
