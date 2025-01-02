using Game.UI.Inventory.StackView;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Inventory.Weapons {
	public class UpgradeWeaponButton: WeaponButton {
		[Header("Settings")]
		[SerializeField] private int _expPerClick = 1;
		[Header("Components")]
		[SerializeField] private Button _button;
		[SerializeField] private TMP_Text _label;
		[SerializeField] private ItemStackView _view;

		private void Awake() {
			// _button.interactable = false;
			_label.text = "[WIP] Upgrade";
		}

		private void OnButtonClicked() {
			Weapon.SetExperience(Weapon.Experience + _expPerClick);
			_view.UpdateView();
		}

		private void OnEnable() {
			_button.onClick.AddListener(OnButtonClicked);
		}
		private void OnDisable() {
			_button.onClick.RemoveListener(OnButtonClicked);
		}
	}
}