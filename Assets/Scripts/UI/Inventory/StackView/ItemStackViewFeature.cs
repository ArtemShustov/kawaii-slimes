using Core.Items;
using UnityEngine;

namespace Game.UI.Inventory.StackView {
	public abstract class ItemStackViewFeature: MonoBehaviour {
		public abstract void Apply(AbstractItemStack itemStack);
	}
}