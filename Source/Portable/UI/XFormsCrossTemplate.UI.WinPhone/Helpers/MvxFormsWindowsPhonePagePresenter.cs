using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsPhone.Views;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFormsCrossTemplate.UI.Helpers
{
	public sealed class MvxFormsWindowsPhonePagePresenter : IMvxPhoneViewPresenter
	{
		public static NavigationPage NavigationPage;

		private PhoneApplicationFrame _rootFrame;

		public MvxFormsWindowsPhonePagePresenter(PhoneApplicationFrame rootFrame)
		{
			_rootFrame = rootFrame;
		}

		public async void Show(MvxViewModelRequest request)
		{
			if (await TryShowPage(request))
				return;

			Mvx.Error("Skipping request for {0}", request.ViewModelType.Name);
		}

		private async Task<bool> TryShowPage(MvxViewModelRequest request)
		{
			var page = MvxPresenterHelpers.CreatePage<Page>(request);
			if (page == null)
				return false;

			var viewModel = MvxPresenterHelpers.LoadViewModel(request);

			if (NavigationPage == null)
			{
				Xamarin.Forms.Forms.Init();
				NavigationPage = new NavigationPage(page);
				_rootFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
			}
			else
			{
				await NavigationPage.PushAsync(page);
			}

			page.BindingContext = viewModel;
			return true;
		}

		public async void ChangePresentation(MvxPresentationHint hint)
		{
			if (hint is MvxClosePresentationHint)
			{
				await NavigationPage.PopAsync();
			}
		}
	}
}
