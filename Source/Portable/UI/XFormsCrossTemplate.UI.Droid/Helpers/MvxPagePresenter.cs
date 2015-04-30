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
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using Xamarin.Forms;

namespace XFormsCrossTemplate.UI.Helpers
{
	// Borrowed from: https://github.com/Cheesebaron/Xam.Forms.Mvx/blob/master/Movies/Movies.Android/MvxDroidAdaptation/MvxPagePresenter.cs
	public sealed class MvxPagePresenter
		: MvxAndroidViewPresenter, IMvxPageNavigationHost
	{
		public override void Show(MvxViewModelRequest request)
		{
			if (TryShowPage(request))
				return;

			Mvx.Error("Skipping request for {0}", request.ViewModelType.Name);
		}

		private bool TryShowPage(MvxViewModelRequest request)
		{
			if (this.NavigationProvider == null)
				return false;

			var page = MvxPresenterHelpers.CreatePage<Page>(request);
			if (page == null)
				return false;

			var viewModel = MvxPresenterHelpers.LoadViewModel(request);

			page.BindingContext = viewModel;

			this.NavigationProvider.Push(page);

			return true;
		}

		public override void Close(IMvxViewModel viewModel)
		{
			if (this.NavigationProvider == null)
				return;

			this.NavigationProvider.Pop();
		}

		public IMvxPageNavigationProvider NavigationProvider { get; set; }
	}
}