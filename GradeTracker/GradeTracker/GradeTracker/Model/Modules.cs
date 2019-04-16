using GradeTracker.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
            //examNames = new List<string>();
            //examWeight = new List<int>();
           // examPercent = new List<double>();
            //SetLists(examNamesString,examWeightString,examPercentString,examNames,examWeight,examPercent);
        }

        #endregion

        public static double CalculatePercentage(int exams,List<int> weight,List<double> percent)
        {
            double currPercent = 0;
            //Get overall percentage from weight and percentages
            for (int i = 0; i < exams; i++)
            {
                double tempWeight = 0;
                tempWeight = (double)weight[i] / 100;
                currPercent += tempWeight * percent[i];
                Debug.WriteLine(currPercent+"\n"+i);
            }   

            return currPercent;
        }
        
        public static List<string> SetNamesList(string enString, List<string> en)
        {
            en = new List<string>();
            string[] holder = null;

            //Put each exam Name into the List<string>
            holder = enString.Split(',');
            foreach (string word in holder)
            {
                en.Add(word);
            }
            return en;
        }

        public static List<int> SetWeightList(string ewString, List<int> ew)
        {
            ew = new List<int>();
            string[] holder = null;

            //Put each exam Weight into the List<int>
            holder = ewString.Split(',');
            foreach (string word in holder)
            {
                var number = int.Parse(word);
                ew.Add(number);
            }
            return ew;
        }

        public static List<double> SetPercentList(string epString, List<double> ep)
        {
            ep = new List<double>();
            string[] holder = null;

            //Put each exam Percent into the List<double>
            holder = epString.Split(',');
            foreach (string word in holder)
            {
                var number = double.Parse(word);
                ep.Add(number);
            }
            return ep;
        }
    }
}
