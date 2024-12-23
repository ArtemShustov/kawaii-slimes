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
			// Debug.Log($"State changing: '{_currentState?.GetType().Name ?? "null"}' -> '{state.GetType().Name}'");
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

		private void OnGUI() {
			var style = new GUIStyle();
			style.alignment = TextAnchor.UpperCenter;
			style.fontSize = 36;
			
			var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
			if (screenPosition.z > 0) {
				var rect = new Rect(screenPosition.x, Screen.height - screenPosition.y, 0, 0);
				GUI.Label(rect, $"State: {_currentState?.GetType().Name}", style);
			}
		}
	}
}