using Newtonsoft.Json;
using NoteApp.Data;
using NoteApp.Models;
using NoteApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms; 

namespace NoteApp.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        #region Attributes
        private string title;
        public string TitleTxt
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        private string content;
        public string ContentTxt
        {
            get { return content; }
            set { content = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands

        public Command SaveNoteCommand => new Command(async () => await SaveNoteAction());

        public async Task SaveNoteAction()
        {
            SaveNoteMethod();
            await Navigation.PopAsync();
        }
        #endregion

        #region Constructor
        public NotesViewModel()
        {
        }
        #endregion

        #region Methods
        public async void SaveNoteMethod()
        {
            if (string.IsNullOrEmpty(TitleTxt))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "you must enter a Title",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(ContentTxt))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "you must enter a Content",
                    "Accept");
                return;
            }
            if (!string.IsNullOrEmpty(ContentTxt) && !string.IsNullOrEmpty(TitleTxt))
            {
                var note = new Note
                {
                    Title = TitleTxt.ToLower(),
                    Content = ContentTxt,
                    CreateAt = DateTime.UtcNow
            };
                await App.NoteDatabase.SaveNoteAsync(note);
            }

        }
        #endregion

    }
}
