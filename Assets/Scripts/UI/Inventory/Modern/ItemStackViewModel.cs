using Core.Events;
using Core.Items;
using Unity.Properties;
using UnityEngine;

namespace Game.UI.Inventory.Modern {
	public class ItemStackViewModel {
		[CreateProperty] public virtual string Name => Stack.AbstractItem.Name.GetLocalizedString();
		[CreateProperty] public virtual Sprite Icon => Stack.AbstractItem.Icon;
		[CreateProperty] public virtual string Label => Stack is CountableItemStack countable ? countable.Count.ToString() : "-";
		[CreateProperty] public virtual string Description => Stack.AbstractItem.Description.GetLocalizedString();
		
		protected AbstractItemStack Stack { get; private set; }

		public ItemStackViewModel(AbstractItemStack stack) {
			Stack = stack;
		}

		public void SelectStack() {
			EventBus<ItemStackSelectedEvent>.Raise(new ItemStackSelectedEvent(Stack));
		}
	}
}