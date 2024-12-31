namespace Core.Items {
	public interface ICountableStack {
		int Count { get; }
		void SetCount(int count);
	}
}