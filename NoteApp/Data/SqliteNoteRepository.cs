using NoteApp.Models;
using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Data
{
    public class SqliteNoteRepository 
    {
        readonly SQLiteAsyncConnection _connection;

        public SqliteNoteRepository(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.DeleteAllAsync<Note>().Wait();
            _connection.CreateTableAsync<Note>().Wait();

        }

        #region CRUD

        //Select o busqueda de información

        public async Task<List<Note>> GetNotes2()
        {
            return await _connection.QueryAsync<Note>("Select * From Note");
        }
        

        public async Task<List<Note>> GetNotes()
        {
            return await _connection.Table<Note>().ToListAsync();
        }

        //Insertar y/o Actualizar

        public async Task<int> SaveNoteAsync(Note note)
        {
            if (note.Id != 0)
            {
                return await _connection.UpdateAsync(note);
            }
            else
            {
                return await _connection.InsertAsync(note);
            }
        }
                
        //Eliminar registro

        public async Task<int> DeleteNoteAsync(Note note)
        {
            return await _connection.DeleteAsync(note);
        }

        #endregion
        /*
        public async Task Initialize()
        {
            if (_connection != null) return;
            _connection = new SQLiteAsyncConnection(Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "note.db3"));
            await _connection.CreateTableAsync<Note>();
        }

        public async Task AddOrUpdateNote(Note note)
        {
            if (note.Id != 0)
            {
                
                _ = _connection.UpdateAsync(note);
                
            }
            else
            {
                _ = await _connection.InsertAsync(note);
            }
        }

        

        */
    }
}
