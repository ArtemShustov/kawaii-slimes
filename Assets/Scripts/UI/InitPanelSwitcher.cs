using UnityEngine;

namespace Game.UI {
	public class InitPanelSwitcher: MonoBehaviour {
		[SerializeField] private UIPanel _default;
		[SerializeField] private PanelSwitcher _switcher;

		private void Start() {
			_switcher.Change(_default);
		}
	}
}