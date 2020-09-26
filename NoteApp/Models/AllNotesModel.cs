using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Models
{
    public class AllNotesModel
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int NoteId { get; set; }
        [MaxLength(60), NotNull]
        public string NoteTitle { get; set; }
        public DateTime Date { get; set; }
    }
}
