using System;
using UnityEngine;

namespace Game.Character {
	[Serializable]
	public class Transition {
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
		
		public virtual void StartTracking() {}
		public virtual bool Check() => false;
		public virtual void StopTracking() {}
	}
}