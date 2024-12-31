using UnityEngine;
using UnityEngine.Localization;

namespace Core.Items {
	public abstract class Item: ScriptableObject {
		[SerializeField] private LocalizedString _name;
		[SerializeField] private LocalizedString _description;
		[SerializeField] private Sprite _icon;
		
		public Sprite Icon => _icon;
		public LocalizedString Name => _name;
		public LocalizedString Description => _description;

		public abstract AbstractItemStack GetStack();
	}
}