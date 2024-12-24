using System;
using UnityEngine;

namespace Game.Character {
	[Serializable]
	public class Transition: AbstractTransition {
		private CharacterState _state;
		private CharacterStateMachine _character;

		protected CharacterStateMachine Character => _character;
		protected CharacterState State => _state;

		public void Init(CharacterStateMachine character, CharacterState state) {
			_character = character;
			_state = state;
		}

		protected void DoTransit() {
			_character.Change(_state);
		}

		public override void StartTracking() { }
		public override bool Check() => false;
		public override void StopTracking() { }
	}

	public abstract class AbstractTransition {
		public abstract void StartTracking();
		public abstract bool Check();
		public abstract void StopTracking();
	}
}