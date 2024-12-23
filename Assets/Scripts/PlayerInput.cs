using System;
using Game.Character;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game {
	public class PlayerInput: MonoBehaviour {
		[SerializeField] private InputAction _move = new InputAction(
			name: "Move", 
			type: InputActionType.Value, 
			binding: "<Gamepad>/leftStick"
		);
		[SerializeField] private InputAction _attack = new InputAction(
			name: "Attack",
			type: InputActionType.Button,
			binding: "<Gamepad>/buttonWest"
		);
		[SerializeField] private CharacterInput _input;

		private void Update() {
			_input.Move = _move.ReadValue<Vector2>().normalized;
		}

		private void OnAttack(InputAction.CallbackContext obj) {
			_input.InvokeAttack();
		}
		private void OnEnable() {
			_move.Enable();
			_attack.Enable();
			_attack.performed += OnAttack;
		}
		private void OnDisable() {
			_move.Disable();
			_attack.Disable();
			_attack.performed -= OnAttack;
		}
	}
}