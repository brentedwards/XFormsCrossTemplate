using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using XFormsCrossTemplate.UI.ViewModels;

namespace XFormsCrossTemplate.UI
{
	public class CoreApp : MvxApplication
	{
		public override void Initialize()
		{
			CreatableTypes()
				.EndingWith("Service")
				.AsInterfaces()
				.RegisterAsLazySingleton();

			CreatableTypes()
				.EndingWith("ViewModel")
				.AsTypes()
				.RegisterAsDynamic();

			RegisterAppStart<FirstPageViewModel>();
		}
	}
}
