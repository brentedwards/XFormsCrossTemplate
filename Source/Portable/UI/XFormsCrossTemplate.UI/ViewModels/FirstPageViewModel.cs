using Cirrious.MvvmCross.ViewModels;

namespace XFormsCrossTemplate.UI.ViewModels
{
    public class FirstPageViewModel 
		: BaseViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
    }
}
