using NoteApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesView : ContentPage
    {
        public NotesView(NotesViewModel notesViewModel)
        {
            InitializeComponent();
            notesViewModel.Navigation = Navigation;
            BindingContext = notesViewModel;
            
            ToolbarItem item = new ToolbarItem
            {
                Text = "Add",
                Order = ToolbarItemOrder.Primary,
                Priority = 0,
                Command = notesViewModel.SaveNoteCommand
            };
            this.ToolbarItems.Add(item);
        }
        
    }
}