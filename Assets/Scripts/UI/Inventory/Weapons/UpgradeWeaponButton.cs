using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Inventory.Weapons {
	public class UpgradeWeaponButton: SelectedWeaponButton {
		[Header("Settings")]
		[Header("Components")]
		[SerializeField] private Button _button;
		[SerializeField] private TMP_Text _label;

		private void Awake() {
			_label.text = "WIP";
			_button.interactable = false;
		}

		private void OnButtonClicked() {}

		private void OnEnable() {
			_button.onClick.AddListener(OnButtonClicked);
		}
		private void OnDisable() {
			_button.onClick.RemoveListener(OnButtonClicked);
		}
	}
}