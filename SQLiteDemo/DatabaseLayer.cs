using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteDemo.Model;

namespace SQLiteDemo
{
    public class DatabaseLayer
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        public bool CreateDatabase()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(folder, "Student.db")))
                {
                    conn.CreateTable<Student>();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Insert(Student student)
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(folder, "Student.db")))
                {
                    conn.Insert(student);
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Student> Select()
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(folder, "Student.db")))
                {
                    return conn.Table<Student>().ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
        public bool Delete(Student student)
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(folder, "Student.db")))
                {
                    conn.Delete(student);
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool SelectTable(int id)
        {
            try
            {
                using (var conn = new SQLiteConnection(System.IO.Path.Combine(folder, "Student.db")))
                {
                    conn.Query<Student>("SELECT * from Student WHERE id=?",id);
                    return true;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}