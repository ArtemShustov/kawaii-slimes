using Core.Character;
using Game.Accessories;
using Game.Items;
using UnityEngine;

namespace Game.Player {
	public class PlayerCharacter: AbstractCharacter {
		[SerializeField] private Transform _cameraTarget;
		[Header("Components")]
		[SerializeField] private PlayerInput _input;
		[Header("Accessories")]
		[SerializeField] private HatSlot _hatSlot;
		[SerializeField] private WeaponSlot _weaponSlot;

		public Transform CameraTarget => _cameraTarget;

		public void SetInputActive(bool isActive) {
			_input.enabled = isActive;
		} 
	}
}