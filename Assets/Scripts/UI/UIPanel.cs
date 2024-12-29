using UnityEngine;

namespace Game.UI {
	public class UIPanel: MonoBehaviour {
		public virtual void Show() {
			gameObject.SetActive(true);
		}
		public virtual void Hide() {
			gameObject.SetActive(false);
		}
	}
}