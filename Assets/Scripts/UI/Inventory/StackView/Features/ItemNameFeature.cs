using Core.Items;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace Game.UI.Inventory.StackView.Features {
	public class ItemNameFeature: ItemStackViewFeature {
		[SerializeField] private LocalizeStringEvent _label;
		
		public override void Apply(AbstractItemStack itemStack) {
			_label.StringReference = itemStack.AbstractItem.Name;
		}
	}
}