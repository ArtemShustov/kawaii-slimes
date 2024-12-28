using System;
using UnityEngine;

namespace Game.Items {
	[Serializable]
	public class WeaponStack: ItemStack<Weapon> {
		[SerializeField] private float _damageModifier = 1.0f;
		
		public int GetDamage() {
			return Mathf.RoundToInt(Item.Damage * _damageModifier);
		}
	}
}