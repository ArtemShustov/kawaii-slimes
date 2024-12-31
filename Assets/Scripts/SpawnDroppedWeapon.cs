using Core.Events;
using Game.Items;
using UnityEngine;

namespace Game {
	public class SpawnDroppedWeapon: MonoBehaviour {
		[SerializeField] private int _experience;
		[SerializeField] private Weapon _item;

		private void Start() {
			Spawn();
			Destroy(this);
		}

		public void Spawn() {
			var stack = _item.GetStack();
			if (stack is WeaponStack weaponStack) {
				weaponStack.SetExperience(_experience);
			}
			EventBus<ItemDroppedEvent>.Raise(new ItemDroppedEvent(stack, transform.position));
		}
	}
}