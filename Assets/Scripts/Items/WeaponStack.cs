using System;
using Core.Items;
using UnityEngine;

namespace Game.Items {
	[Serializable]
	public class WeaponStack: ItemStack<Weapon> {
		private int _experience;
		
		public int Experience => _experience;

		public WeaponStack(Weapon weapon, int experience): base(weapon) {
			_experience = experience;
		}

		public void SetExperience(int experience) {
			_experience = Mathf.Max(0, experience);
		}
		
		public int GetDamage() {
			return Item.GetUpgradeStage(_experience).Damage;
		}
		public int GetLevel() {
			return Item.GetUpgradeStage(_experience).Level;
		}
	}
}