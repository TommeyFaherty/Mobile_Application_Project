using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using GradeTracker;
using Newtonsoft.Json;

namespace Utils
{
    class Utils
    {
        public const string JSON_MODULES_FILE = "Modules.txt";

        public static List<Modules> ReadModulesListData()
        {
            List<Modules> myModules = new List<Modules>();
            string jsonText;

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string filename = Path.Combine(path, JSON_MODULES_FILE);

                Console.WriteLine("here!");//sssssssssssssssssssssss

                using (var reader = new StreamReader(filename))
                {
                    jsonText = reader.ReadToEnd();
                    myModules = JsonConvert.DeserializeObject<List<Modules>>(jsonText);
                }
            }
            catch
            {

                Console.WriteLine("here!"); //dsgadsgasdfdfasssssssssssssss

                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("GradeTracker.Modules.txt");

                assembly.GetType().Assembly.GetManifestResourceNames(); //sssssssssssssssssssssss
                

                using (var reader = new StreamReader(stream))
                {
                    jsonText = reader.ReadToEnd();
                    myModules = JsonConvert.DeserializeObject<List<Modules>>(jsonText);
                }
            }
            return myModules;
        }


        public static void saveModulesListData(List<Modules> saveList)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string filename = Path.Combine(path, JSON_MODULES_FILE);

            using (var writer = new StreamWriter(filename, false))
            {
                string jsonText = JsonConvert.SerializeObject(saveList);
                writer.WriteLine(jsonText);
            }
        }
    }
}
