using Core.Items;
using TMPro;
using UnityEngine;

namespace Game.UI.Inventory.StackView.Features {
	public class ItemDescriptionFeature: ItemStackViewFeature {
		[SerializeField] private TMP_Text _label;
		
		public override void Apply(AbstractItemStack itemStack) {
			_label.text = itemStack.AbstractItem.Description;
		}
	}
}