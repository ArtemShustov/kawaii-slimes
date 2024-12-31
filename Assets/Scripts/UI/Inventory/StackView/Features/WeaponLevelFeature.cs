using Core.Items;
using Game.Items;
using TMPro;
using UnityEngine;

namespace Game.UI.Inventory.StackView.Features {
	public class WeaponLevelFeature: ItemStackViewFeature {
		[SerializeField] private string _pattern = "LVL: {0}";
		[SerializeField] private TMP_Text _label;
		
		public override void Apply(AbstractItemStack itemStack) {
			if (itemStack is WeaponStack weaponStack) {
				_label.enabled = true;
				_label.text = string.Format(_pattern, weaponStack.GetLevel());
			} else {
				_label.enabled = false;
			}
		}
	}
}