using System;

namespace Core.MVVM {
	public interface IView<T> where T: IViewModel {
		Type ViewModelType { get; }
		void Bind(T viewModel);
	}
}