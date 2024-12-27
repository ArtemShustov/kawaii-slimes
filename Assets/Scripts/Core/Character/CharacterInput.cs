using System;
using UnityEngine;

namespace Core.Character {
	public class CharacterInput: MonoBehaviour {
		[SerializeField] private bool _cameraRelated = true;
		
		public Vector2 Move { get; set; }
		public event Action Attack;

		public Vector2 GetRelatedMove() {
			if (!_cameraRelated) {
				return Move;
			}
			
			var input = Move;
			var camera = Camera.main;

			var directionAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
			if (directionAngle < 0) {
				directionAngle += 360;
			}
			directionAngle += camera.transform.eulerAngles.y;
			if (directionAngle > 360) {
				directionAngle -= 360;
			}
			var forward = Quaternion.Euler(0, directionAngle, 0) * Vector3.forward;
			var result = forward * input.magnitude;
			return new Vector2(result.x, result.z);
		}
		
		public void InvokeAttack() => Attack?.Invoke();
	}
}