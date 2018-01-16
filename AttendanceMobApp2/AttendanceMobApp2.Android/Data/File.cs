using System;
using System.IO;
using Android.Content;
using Android.Support.V7.Widget;
using AttendanceMobApp2.Data;
using AttendanceMobApp2.Droid.Data;
using Java.Util;
using Environment = System.Environment;
using Xamarin.Forms;


[assembly: Dependency(typeof(FileImplementation))]
namespace AttendanceMobApp2.Droid.Data
{
    public class FileImplementation : IFile
    {
        //public void SaveSettings(string regCode)
        //{
        //    ISharedPreferences sharedprefs = GetSharedPreferences("prefs_file", FileCreationMode.Private);
        //    sharedprefs.Edit().PutString("keyName", "value").Commit();
        //}
        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.Delete(filePath);
            File.WriteAllText(filePath, text);
        }

        public string LoadText(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }

        public void ClearFile(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.Delete(filePath);
        }

        public bool FileExists(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return File.Exists(filePath);
        }
    }
}