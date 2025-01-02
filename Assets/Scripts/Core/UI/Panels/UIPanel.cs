using System;
using Core.MVVM;

namespace Core.UI.Panels {
	public abstract class UIPanel<TViewModel>: AbstractUIPanel, IView<TViewModel> where TViewModel: IViewModel {
		protected TViewModel ViewModel { get; private set; }
		public Type ViewModelType => typeof(TViewModel);
		
		public virtual void Bind(TViewModel viewModel) {
			ViewModel = viewModel;
		}

		public override void Show() {
			gameObject.SetActive(true);
		}
		public override void Hide() {
			gameObject.SetActive(false);
		}
	}
}