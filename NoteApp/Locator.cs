using Microsoft.Extensions.DependencyInjection;
using NoteApp.Data;
using NoteApp.ViewModels;
using NoteApp.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NoteApp
{
    public static class Locator
    {
        private static IServiceProvider serviceProvider;
        public static void Initialize()
        {
            
            var services = new ServiceCollection();
            //services.AddSingleton<INoteRepository, SqliteNoteRepository>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<NotesViewModel>();
            services.AddTransient<HomeView>();
            services.AddTransient<NotesView>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();

    }
}
