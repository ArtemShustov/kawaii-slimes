using UnityEngine;

namespace Game {
	public class LockFPS: MonoBehaviour {
		[SerializeField] private int _targetFrameRate = 60;

		private void Awake() {
			Application.targetFrameRate = _targetFrameRate;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}
	}
}