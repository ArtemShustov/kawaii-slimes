using UnityEngine;

namespace Core.UI.Panels {
	public abstract class AbstractUIPanel: MonoBehaviour, IUIPanel {
		public abstract void Show();
		public abstract void Hide();
	}
}