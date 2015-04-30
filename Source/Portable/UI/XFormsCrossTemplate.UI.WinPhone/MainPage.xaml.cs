using Microsoft.Phone.Controls;
using Xamarin.Forms;
using XFormsCrossTemplate.UI.Helpers;

namespace XFormsCrossTemplate.UI
{
	public partial class MainPage : PhoneApplicationPage
	{
		public MainPage()
		{
			InitializeComponent();
			SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

			global::Xamarin.Forms.Forms.Init();

			var navigationPage = MvxFormsWindowsPhonePagePresenter.NavigationPage;
			Content = navigationPage.ConvertPageToUIElement(this);
		}
	}
}
