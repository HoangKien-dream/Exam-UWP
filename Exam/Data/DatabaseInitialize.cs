using Exam.Entity;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    class DatabaseInitialize
    {
        public static bool CreateTables()
        {
            var conn = new SQLiteConnection("sqliteContact.db");
            string sql = @"CREATE TABLE IF NOT EXISTS
                        Contact (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                        Name VARCHAR( 140 ),
                        Phone VARCHAR(10) UNIQUE
                        );";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public static bool SaveTables(Contact contact)
        {
            var conn = new SQLiteConnection("sqliteContact.db");
            using (var contactSql = conn.Prepare("INSERT INTO Contact(Name, Phone) VALUES (?, ?)"))
            {
                contactSql.Bind(1, contact.Name);
                contactSql.Bind(2, contact.Phone);
                contactSql.Step();
            }
            return true;
        }

        public Contact GetContact(string name)
        {
            Contact contact = null;
            var conn = new SQLiteConnection("sqliteContact.db");
            using (var statement = conn.Prepare("SELECT Name, Phone FROM  Contact WHERE Name = ? "))
            {
                statement.Bind(1, name);
                if (statement.Step() == SQLiteResult.ROW)
                {
                    contact = new Contact()
                    {
                     Name = (string)statement["Name"],
                     Phone = (string)statement["Phone"]
                    };
                }
            }
            return contact;
        }
    }
}
