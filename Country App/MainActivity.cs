using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Country_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        Spinner capspinner;   
        TextView capital;

        ImageView capitalImages;


        string[] CapitalArray = { "Delhi", "Amsterdam" , "Dhaka", "Ottawa", "Kathmandu", "Washington" };



        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            capspinner = (Spinner)FindViewById(Resource.Id.spinner1);

            capital = (TextView)FindViewById(Resource.Id.capitalTV);

            capitalImages = (ImageView)FindViewById(Resource.Id.imageView1);




            var capitalNamesAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.CapitalArray, Android.Resource.Layout.SimpleSpinnerItem);

            capspinner.Adapter = capitalNamesAdapter;

            capspinner.ItemSelected += delegate

            {

                long i = capspinner.SelectedItemId;

                capital.Text = CapitalArray[i].ToString();

                Toast.MakeText(this, "The Selected Country is : " + capspinner.SelectedItem, ToastLength.Long).Show();

                string imgName = "capital0" + i;

                int imgId = this.Resources.GetIdentifier(imgName, "mipmap", this.PackageName);

                capitalImages.SetImageResource(imgId);

            };

        }

        public override bool OnCreateOptionsMenu(IMenu menu)

        {

            MenuInflater.Inflate(Resource.Menu.menu_main, menu);

            return true;

        }

        public override bool OnOptionsItemSelected(IMenuItem item)

        {

            int id = item.ItemId;

            if (id == Resource.Id.action_settings)

            {

                return true;

            }

            return base.OnOptionsItemSelected(item);

        }

        private void FabOnClick(object sender, EventArgs eventArgs)

        {

            View view = (View)sender;

            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)

                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();

        }


    }
}

