
namespace XFormsCrossTemplate.UI.Helpers
{
	public interface IUiContext
	{
#if ANDROID
		Android.App.Activity CurrentContext { get; set; }
#elif IOS
        UIKit.UIViewController CurrentContext { get; set; }
#endif
	}
}
