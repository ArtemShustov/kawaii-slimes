using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.GameFlow {
	public class ChangeStateOnButton: MonoBehaviour {
		[SerializeField] private WorldState _state;
		[SerializeField] private WorldStateMachine _machine;
		[SerializeField] private InputAction _button = new InputAction(
			name: "Button",
			type: InputActionType.Button
		);

		private void OnButton(InputAction.CallbackContext obj) {
			_machine.Change(_state);
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