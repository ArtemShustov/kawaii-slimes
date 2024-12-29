using Game.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Inventory {
	public class ClearCheat: MonoBehaviour, IPointerClickHandler {
		[SerializeField] private WeaponSlot _slot;
		
		public void OnPointerClick(PointerEventData eventData) {
			_slot.SetWeapon(null);
		}
	}
}