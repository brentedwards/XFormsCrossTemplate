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
using Android.Content.PM;
using Xamarin.Forms.Platform.Android;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Xamarin.Forms;

namespace XFormsCrossTemplate.UI.Helpers
{
	// Borrowed from: https://github.com/Cheesebaron/Xam.Forms.Mvx/blob/master/Movies/Movies.Android/MvxDroidAdaptation/MvxNavigationActivity.cs
	[Activity(Label = "XFormsCross Template"
		, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MvxNavigationActivity
		: FormsApplicationActivity
		, IMvxPageNavigationProvider
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			Xamarin.Forms.Forms.Init(this, bundle);

			var uiContext = new UiContext
			{
				CurrentContext = this
			};

			Mvx.Resolve<IMvxPageNavigationHost>().NavigationProvider = this;
			Mvx.Resolve<IMvxAppStart>().Start();
		}

		public async void Push(Page page)
		{
			if (MvxNavigationActivity.NavigationPage != null)
			{
				await MvxNavigationActivity.NavigationPage.PushAsync(page);
				return;
			}

			MvxNavigationActivity.NavigationPage = new NavigationPage(page);
			this.SetPage(MvxNavigationActivity.NavigationPage);
		}

		public async void Pop()
		{
			if (MvxNavigationActivity.NavigationPage == null)
				return;

			await MvxNavigationActivity.NavigationPage.PopAsync();
		}

		public static NavigationPage NavigationPage { get; set; }
	}
}