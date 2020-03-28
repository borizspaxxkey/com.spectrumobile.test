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
using com.spectrumobile.test.Adapter;
using com.spectrumobile.test.Utility;

namespace com.spectrumobile.test
{
    [Activity(Label = "ListActivity")]
    public class ListActivity : Activity
    {
        SqliteUtility dbHelper;
        UserAdapter adapter;
        ListView lstTask;
      
        public void LoadUserList()
        {
            List<string> taskList = dbHelper.GetUserList();
            adapter = new UserAdapter(this, taskList, dbHelper);
            lstTask.Adapter = adapter;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.user_list);
            dbHelper = new SqliteUtility(this);
            lstTask = FindViewById<ListView>(Resource.Id.lstTask);

            LoadUserList();
        }
    }
}