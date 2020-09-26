using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Data
{
    public interface INoteRepository
    {
        Task Initialize();
        Task<List<Note>> GetNotes();
        Task AddOrUpdateNote(Note note);
    }
}
