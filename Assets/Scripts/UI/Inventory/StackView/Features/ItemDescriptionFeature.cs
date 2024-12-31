using Core.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

namespace Game.UI.Inventory.StackView.Features {
	public class ItemDescriptionFeature: ItemStackViewFeature {
		[SerializeField] private LocalizeStringEvent _label;
		
		public override void Apply(AbstractItemStack itemStack) {
			_label.StringReference = itemStack.AbstractItem.Description;
		}
	}
}