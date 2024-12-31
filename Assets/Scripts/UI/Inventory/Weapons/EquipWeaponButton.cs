using Game.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace Game.UI.Inventory.Weapons {
	public class EquipWeaponButton: SelectedWeaponButton {
		[Header("Settings")]
		[SerializeField] private LocalizedString _equippedText;
		[SerializeField] private LocalizedString _unequippedText;
		[Header("Components")]
		[SerializeField] private Button _button;
		[SerializeField] private LocalizeStringEvent _label;
		
		public override void SetStack(WeaponStack stack) {
			base.SetStack(stack);
			UpdateLabel();
		}

		private bool IsEquipped() {
			if (Weapon == null) {
				return false;
			}
			return ViewModel.Weapon == Weapon;
		}
		private void UpdateLabel() {
			_label.StringReference = IsEquipped() ? _equippedText : _unequippedText;
		}
		
		private void OnButtonClicked() {
			ViewModel.EquipWeapon(IsEquipped() ? null : Weapon);
			UpdateLabel();
		}
		private void OnEnable() {
			_button.onClick.AddListener(OnButtonClicked);
		}
		private void OnDisable() {
			_button.onClick.RemoveListener(OnButtonClicked);
		}
	}
}