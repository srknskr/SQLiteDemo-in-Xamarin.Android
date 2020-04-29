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
using SQLiteDemo.Model;

namespace SQLiteDemo
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName { get; set; }
        public TextView txtSurname { get; set; }
    }
    public class ListViewAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Student> StudentList;
        public ListViewAdapter(Activity activity, List<Student> StudentList)
        {
            this.activity = activity;
            this.StudentList = StudentList;
        }
        public override int Count
        {
            get { return StudentList.Count; }
        }
        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }
        public override long GetItemId(int position)
        {
            return StudentList[position].Id;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ListView,parent,false);
            var txtName = view.FindViewById<TextView>(Resource.Id.textName);
            var txtSurname = view.FindViewById<TextView>(Resource.Id.textSurname);

            txtName.Text = StudentList[position].Name;
            txtSurname.Text = StudentList[position].Surname;

            return view;

        }

    }
}