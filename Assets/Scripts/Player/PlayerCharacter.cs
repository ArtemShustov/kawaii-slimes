using Core.Character;
using UnityEngine;

namespace Game.Player {
	public class PlayerCharacter: AbstractCharacter {
		[SerializeField] private Transform _cameraTarget;
		[Header("Components")]
		[SerializeField] private PlayerInput _input;
		[Header("Slots")]
		[SerializeField] private WeaponSlot _weaponSlot;

		public Transform CameraTarget => _cameraTarget;
		public WeaponSlot WeaponSlot => _weaponSlot;

		public void SetInputActive(bool isActive) {
			_input.enabled = isActive;
		} 
	}
}