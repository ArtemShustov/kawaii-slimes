using UnityEngine;

namespace Core.UI.Panels {
	public class DisablePanelsOnAwake: MonoBehaviour {
		private void Awake() {
			foreach (Transform child in transform) {
				if (child.TryGetComponent<UIPanel>(out var panel)) {
					child.gameObject.SetActive(false);
				}
			}
		}
	}
}