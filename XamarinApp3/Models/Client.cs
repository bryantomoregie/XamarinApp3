using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApp3.Models
{
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

    }
}
