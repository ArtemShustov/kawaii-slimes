using Core.Items;
using TMPro;
using UnityEngine;

namespace Game.UI.Inventory.StackViewFeatures {
	public class StackNameWithCountFeature: ItemStackViewFeature {
		[SerializeField] private string _pattern = "{1} of {0}";
		[SerializeField] private TMP_Text _label;
		
		public override void Apply(AbstractItemStack itemStack) {
			if (itemStack is ICountableStack countableStack) {
				_label.text = string.Format(_pattern, itemStack.AbstractItem.name, countableStack.Count);
			} else {
				_label.text = itemStack.AbstractItem.name;
			}
		}
	}
}