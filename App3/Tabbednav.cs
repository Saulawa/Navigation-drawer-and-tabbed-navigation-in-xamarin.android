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
using Android.Support.V4.View;
using Android.Support.V4.App;
using Java.Lang;
using Android.Support.Design.Widget;

namespace App3
{
    // the tabbednav class inherits from AppCompatActivity which is only accessible using support lib v7
    [Activity(Label = "Roses", Theme = "@style/AppTheme" )]
    public class Tabbednav : AppCompatActivity
    {
        private TabLayout tablayout;
        private ViewPager viewpager;
        // because there is a toolbar view which is not part of support libirary
        //we use fully qualified name to specify that we only need the toolbar 
        //from the support lib
        private Android.Support.V7.Widget.Toolbar toolbar;
        //private SectionPagerAdapter sections;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.tablayout);


            
            tablayout = FindViewById<TabLayout>(Resource.Id.tabbed);
            viewpager = FindViewById<ViewPager>(Resource.Id.container);
            toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarwidget);
            SetSupportActionBar(toolbar);

           
            viewpager.Adapter = new SectionPagerAdapter(SupportFragmentManager);

            tablayout.SetupWithViewPager(viewpager);

        }
 
    }

    // Section pager class returns the number of fragments to be added to the viewpager
    public class SectionPagerAdapter : FragmentPagerAdapter

    {

        //this is a constructor

        public SectionPagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
        {

        }

        // this is an overrding method of the FragmentPageAdapter that returns the number of fragments
        public override Android.Support.V4.App.Fragment GetItem(int position)
        {

            switch (position)
            {
                case 0:
                    return new Containerone();
                case 1:
                    return new Containertwo();

                case 2:
                    return new Cont();
                default:
                    return null;
            }


          
        }

        // this is a method that uses new C# feature like functional programming to return the number of the fragments
        public override int Count => 3;

        // this returns the title to be added to the tabs
        public override ICharSequence GetPageTitleFormatted(int position)
        {
      switch (position) {
                case 0:
                    return new  Java.Lang.String("one") ; // i use java language cast
                case 1:
                    return new Java.Lang.String("two");

                case 2:
                    return new Java.Lang.String("three");
            }
            return null;
        }




    }
}