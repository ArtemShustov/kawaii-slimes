using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Inventory {
	public class ActiveWeaponView: MonoBehaviour {
		[SerializeField] private Image _icon;
		[SerializeField] private TMP_Text _label;
		[SerializeField] private TMP_Text _modifierLabel;
		[Space]
		[SerializeField] private WeaponSlot _slot;

		private void UpdateUI() {
			_icon.sprite = _slot.Weapon?.Item?.Icon;
			_modifierLabel.text = $"Damage modifier: x{_slot.Weapon?.DamageModifier ?? 1}";
			_label.text = _slot.Weapon?.Item?.name ?? "No weapon";
		}

		private void OnWeaponChanged() {
			UpdateUI();
		}
		private void OnEnable() {
			_slot.WeaponChanged += OnWeaponChanged;
			UpdateUI();
		}
		private void OnDisable() {
			_slot.WeaponChanged -= OnWeaponChanged;
		}
	}
}