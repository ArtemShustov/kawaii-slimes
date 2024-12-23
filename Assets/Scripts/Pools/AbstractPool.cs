using System.Collections.Generic;
using UnityEngine;

namespace Game.Pools {
	public abstract class AbstractPool<T>: ScriptableObject, IPool<T> where T: IPoolableAs<T> {
		private readonly Stack<T> _pool = new Stack<T>();

		private Transform _root;
		
		public T Get() {
			if (!_root) {
				_root = new GameObject($"Pool of {this.GetType()}").transform;
				DontDestroyOnLoad(_root);
			}
			
			var instance = _pool.Count > 0 ? _pool.Pop() : GetNew(_root);
			instance.SetPool(this);
			instance.OnGetFromPool();
			return instance;
		}
		public void Return(T poolable) {
			_pool.Push(poolable);
			poolable.OnReturnToPool();
		}

		protected abstract T GetNew(Transform root);
	}
}