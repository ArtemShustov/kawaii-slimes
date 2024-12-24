using UnityEngine;
using UnityEngine.InputSystem;

namespace Game {
	public class TestSwitchWeapon: MonoBehaviour {
		[SerializeField] private InputAction _button = new InputAction(
			name: "Button",
			type: InputActionType.Button,
			binding: "<Gamepad>/buttonNorth"
		);
		[SerializeField] private Animator _animator;

		private void OnButton(InputAction.CallbackContext obj) {
			var hasWeapon = _animator.GetBool("HasWeapon");
			_animator.SetBool("HasWeapon", !hasWeapon);
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