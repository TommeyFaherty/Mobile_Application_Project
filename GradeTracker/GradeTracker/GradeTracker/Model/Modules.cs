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
    class Modules 
    {
        #region == Public Properties == 
        //Module variables
        public string module { get; set; }
        public double currGrade { get; set; }

        //Exam 
        public int numOfExams { get; set; }
        public List<string> examNames { get; set; }
        public List<int> examWeight { get; set; } //Toal must equal 100
        public List<double> examPercent { get; set; }
        public double currPercent { get; set; }
        #endregion

        #region == Constructors ==
        public Modules()
        {

        }

        public Modules(string m, int num,List<string> en, List<int> ew, List<double> ep, double curr)
        {
            module = m; numOfExams = num; examWeight = ew;
            examNames = en; examPercent = ep; currPercent = CalculatePercentage(curr,num,ew,ep);
        }
        #endregion

        public static double CalculatePercentage(double currPercent,int exams,List<int> weight,List<double> percent)
        {         

            //Get overall percentage from weight and percentages
            for (int i = 0; i <= exams; i++)
            {
                int tempWeight = 0;
                tempWeight = weight[i] / 100;
                currPercent += (double)tempWeight * percent[i];
            }   

            return currPercent;
        }
    }
}
