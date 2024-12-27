using UnityEngine;

namespace Core.Character {
	public abstract class AbstractCharacterState: MonoBehaviour {
		protected CharacterStateMachine StateMachine { get; private set; }

		public virtual void SetStateMachine(CharacterStateMachine character) {
			StateMachine = character;
		}
		
		public abstract void OnUpdate(float deltaTime);
		
		public abstract void OnEnter();
		public abstract void OnExit();
	}
}