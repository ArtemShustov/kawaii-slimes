using Unity.Cinemachine;
using UnityEngine;

namespace Game {
	public class GameCamera: MonoBehaviour {
		[SerializeField] private Camera _camera;
		[SerializeField] private CinemachineInputAxisController _input;

		public Camera Camera => _camera;
		
		public void SetInputActive(bool isActive) {
			_input.enabled = isActive;
		}
		public void SetCursorLock(bool isLocked) {
			Cursor.visible = !isLocked;
			Cursor.lockState = isLocked ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
}