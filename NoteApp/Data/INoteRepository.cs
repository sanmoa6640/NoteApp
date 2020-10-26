using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Data
{
    public interface INoteRepository
    {
        Task Initialize();
        Task<ObservableCollection<Note>> GetNotes();
        Task AddOrUpdateNote(Note note);
    }
}
