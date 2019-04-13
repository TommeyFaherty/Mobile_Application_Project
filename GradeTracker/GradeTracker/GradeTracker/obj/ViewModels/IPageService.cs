using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GradeTracker.ViewModels
{
    interface IPageService
    {
        // add some methods
        Task PushAsnyc(Page page);
        Task<bool> DisplayAlert(string title, string message,
                                string ok, string cancel);
    }
}
