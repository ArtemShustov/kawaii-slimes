using System;
using UnityEngine;

namespace Core.UI.Tabs {
	public class Tab: MonoBehaviour {
		public event Action Showed;
		public event Action Closed;
		
		public virtual void Show() {
			gameObject.SetActive(true);
			Showed?.Invoke();
		}
		public virtual void Hide() {
			gameObject.SetActive(false);
			Closed?.Invoke();
		}
	}
}