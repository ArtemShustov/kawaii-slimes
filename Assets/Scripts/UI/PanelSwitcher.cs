using UnityEngine;

namespace Game.UI {
	public class PanelSwitcher: MonoBehaviour {
		private UIPanel _last;
		private UIPanel _current;

		public UIPanel Current => _current;
		
		public void Change(UIPanel panel) {
			_current?.Hide();
			_last = _current;
			_current = panel;
			_current?.Show();
		}
		public void ShowLast() {
			Change(_last);
		}
	}
}