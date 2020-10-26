using Android.Content;
using Newtonsoft.Json;
using NoteApp.Data;
using NoteApp.Models;
using NoteApp.Views;
using Plugin.Geolocator;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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

        private ObservableCollection<Note> notesCollection;
        public ObservableCollection<Note> NotesCollection
        {
            get { return notesCollection; }
            set { notesCollection = value; OnPropertyChanged(); }
        }

        private Note note;
        public Note Note
        {
            get { return note; }
            set { note = value; OnPropertyChanged(); }
        }
        private string latitude;
        public string Latitude
        {
            get { return latitude; }
            set { latitude = value; OnPropertyChanged(); }
        }
        private string longitud;
        public string Longitud
        {
            get { return longitud; }
            set { longitud = value; OnPropertyChanged(); }
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
            
            Device.BeginInvokeOnMainThread(() =>
               {
                   LoadNotesCollection();
               });

        }
        #endregion

        #region Methods 

        public async Task AddNoteAction()
        {
            try 
            {
                
                //CancellationTokenSource cts;
                //var Locator = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                //cts = new CancellationTokenSource();
                //var location = await Geolocation.GetLocationAsync(Locator, cts.Token);
                #region Funcional gps
                //var locator = CrossGeolocator.Current;
                //locator.DesiredAccuracy = 500;
                //var location = await locator.GetPositionAsync();
                //if (location != null)
                //{
                //    Latitude = location.Latitude.ToString();
                //    Longitud = location.Longitude.ToString();
                //}
                //else
                //{
                //    var location2 = await locator.GetLastKnownLocationAsync();
                //    Latitude = location2.Latitude.ToString();
                //    Longitud = location2.Longitude.ToString();

                //}
                #endregion
                

               

                

            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not enabled on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

            //var notesView = Locator.Resolve<NotesView>();
            //await Navigation.PushAsync(notesView);
        }

        public async Task RefreshUI()
        {
            Notes = await App.NoteDatabase.GetNotes();
        }

        private void LoadNotesCollection()
        {
            if(Notes != null)
            {
                foreach (Note Note in Notes)
                {
                    NotesCollection.Add(Note);
                }
            }
            
        }

        private async Task LoadNotes()
        {
            Notes = await App.NoteDatabase.GetNotes();
        }
        #endregion

    }
}