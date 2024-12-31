using Core.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Inventory.StackViewFeatures {
	public class StackIconFeature: ItemStackViewFeature {
		[SerializeField] private Image _icon;

		public override void Apply(AbstractItemStack itemStack) {
			_icon.sprite = itemStack.AbstractItem.Icon;
		}
	}
}