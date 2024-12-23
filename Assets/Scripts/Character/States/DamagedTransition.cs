using System;
using UnityEngine;

namespace Game.Character.States {
	[Serializable]
	public class DamagedTransition: Transition {
		[SerializeField] protected Health _health;

		private void OnDamaged(GameObject from, int damage) {
			if (State is Damaged damaged) {
				damaged.RotateTo(from);
			}
			DoTransit();
		}
		public override void StartTracking() {
			_health.Damaged += OnDamaged;
		}
		public override void StopTracking() {
			_health.Damaged -= OnDamaged;
		}
	}
}