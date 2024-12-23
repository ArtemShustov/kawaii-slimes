namespace Game.Pools {
	public interface IPoolableAs<T>: IPoolable where T: IPoolable {
		void SetPool(IPool<T> pool);
	}
}