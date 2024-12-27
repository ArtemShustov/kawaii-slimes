using Game.Items;
using UnityEngine;

namespace Game.Accessories {
	public class HatSlot: MonoBehaviour {
		[SerializeField] private Hat _hat;
		private GameObject _instance;

		public void Show() {
			_instance?.SetActive(true);
		}
		public void Hide() {
			_instance?.SetActive(false);
		}

		public void Set(Hat hat) {
			if (_instance) {
				Destroy(_instance);
			}
			_hat = hat;
			_instance = Instantiate(_hat.Prefab, transform);
		}
	}
}