using UnityEngine;

namespace Game.Accessories {
	public class WeaponSlot: MonoBehaviour {
		[SerializeField] private HandSlot _hand;
		[SerializeField] private GameObject _weapon;

		private void Awake() {
			_hand.Put(_weapon);
			_weapon.SetActive(false);
		}

		private void OnArmCallback() {
			_weapon.SetActive(true);
		}
		private void OnDisarmCallback() {
			_weapon.SetActive(false);
		}
	}
}