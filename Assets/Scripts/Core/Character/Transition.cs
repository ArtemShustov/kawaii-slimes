using System;

namespace Core.Character {
	[Serializable]
	public class Transition: AbstractTransition {
		private CharacterStateMachine _character;

		protected CharacterStateMachine Character => _character;

		public void SetCharacter(CharacterStateMachine character) {
			_character = character;
		}

		public override void StartTracking() { }
		public override bool Check() => false;
		public override void StopTracking() { }
	}
}