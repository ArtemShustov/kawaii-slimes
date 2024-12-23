using Game.Character;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game {
	public class CharacterModelChanger: MonoBehaviour {
		[SerializeField] private InputAction _button = new InputAction(
			name: "Change",
			type: InputActionType.Button,
			binding: "<Keyboard>/c"
		);
		[SerializeField] private CharacterAnimator[] _list;
		[SerializeField] private CharacterStateMachine _character;
		
		private int _current;

		private void Awake() {
			foreach (var animator in _list) {
				animator.gameObject.SetActive(false);
			}
			SetAnimator(_list[0]);
		}
		
		private void SetAnimator(CharacterAnimator newAnimator) {
			newAnimator.gameObject.SetActive(true);
			_character.SetAnimator(newAnimator);
			if (_character.CurrentState) {
				_character.Change(_character.CurrentState);
			}
		}

		private void OnButton(InputAction.CallbackContext obj) {
			_current = _current >= _list.Length - 1 ? 0 : _current + 1;
			_character.Animator.gameObject.SetActive(false);
			
			SetAnimator(_list[_current]);
		}
		private void OnEnable() {
			_button.Enable();
			_button.performed += OnButton;
		}
		private void OnDisable() {
			_button.Disable();
			_button.performed -= OnButton;
		}
	}
}