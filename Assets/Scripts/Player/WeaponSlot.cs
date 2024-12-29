using System;
using Game.Accessories;
using Game.Items;
using Game.Player.States;
using NUnit.Framework;
using UnityEngine;

namespace Game.Player {
	public class WeaponSlot: MonoBehaviour {
		[SerializeField] private AttackArea _swordArea;
		[SerializeField] private HandSlot _hand;
		[Space]
		[SerializeField] private WeaponStack _weapon;

		private bool _isShowed;

		public event Action WeaponChanged;
		
		public bool HasWeapon => _weapon != null && _weapon.Item != null;
		public WeaponStack Weapon => _weapon;

		private void Start() {
			SetWeapon(_weapon);
		}

		public void SetWeapon(WeaponStack weapon) {
			_weapon = weapon;
			if (HasWeapon) {
				_swordArea.SetDamage(_weapon.GetDamage());
			}
			WeaponChanged?.Invoke();
		}

		public void Hide() {
			if (!_isShowed) {
				return;
			}
			_hand.Clear();
			_isShowed = false;
		}
		public void Show() {
			if (_isShowed || !HasWeapon) {
				return;
			}
			var instance = Instantiate(_weapon.Item.Prefab, _hand.transform);
			_hand.Put(instance);
			_isShowed = true;
		}

		private void OnValidate() {
			if (Application.isPlaying) {
				SetWeapon(_weapon);
			}
		}
	}
}