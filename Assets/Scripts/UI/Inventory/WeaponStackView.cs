using System;
using Core.Events;
using Game.Items;
using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Inventory {
	[Obsolete]
	public class WeaponStackView: MonoBehaviour {
		[SerializeField] private WeaponSlot _slot;
		[SerializeField] private string _infoPattern = "{0} LVL ({1}/{2} exp)\nDamage: {3}";
		[Header("Components")]
		[SerializeField] private GameObject _root;
		[SerializeField] private Image _icon;
		[SerializeField] private TMP_Text _name;
		[SerializeField] private TMP_Text _info;
		[SerializeField] private Button _useButton;
		
		private WeaponStack _stack;
		
		public void Bind(WeaponStack weaponStack) {
			_stack = weaponStack;
			
			_icon.sprite = _stack.Item.Icon;
			_name.text = _stack.Item.name;
			_info.text = string.Format(_infoPattern, 
				_stack.GetLevel(), 
				_stack.Experience, 
				_stack.Item.GetMaxExperience(), 
				_stack.GetDamage()
			);
		}
		public void Show() => _root.SetActive(true);
		public void Hide() {
			_root.SetActive(false);
			_stack = null;
		}

		private void OnItemSelected(ItemSelectedEvent gameevent) {
			if (gameevent.View.Stack is WeaponStack weaponStack) {
				Bind(weaponStack);
				Show();
			}
		}
		private void OnUseButtonClicked() {
			if (_stack != null) {
				_slot.SetWeapon(_stack);
			}
		}
		private void OnEnable() {
			Hide();
			EventBus<ItemSelectedEvent>.Event += OnItemSelected;
			_useButton.onClick.AddListener(OnUseButtonClicked);
		}
		private void OnDisable() {
			EventBus<ItemSelectedEvent>.Event -= OnItemSelected;
			_useButton.onClick.RemoveListener(OnUseButtonClicked);
		}
	}
}