using System;
using Game.Items;
using Unity.Properties;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace Game.UI.Inventory.Modern {
	[Serializable]
	public class WeaponStackViewModel: ItemStackViewModel {
		[CreateProperty] public override string Label => $"LVL. {_weapon.GetLevel()}";
		[CreateProperty] public int Damage => _weapon.GetDamage();
		[CreateProperty] public string LvlWithMax => $"{_weapon.GetLevel()}/{_weapon.Item.GetMaxLevel()}";
		[CreateProperty] public string ExpWithMax => $"{_weapon.Experience}/{_weapon.Item.GetMaxExperience()}";
		[CreateProperty] public virtual bool CanUpgrade => _weapon.Experience < _weapon.Item.GetMaxExperience();

		private WeaponStack _weapon;

		public WeaponStack Weapon => _weapon;
		
		public WeaponStackViewModel(WeaponStack stack): base(stack) {
			_weapon = stack;
		}
	}
}