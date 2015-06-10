
namespace XFormsCrossTemplate.UI.Helpers
{
	// Borrowed from https://github.com/Cheesebaron/Xam.Forms.Mvx/blob/master/Movies/Movies.Android/MvxDroidAdaptation/IMvxPageNavigationHost.cs
	public interface IMvxPageNavigationHost
	{
		IMvxPageNavigationProvider NavigationProvider { get; set; }
	} 
}