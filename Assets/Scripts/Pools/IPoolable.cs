namespace Game.Pools {
	public interface IPoolable {
		void OnGetFromPool();
		void OnReturnToPool();
	}
}