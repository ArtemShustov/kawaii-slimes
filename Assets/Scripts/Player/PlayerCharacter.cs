using Core.Character;
using Game.Accessories;
using Game.Items;
using UnityEngine;

namespace Game.Player {
	public class PlayerCharacter: AbstractCharacter {
		[SerializeField] private Transform _cameraTarget;
		[Header("Accessories")]
		[SerializeField] private HatSlot _hatSlot;
		[SerializeField] private WeaponSlot _weaponSlot;

		public Transform CameraTarget => _cameraTarget;
	}
}