using UnityEngine;

namespace Game {
	public class PlaceObjectInArea: MonoBehaviour {
		[SerializeField] private int _count;
		[SerializeField] private float _radius;
		[SerializeField] private GameObject _target;

		private void Awake() {
			for (int i = 0; i < _count; i++) {
				var rnd = Random.insideUnitCircle * _radius;
				var position = transform.position + new Vector3(rnd.x, 0, rnd.y);
				var instance = Instantiate(_target, transform);
				instance.transform.position = position;
			}
		}
		private void OnDrawGizmosSelected() {
			Gizmos.DrawWireSphere(transform.position, _radius);
		}
	}
}