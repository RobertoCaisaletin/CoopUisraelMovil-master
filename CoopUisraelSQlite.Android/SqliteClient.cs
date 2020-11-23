using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;  // importamos  la libreria
using Java.Nio.FileNio;
using CoopUisraelSQlite.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SqliteClient))]

namespace CoopUisraelSQlite.Droid
{
    public class SqliteClient : DataBase
    {  
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "uisrael.db3");
            return new SQLiteAsyncConnection(path);

        }
    }
}