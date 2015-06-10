
namespace XFormsCrossTemplate.UI.Helpers
{
	public class UiContext : IUiContext
	{
#if ANDROID
        public Android.App.Activity CurrentContext { get; set; }
#elif IOS
		public UIKit.UIViewController CurrentContext { get; set; }
#endif
	}
}
