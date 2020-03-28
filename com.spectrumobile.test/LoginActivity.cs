using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;
using Android.Content;
using com.spectrumobile.test.Utility;

namespace com.spectrumobile.test
{

    [Activity(Label = "Spectrum Test", Theme = "@style/AppTheme", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity
    {
        private EditText _userNameView;
        private EditText _passwordView;
        private Button _loginButton;
        private SqliteUtility dbHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            dbHelper = new SqliteUtility(this);
            FindViews();
            LinkEventHandlers();
        }

        private void FindViews()
        {
            _userNameView = FindViewById<EditText>(Resource.Id.username);
            _passwordView = FindViewById<EditText>(Resource.Id.password);
            _loginButton = FindViewById<Button>(Resource.Id.button);
        }

        private void LinkEventHandlers()
        {
            _loginButton.Click += Login_Click;
            _passwordView.TextChanged += OnTextChanged;
        }

        private void Login_Click(object sender, System.EventArgs e)
        {
            string userName = _userNameView.Text;
            string password = _passwordView.Text;
           if(isValidEmail(userName))
            {
                dbHelper.InsertNewUser(userName);
                var intent = new Intent(this, typeof(ListActivity));
                StartActivity(intent);
            }
            Toast.MakeText(this, "A button was clicked " + " " + userName, ToastLength.Short).Show();

            Android.Widget.Toast.MakeText(this, "Login Button Clicked!", Android.Widget.ToastLength.Short).Show();

        }

        private void OnTextChanged(object sender, EventArgs e)
        {
      
        }

        public bool isValidEmail(string email)
        {
            return Android.Util.Patterns.EmailAddress.Matcher(email).Matches();
        }

    }
}




