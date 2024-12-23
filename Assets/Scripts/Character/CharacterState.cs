using UnityEngine;

namespace Game.Character {
	public abstract class CharacterState: MonoBehaviour {
		protected CharacterStateMachine StateMachine { get; private set; }

		public virtual void SetCharacter(CharacterStateMachine character) {
			StateMachine = character;
		}
		
		public abstract void OnUpdate(float deltaTime);
		
		public abstract void OnEnter();
		public abstract void OnExit();
	}
}