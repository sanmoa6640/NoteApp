using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NoteApp.ViewModels
{
    public class ViewModelBase : BindableObject
    {
        public INavigation Navigation { get; set; }
    }
}
