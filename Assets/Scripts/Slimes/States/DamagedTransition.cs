using System;
using Core.Character;
using Core.Character.Properties;
using UnityEngine;

namespace Game.Slimes.States {
	[Serializable]
	public class DamagedTransition: Transition {
		[SerializeField] private DamagedState _damagedState;
		[SerializeField] private Health _health;

		private void OnDamaged(AbstractCharacter from, int value) {
			_damagedState.ChangeToThis(attacker: from);
		}
		public override void StartTracking() {
			_health.Damaged += OnDamaged;
		}
		public override void StopTracking() {
			_health.Damaged -= OnDamaged;
		}
	}
}