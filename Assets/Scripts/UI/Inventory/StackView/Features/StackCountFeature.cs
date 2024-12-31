using Core.Items;
using TMPro;
using UnityEngine;

namespace Game.UI.Inventory.StackView.Features {
	public class StackCountFeature: ItemStackViewFeature {
		[SerializeField] private TMP_Text _label;
		
		public override void Apply(AbstractItemStack itemStack) {
			if (itemStack is CountableItemStack countableStack) {
				_label.text = countableStack.Count.ToString();
			} else {
				_label.text = string.Empty;
			}
		}
	}
}