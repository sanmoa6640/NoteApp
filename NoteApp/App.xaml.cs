using NoteApp.Data;
using NoteApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp
{
    public partial class App : Application
    {
        static SqliteNoteRepository noteDataBase;

        public static SqliteNoteRepository NoteDatabase
        {
            get
            {
                if (noteDataBase == null)
                {
                    noteDataBase = new SqliteNoteRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.db3"));
                }
                return noteDataBase;
            }
        }

        public App()
        {
            InitializeComponent();
            Locator.Initialize();
            //InitializeRepository();
            InitializeMainPage();
        }

        private void InitializeMainPage()
        {
            MainPage = new NavigationPage(Locator.Resolve<HomeView>());
        }

        //private void InitializeRepository()
        //{
        //    INoteRepository repository = Locator.Resolve<INoteRepository>();
        //    repository.Initialize();
        //}

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
    }
}
