using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace App3
{
    [Activity(Label = "Home", MainLauncher = true, Theme ="@style/AppTheme",  Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { StartActivity(typeof(Tabbednav)); };


            var nav = FindViewById<Button>(Resource.Id.myButton2);
            nav.Click += delegate { StartActivity(typeof(Navdrawer)); };

        }
    }
}

