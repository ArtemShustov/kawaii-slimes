using Core.Items;
using Game.Items;
using Unity.Properties;
using UnityEngine;

namespace Game.UI.Inventory.Modern {
	public class UpgradeWeaponViewModel: WeaponStackViewModel {
		[CreateProperty] public int SliderMin { get; private set; } = 0;
		[CreateProperty] public int SliderMax {
			get {
				var exp = Weapon.Item.GetMaxExperience() - Weapon.Experience;
				return Mathf.Min(GetAvailableResources(), exp);
			}
		}
		[CreateProperty] public int SliderValue {
			get => _sliderValue;
			set {
				_sliderValue = value;
				_required.SetCount(value);
			}
		}
		[CreateProperty] public override bool CanUpgrade => base.CanUpgrade && SliderValue != 0 && HaveEnoughResources();

		private int _sliderValue = 0;
		private readonly Core.Items.Inventory _source;
		private readonly CountableItemStack _required;
		
		public UpgradeWeaponViewModel(WeaponStack stack, Core.Items.Inventory source, CountableItemStack required): base(stack) {
			_source = source;
			_required = required;
			required.SetCount(SliderValue);
		}

		private bool HaveEnoughResources() {
			return GetAvailableResources() >= SliderValue;
		}
		private int GetAvailableResources() {
			return _source.GetCountOf(_required.Item);
		}
		
		#region Commands
		public void UpgradeWeapon() {
			if (_source.Take(_required.Item, SliderValue)) {
				Weapon.SetExperience(Weapon.Experience + SliderValue);
				SliderValue = 0;
			}
		}
		public void SliderIncrease() {
			SliderValue = Mathf.Clamp(SliderValue + 1, SliderMin, SliderMax);
		}
		public void SliderDecrease() {
			SliderValue = Mathf.Clamp(SliderValue - 1, SliderMin, SliderMax);
		}
		#endregion
	}
}