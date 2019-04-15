using GradeTracker.ViewModels;
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
    public class Modules 
    {
        #region == Public Properties == 
        //Module variables
        public string module { get; set; }
        public int numOfExams { get; set; }
        public List<string> examNames { get; set; }
        public List<int> examWeight { get; set; } //Toal must equal 100
        public List<double> examPercent { get; set; }
        public double currPercent { get; set; }

        //List values
        public string examNamesString { get; set; }
        public string examWeightString { get; set; }
        public string examPercentString { get; set; }
        #endregion

        #region == Constructors ==
        public Modules()
        {
            SetLists();
        }

        public Modules(string m, int num,List<string> en, List<int> ew, List<double> ep)
        {
            module = m; numOfExams = num; examWeight = ew;
            examNames = en; examPercent = ep; currPercent = CalculatePercentage(num,ew,ep);
        }
        #endregion

        public static double CalculatePercentage(int exams,List<int> weight,List<double> percent)
        {
            double currPercent = 0;
            //Get overall percentage from weight and percentages
            for (int i = 0; i <= exams; i++)
            {
                int tempWeight = 0;
                tempWeight = weight[i] / 100;
                currPercent += (double)tempWeight * percent[i];
            }   

            return currPercent;
        }

        public static void SetLists(string en, string ew, string ep)
        {

        }
    }
}
