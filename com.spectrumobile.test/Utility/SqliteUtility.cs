using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using System;
using System.Collections.Generic;

namespace com.spectrumobile.test.Utility
{
 public   class SqliteUtility: SQLiteOpenHelper
    {
        private static String DB_NAME = "Spectrum";
        private static int DB_VERSION = 1;
        private static String DB_TABLE = "User";
        private static String DB_COLUMN = "UserName";
        public SqliteUtility(Context context) : base(context, DB_NAME, null, DB_VERSION)
        {
        }
        public override void OnCreate(SQLiteDatabase db)
        {
            string query = $"CREATE TABLE {SqliteUtility.DB_TABLE} (ID INTEGER PRIMARY KEY AUTOINCREMENT, {SqliteUtility.DB_COLUMN} TEXT NOT NULL);";
            db.ExecSQL(query);
        }
        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            string query = $"DELETE TABLE IF EXISTS {DB_TABLE}";
            db.ExecSQL(query);
            OnCreate(db);
        }
        public void InsertNewUser(String user)
        {
            SQLiteDatabase db = this.WritableDatabase;
            ContentValues values = new ContentValues();
            values.Put(DB_COLUMN, user);
            db.InsertWithOnConflict(DB_TABLE, null, values, Android.Database.Sqlite.Conflict.Replace);
            db.Close();
        }
        public void DeleteUser(String user)
        {
            SQLiteDatabase db = this.WritableDatabase;
            db.Delete(DB_TABLE, DB_COLUMN + " = ?", new String[] { user });
            db.Close();
        }
        public List<string> GetUserList()
        {
            List<string> userList = new List<string>();
            SQLiteDatabase db = this.ReadableDatabase;
            ICursor cursor = db.Query(DB_TABLE, new string[] { DB_COLUMN }, null, null, null, null, null);
            while (cursor.MoveToNext())
            {
                int index = cursor.GetColumnIndex(DB_COLUMN);
                userList.Add(cursor.GetString(index));
            }
            return userList;
        }
    }
}