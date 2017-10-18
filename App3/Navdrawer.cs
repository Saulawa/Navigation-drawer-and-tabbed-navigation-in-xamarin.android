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
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;

namespace App3
{
    [Activity(Label = "Navdrawer" , Theme ="@style/AppTheme")]
    public class Navdrawer : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        Android.Support.V7.Widget.Toolbar toolbar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.draweractivity);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
             toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            // event handler for the side bar
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open, Resource.String.close);

            //this is what makes the nav drawer open by clicking the
            //hamburger menu on the right side of toolbar
            drawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            // we have to add one fragment which displays by default

            var ft = FragmentManager.BeginTransaction();
       
            ft.Add(Resource.Id.homeframe, new Tea());
            ft.Commit();

            toolbar.Title = "Tea";
        }

        //we are using nav bar to change the displayed frgmnet based on user
        //selection

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.fragone):
                    var ft = FragmentManager.BeginTransaction();
                    ft.SetTransition(FragmentTransit.FragmentOpen);
                    ft.Replace(Resource.Id.homeframe, new Tea());
                    ft.Commit();
                    toolbar.Title = "Tea";
                    break;
                case (Resource.Id.fragtwo):

                    var ft2 = FragmentManager.BeginTransaction();
                    ft2.SetTransition(FragmentTransit.FragmentOpen);
                    ft2.Replace(Resource.Id.homeframe, new Coffee());
                    ft2.Commit();
                    toolbar.Title = "Coffee";
                    break;
          
            }
            drawerLayout.CloseDrawers();
        }
    }
}