using System.Collections;
using UnityEngine;

namespace Game.Pools.Effects {
	public class Effect: MonoBehaviour, IPoolableAs<Effect> {
		[SerializeField] private float _returnTime = 1;
		[SerializeField] private EffectComponent[] _components;

		private IPool<Effect> _pool;
		private Coroutine _returnTimer;
		
		public void PlayAt(Vector3 position) {
			transform.position = position;
			foreach (var component in _components) {
				component.Play();
			}
			if (_returnTimer != null) {
				StopCoroutine(_returnTimer);
			}
			_returnTimer = StartCoroutine(ReturnToPool());
		}
		
		public void SetPool(IPool<Effect> pool) {
			_pool = pool;
		}
		
		public void OnGetFromPool() {
			gameObject.SetActive(true);
		}
		public void OnReturnToPool() {
			gameObject.SetActive(false);
			
			if (_returnTimer != null) {
				StopCoroutine(_returnTimer);
				_returnTimer = null;
			}
		}

		private IEnumerator ReturnToPool() {
			yield return new WaitForSeconds(_returnTime);
			_pool.Return(this);
			_returnTimer = null;
		}
	}
}