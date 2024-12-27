using UnityEngine;

namespace Core.Character {
	public class CharacterStateMachine: MonoBehaviour {
		[SerializeField] private CharacterInput _input;
		[SerializeField] private CharacterAnimator _animator;
		[SerializeField] private CharacterController _controller;
		private AbstractCharacterState _currentState;

		public AbstractCharacterState CurrentState => _currentState;
		public CharacterInput Input => _input;
		public CharacterAnimator Animator => _animator;
		public CharacterController Controller => _controller;

		private void Update() {
			_currentState?.OnUpdate(Time.deltaTime);
		}

		public void Change(AbstractCharacterState state) {
			if (!state) {
				return;
			}
			_currentState?.OnExit();
			_currentState = state;
			_currentState.OnEnter();
		}
	}
}