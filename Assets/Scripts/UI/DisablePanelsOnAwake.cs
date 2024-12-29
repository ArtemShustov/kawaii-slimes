using UnityEngine;

namespace Game.UI {
	public class DisablePanelsOnAwake: MonoBehaviour {
		private void Awake() {
			foreach (var o in transform) {
				var child = (Transform)o;
				if (child.TryGetComponent<UIPanel>(out var panel)) {
					child.gameObject.SetActive(false);
				}
			}
		}
	}
}