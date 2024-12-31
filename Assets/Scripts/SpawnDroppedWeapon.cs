using Game.Items;
using UnityEngine;

namespace Game {
	public class SpawnDroppedWeapon: MonoBehaviour {
		[SerializeField] private int _experience;
		[SerializeField] private Weapon _item;
		[SerializeField] private DroppedItemFactory _factory;

		private void Awake() {
			Spawn();
			Destroy(this);
		}

		public void Spawn() {
			var stack = _item.GetStack();
			if (stack is WeaponStack weaponStack) {
				weaponStack.SetExperience(_experience);
			}
			_factory.Spawn(transform, stack);
		}
	}
}