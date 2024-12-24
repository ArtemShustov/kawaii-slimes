using UnityEngine;

namespace Game.Character {
	public class CharacterStateMachine: MonoBehaviour {
		[SerializeField] private CharacterInput _input;
		[SerializeField] private CharacterAnimator _animator;
		[SerializeField] private CharacterController _controller;
		private CharacterState _currentState;

		public CharacterState CurrentState => _currentState;
		public CharacterInput Input => _input;
		public CharacterAnimator Animator => _animator;
		public CharacterController Controller => _controller;

		private void Update() {
			_currentState?.OnUpdate(Time.deltaTime);
		}

		public void Change(CharacterState state) {
			if (!state) {
				Debug.LogWarning("Trying to change state to null");
				return;
			}
			_currentState?.OnExit();
			_currentState = state;
			_currentState.OnEnter();
		}

		public void SetAnimator(CharacterAnimator animator) {
			_animator = animator;
		}
	}
}