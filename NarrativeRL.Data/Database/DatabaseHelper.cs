using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace NarrativeRL.Data.Database
{  
    public static class DatabaseHelper
    {
        private static SQLiteConnection db = null;

        public static SQLiteConnection GetInstance()
        {
            if (db == null)
            {
                db = new SQLiteConnection(@".\Database\nrl_db.sqlite");
            }

            return db;
        }

        public static void Close()
        {
            if (db != null)
            {
                db.Close();
                db.Dispose();
            }
        }
    }
}
