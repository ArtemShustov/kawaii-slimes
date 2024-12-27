using Game.Accessories;
using Game.Items;
using UnityEngine;

namespace Game.Player {
	public class WeaponSlot: MonoBehaviour {
		[SerializeField] private HandSlot _hand;
		[SerializeField] private Weapon _weapon;
		
		public bool HasWeapon => _weapon != null;
	}
}