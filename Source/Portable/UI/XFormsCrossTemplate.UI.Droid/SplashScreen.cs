using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;
using XFormsCrossTemplate.UI.Helpers;

namespace XFormsCrossTemplate.UI
{
    [Activity(
		Label = "XFormsCross Template"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

		public override void InitializationComplete()
		{
			StartActivity(typeof(MvxNavigationActivity));
		}
    }
}