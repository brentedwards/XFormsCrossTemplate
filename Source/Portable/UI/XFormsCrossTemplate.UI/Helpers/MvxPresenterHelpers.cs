using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using System;
using Xamarin.Forms;

namespace XFormsCrossTemplate.UI.Helpers
{
	// This class is mostly borrowed from: https://github.com/Cheesebaron/Xam.Forms.Mvx/blob/master/Movies/Movies/MvxPresenterHelpers.cs
	public static class MvxPresenterHelpers
	{
		public static IMvxViewModel LoadViewModel(MvxViewModelRequest request)
		{
			var viewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();
			var viewModel = viewModelLoader.LoadViewModel(request, null);
			return viewModel;
		}

		public static T CreatePage<T>(MvxViewModelRequest request)
			 where T : class
		{
			var viewType = MvxPresenterHelpers.ResolveViewType(request.ViewModelType);

			if (viewType == null)
			{
				Mvx.Trace("Page not found for {0}", request.ViewModelType.Name);
				return null;
			}

			var page = Activator.CreateInstance(viewType) as T;
			if (page == null)
			{
				Mvx.Error("Failed to create ContentPage {0}", viewType.Name);
			}
			return page;
		}

		private static Type ResolveViewType(Type viewModelType)
		{
			var viewName = viewModelType.AssemblyQualifiedName.Replace(
				viewModelType.Name,
				viewModelType.Name.Replace("ViewModel", string.Empty));
			viewName = viewName.Replace("Model", string.Empty);

			Type viewType = null;

			if (Device.Idiom == TargetIdiom.Tablet)
			{
				viewType = Type.GetType(viewName.Replace("Page", "PageTablet"));
			}
			else
			{
				viewType = Type.GetType(viewName.Replace("Page", "PagePhone"));
			}

			if (viewType == null)
			{
				viewType = Type.GetType(viewName);
			}

			return viewType;
		}
	}
}
