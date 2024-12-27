using UnityEngine;

namespace Game.Items {
	public class Item: ScriptableObject {
		[SerializeField] private Sprite _icon;
		
		public Sprite Icon => _icon;
	}
}