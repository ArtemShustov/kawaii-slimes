using UnityEngine;

namespace Core.UI.Tabs {
	public class TabSwitcher: MonoBehaviour {
		[SerializeField] private Tab[] _tabs;
		[Header("Settings")]
		[SerializeField] private bool _autoOpen = true;
		
		private Tab _current;

		private void Awake() {
			foreach (var tab in _tabs) {
				tab.gameObject.SetActive(false);
			}
		}
		
		public void Change(Tab tab) {
			_current?.Hide();
			_current = tab;
			_current?.Show();
		}
		
		private void OnEnable() {
			if (_autoOpen) {
				Change(_tabs[0]);
			}
		}
	}
}