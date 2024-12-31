using UnityEngine;

namespace Core.Items {
	public abstract class Item: ScriptableObject {
		[SerializeField] private string _name;
		[TextArea]
		[SerializeField] private string _description;
		[SerializeField] private Sprite _icon;
		
		public Sprite Icon => _icon;
		public string Name => _name;
		public string Description => _description;

		public abstract AbstractItemStack GetStack();
	}
}