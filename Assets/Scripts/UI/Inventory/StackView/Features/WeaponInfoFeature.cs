using Core.Items;
using Game.Items;
using TMPro;
using UnityEngine;

namespace Game.UI.Inventory.StackView.Features {
	public class WeaponInfoFeature: ItemStackViewFeature {
		[Header("Settings")]
		[SerializeField] private string _lvlPattern = "LVL: {0}";
		[SerializeField] private string _expPattern = "EXP: {0}/{1}";
		[SerializeField] private string _damagePattern = "DAMAGE: {0}";
		[Header("Components")]
		[SerializeField] private TMP_Text _lvlLabel;
		[SerializeField] private TMP_Text _expLabel;
		[SerializeField] private TMP_Text _damageLabel;
		
		public override void Apply(AbstractItemStack itemStack) {
			if (itemStack is WeaponStack weaponStack) {
				_lvlLabel.text = string.Format(_lvlPattern, weaponStack.GetLevel());
				_expLabel.text = string.Format(_expPattern, 
					weaponStack.Experience, 
					weaponStack.Item.GetUpgradeStage(weaponStack.Experience).Experience, 
					weaponStack.Item.GetMaxExperience()
				);
				_damageLabel.text = string.Format(_damagePattern, weaponStack.GetDamage());
			}
		}
	}
}