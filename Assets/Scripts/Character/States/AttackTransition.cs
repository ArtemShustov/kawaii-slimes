using System;

namespace Game.Character.States {
	[Serializable]
	public class AttackTransition: Transition {
		private void OnAttack() {
			DoTransit();
		}
		
		public override void StartTracking() {
			Character.Input.Attack += OnAttack;
		}
		public override void StopTracking() {
			Character.Input.Attack -= OnAttack;
		}
	}
}