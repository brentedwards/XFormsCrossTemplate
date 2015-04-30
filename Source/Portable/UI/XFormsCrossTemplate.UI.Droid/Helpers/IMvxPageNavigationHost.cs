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

namespace XFormsCrossTemplate.UI.Helpers
{
	// Borrowed from https://github.com/Cheesebaron/Xam.Forms.Mvx/blob/master/Movies/Movies.Android/MvxDroidAdaptation/IMvxPageNavigationHost.cs
	public interface IMvxPageNavigationHost
	{
		IMvxPageNavigationProvider NavigationProvider { get; set; }
	} 
}