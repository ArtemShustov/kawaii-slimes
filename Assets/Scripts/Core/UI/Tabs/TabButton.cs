using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Tabs {
	public class TabButton: MonoBehaviour {
		[SerializeField] private Tab _tab;
		[SerializeField] private Button _button;
		[SerializeField] private TabSwitcher _switcher;

		private void OnButton() {
			_switcher.Change(_tab);
		}
		private void OnTabClosed() {
			_button.interactable = true;
		}
		private void OnTabShowed() {
			_button.interactable = false;
		}
		private void OnEnable() {
			_button.onClick.AddListener(OnButton);
			_tab.Showed += OnTabShowed;
			_tab.Closed += OnTabClosed;
		}
		private void OnDisable() {
			_button.onClick.RemoveListener(OnButton);
			_tab.Showed -= OnTabShowed;
			_tab.Closed -= OnTabClosed;
		}
	}
}