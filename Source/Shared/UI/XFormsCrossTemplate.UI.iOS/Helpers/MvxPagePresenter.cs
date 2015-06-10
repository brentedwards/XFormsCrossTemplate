using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace XFormsCrossTemplate.UI.Helpers
{
	// Mostly borrowed from: https://github.com/Cheesebaron/Xam.Forms.Mvx/blob/master/Movies/Movies.iOS/MvxFormsTouchViewPresenter.cs
	public sealed class MvxPagePresenter : IMvxTouchViewPresenter
	{
		private readonly UIWindow _window;
		private NavigationPage _navigationPage;
		private readonly IUiContext context;

		public MvxPagePresenter(UIWindow window, IUiContext context)
		{
			_window = window;
			this.context = context;
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

			if (_navigationPage == null)
			{
				_navigationPage = new NavigationPage(page);
				_window.RootViewController = _navigationPage.CreateViewController();
				this.context.CurrentContext = _window.RootViewController;
			}
			else
			{
				await _navigationPage.PushAsync(page);
			}

			page.BindingContext = viewModel;
			return true;
		}

		public async void ChangePresentation(MvxPresentationHint hint)
		{
			if (hint is MvxClosePresentationHint)
			{
				await _navigationPage.PopAsync();
			}
		}

		public bool PresentModalViewController(UIViewController controller, bool animated)
		{
			return false;
		}

		public void NativeModalViewControllerDisappearedOnItsOwn()
		{

		}
	}
}