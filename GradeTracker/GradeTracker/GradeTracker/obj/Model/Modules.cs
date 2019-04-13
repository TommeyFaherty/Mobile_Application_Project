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
    class Modules
    {
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
    }
}
