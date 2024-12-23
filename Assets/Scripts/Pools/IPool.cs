namespace Game.Pools {
	public interface IPool<T> where T: IPoolable {
		T Get();
		void Return(T poolable);
	}
}