using UnityEngine;

namespace Game {
	public class DestroyAfter: MonoBehaviour {
		[SerializeField] private float _time = 1;

		private void OnEnable() {
			Destroy(gameObject, _time);
		}
		private void OnDisable() {
			CancelInvoke(nameof(Destroy));
		}
	}
}