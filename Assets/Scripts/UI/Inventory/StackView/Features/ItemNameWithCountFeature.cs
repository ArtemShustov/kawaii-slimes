using Core.Items;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

namespace Game.UI.Inventory.StackView.Features {
	public class ItemNameWithCountFeature: ItemStackViewFeature {
		[SerializeField] private string _stackCountId = "stackCount";
		[SerializeField] private string _stackNameId = "stackName";
		[SerializeField] private LocalizedString _nameWithCount;
		[SerializeField] private LocalizeStringEvent _label;
		
		public override void Apply(AbstractItemStack itemStack) {
			if (itemStack is ICountableStack countableStack) {
				var stackCount = countableStack.Count;
				var itemName = itemStack.AbstractItem.Name.GetLocalizedString();
				SetNameWithCount(stackCount, itemName);
			} else {
				_label.StringReference = itemStack.AbstractItem.Name;
			}
		}
		private void SetNameWithCount(int stackCount, string stackName) {
			var reference = _nameWithCount;
			var countVariable = new IntVariable {
				Value = stackCount
			};
			var nameVariable = new StringVariable {
				Value = stackName
			};
			reference.Add(_stackCountId, countVariable);
			reference.Add(_stackNameId, nameVariable);
			_label.StringReference = reference;
		}
	}
}