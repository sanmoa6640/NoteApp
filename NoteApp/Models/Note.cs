using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Models
{
    public class Note
    {
        public Note()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }
        
    }

}
