using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using SQLiteDemo.Model;
using System.Collections.Generic;
using System;

namespace SQLiteDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView List;
        List<Student> listSource = new List<Student>();
        DatabaseLayer db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            db = new DatabaseLayer();
            db.CreateDatabase();

            List = FindViewById<ListView>(Resource.Id.listView1);
            var edtName = FindViewById<EditText>(Resource.Id.edtName);
            var edtSurname = FindViewById<EditText>(Resource.Id.edtSurname);
            var btnAdd = FindViewById<Button>(Resource.Id.addButton);
            var btnRemove = FindViewById<Button>(Resource.Id.deleteButton);

            LoadData();

            btnAdd.Click += delegate
            {
                Student student = new Student()
                {
                    Name = edtName.Text,
                    Surname = edtSurname.Text
                };
                db.Insert(student);
                LoadData();
            }; 
            btnRemove.Click += delegate
            {
                Student student = new Student()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Name = edtName.Text,
                    Surname = edtSurname.Text
                };
                db.Delete(student);
                LoadData();
            };
            List.ItemClick += (s, e) =>
            {
                //Set Backround for selected item  
                for (int i = 0; i < List.Count; i++)
                {
                    if (e.Position == i)
                        List.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Pink);
                    else
                        List.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }


                //Binding Data  
                var txtName = e.View.FindViewById<TextView>(Resource.Id.textName);
                var txtSurname = e.View.FindViewById<TextView>(Resource.Id.textSurname);
          
               
                edtName.Tag = e.Id;
               
              
            };
        }

        private void LoadData()
        {
            listSource = db.Select();
            var adapter = new ListViewAdapter(this, listSource);
            List.Adapter = adapter;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}