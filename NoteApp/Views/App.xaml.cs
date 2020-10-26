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
            InitializeMainPage();
        }

        private void InitializeMainPage()
        {
            MainPage = new NavigationPage(Locator.Resolve<HomeView>());
        }

        #region AppLifeCicleMethods

        protected override void OnStart()
        {
            EraseCache();
        }

        private void EraseCache()
        {

            //var list = Directory.GetFiles(MyPath, "*");

            //if (list.Length > 0)
            //{
            //    for (int i = 0; i < list.Length; i++)
            //    {
            //        File.Delete(list[i]);
            //    }
            //}
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        #endregion
    }
}
