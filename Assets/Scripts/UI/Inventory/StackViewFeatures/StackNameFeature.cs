using Core.Items;
using TMPro;
using UnityEngine;

namespace Game.UI.Inventory.StackViewFeatures {
	public class StackNameFeature: ItemStackViewFeature {
		[SerializeField] private TMP_Text _label;
		
		public override void Apply(AbstractItemStack itemStack) {
			_label.text = itemStack.AbstractItem.name;
		}
	}
}