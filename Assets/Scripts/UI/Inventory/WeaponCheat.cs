using Game.Items;
using Game.Player;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI.Inventory {
	public class WeaponCheat: MonoBehaviour, IPointerClickHandler {
		[SerializeField] private WeaponStack _stack;
		[SerializeField] private WeaponSlot _slot;
		[Space]
		[SerializeField] private Image _icon;
		[SerializeField] private TMP_Text _label;

		private void Awake() {
			_icon.sprite = _stack.Item.Icon;
			_label.text = _stack.Item.name;
		}

		public void OnPointerClick(PointerEventData eventData) {
			_slot.SetWeapon(_stack);
		}
	}
}