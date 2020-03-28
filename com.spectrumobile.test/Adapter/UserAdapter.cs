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
using com.spectrumobile.test.Utility;

namespace com.spectrumobile.test.Adapter
{
    public class UserAdapter : BaseAdapter
    {
        private ListActivity mainActivity;
        private List<string> taskList;
     //   private SqliteUtility dbHelper;
        public UserAdapter(ListActivity mainActivity, List<string> taskList, SqliteUtility dbHelper)
        {
            this.mainActivity = mainActivity;
            this.taskList = taskList;
         //   this.dbHelper = dbHelper;
        }
        public override int Count { get { return taskList.Count; } }
        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = (LayoutInflater)mainActivity.GetSystemService(Context.LayoutInflaterService);
            View view = inflater.Inflate(Resource.Layout.row, null);
            TextView txtTask = view.FindViewById<TextView>(Resource.Id.task_title);
            txtTask.Text = taskList[position];
            return view;
        }
    }
}