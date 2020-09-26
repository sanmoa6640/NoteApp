using Newtonsoft.Json;
using NoteApp.Data;
using NoteApp.Models;
using NoteApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NoteApp.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        #region Attributes
        private List<Note> notes;
        public List<Note> Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChanged(); }
        }
        private Note note;
        public Note Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged(); }
        }
        public SqliteNoteRepository noteRepository;
        #endregion

        #region Commands
        public Command AddNoteCommand => new Command(async () => await AddNoteAction());

        #endregion

        #region Constructor
        public HomeViewModel()
        {
            LoadNotes();
        }

        private async Task LoadNotes()
        {
            Notes = await App.NoteDatabase.GetNotes();
        }
        #endregion

        #region Methods 
        public async Task AddNoteAction()
        {
            var notesView = Locator.Resolve<NotesView>();
            await Navigation.PushAsync(notesView);
        }

        public async Task RefreshUI()
        {
            Notes = await App.NoteDatabase.GetNotes();
        }
        #endregion

    }
}