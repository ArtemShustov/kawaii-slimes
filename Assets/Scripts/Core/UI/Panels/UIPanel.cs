using UnityEngine;

namespace Core.UI.Panels {
	public class UIPanel: MonoBehaviour {
		public virtual void Show() {
			gameObject.SetActive(true);
		}
		public virtual void Hide() {
			gameObject.SetActive(false);
		}
	}
}