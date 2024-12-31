namespace Core.MVVM {
	public interface IView<T> where T: IViewModel {
		void Bind(T viewModel);
	}
}