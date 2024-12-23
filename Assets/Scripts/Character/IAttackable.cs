using UnityEngine;

namespace Game.Character {
	public interface IAttackable {
		public void TakeDamage(GameObject from, int damage);
	}
}