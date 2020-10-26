using NoteApp.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RestSharp;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NoteApp.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        #region Attributes

        private Stream photo;
        public Stream Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged(); }
        }

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
        private string uri;
        public string Uri
        {
            get { return uri; }
            set { uri = value; OnPropertyChanged(); }
        }
        private string imageFile;
        public string ImageFile
        {
            get { return imageFile; }
            set { imageFile = value; OnPropertyChanged(); }
        }
        private ImageSource imSource;
        public ImageSource ImSource
        {
            get { return imSource; }
            set { imSource = value; OnPropertyChanged(); }
        }
        private bool photoIsVisible;
        public bool PhotoIsVisible
        {
            get { return photoIsVisible; }
            set { photoIsVisible = value; OnPropertyChanged(); }
        }
        private bool photoIsNotVisible;
        public bool PhotoIsNotVisible
        {
            get { return photoIsNotVisible; }
            set { photoIsNotVisible = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands

        public Command SaveNoteCommand => new Command(async () => await SaveNoteAction());

        public async Task SaveNoteAction()
        {
            SaveNoteMethod();
            await Navigation.PopAsync();
        }
        public Command TakePhotoCommand => new Command(async () => await TakePhotoAction());

        
        #endregion

        #region Constructor
        public NotesViewModel()
        {
            PhotoIsVisible = false;
            PhotoIsNotVisible = true;
            //DownloadLoadImage();

        }

      /*  public void DownloadLoadImage()
        {

            //if (string.IsNullOrEmpty(Uri))
            //{
            //    var client = new RestClient("https://image.freepik.com/vector-gratis/verano-puesta-sol-palmera_116220-31.jpg"){ Timeout = -1  };
            //    var request = new RestRequest(Method.GET);
            //    byte[] bytearray = client.DownloadData(request);
            //    var cacheDir = FileSystem.CacheDirectory;
            //    var FileName = "image.png";
            //    string path = Path.Combine(cacheDir, FileName);
            //    File.WriteAllBytes(path, bytearray);
            //    Uri = path;
            //}   
        }
      */
        #endregion

        #region Methods


        private async Task TakePhotoAction()
        {
            try
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    Directory = "AppImages",
                    Name = "test.jpg",
                    PhotoSize = PhotoSize.Custom,
                    CustomPhotoSize = 90,
                    CompressionQuality = 92
                });
                var path = photo.Path;
                if (photo != null)
                {
                    ImSource = ImageSource.FromStream(() => { return photo.GetStream(); });
                    PhotoIsVisible = true;
                    PhotoIsNotVisible = false;
                    await Application.Current.MainPage.DisplayAlert("File Location", photo.Path, "OK");
                }
            }
            catch(Exception e)
            {
            }
            
            
            
            
        }
        public async Task RefreshUI()
        {
            //ImSource = ImageSource.FromStream(() => { return photo.GetStream(); });
        }
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
