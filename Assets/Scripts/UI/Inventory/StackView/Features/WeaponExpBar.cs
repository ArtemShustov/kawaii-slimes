using Core.Items;
using Game.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Inventory.StackView.Features {
	public class WeaponExpBar: ItemStackViewFeature {
		[SerializeField] private Image _fillImage;
		
		public override void Apply(AbstractItemStack itemStack) {
			if (itemStack is WeaponStack weaponStack) {
				var maxExp = weaponStack.Item.GetMaxExperience();
				_fillImage.fillAmount = maxExp == 0 ? 1 : Mathf.Clamp01((float)weaponStack.Experience / maxExp);
			}
		}
	}
}