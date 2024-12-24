using System;
using UnityEngine;

namespace Game.Character.States {
	[Serializable]
	public class DamagedTransition: AbstractTransition {
		[SerializeField] protected Health _health;
		private Damaged _state;
		private CharacterStateMachine _machine;
		
		public void Init(CharacterStateMachine machine, Damaged damaged) {
			_state = damaged;
			_machine = machine;
		}
		
		private void OnDamaged(AbstractCharacter from, int damage) {
			if (from) {
				_state.RotateTo(from.gameObject);
			}
			_machine.Change(_state);
		}
		public override void StartTracking() {
			_health.Damaged += OnDamaged;
		}
		public override void StopTracking() {
			_health.Damaged -= OnDamaged;
		}
		public override bool Check() => false;
	}
}