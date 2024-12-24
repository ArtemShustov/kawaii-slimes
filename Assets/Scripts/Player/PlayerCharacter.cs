using Game.Character;
using UnityEngine;

namespace Game.Player {
	public class PlayerCharacter: AbstractCharacter {
		[SerializeField] private Transform _cameraTarget;

		public Transform CameraTarget => _cameraTarget;
	}
}