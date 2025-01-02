using Core.UI.Panels;
using UnityEngine;

namespace Game.GameFlow {
	public class WorldStateWithUI: WorldState {
		[Header("UI")]
		[SerializeField] private AbstractUIPanel _panel;
		[SerializeField] private PanelSwitcher _switcher;
		
		private IUIPanel _last;
		
		public override void OnEnter() {
			_last = _switcher.Current;
			_switcher.Change(_panel);
		}
		public override void OnExit() {
			_switcher.Change(_last);
		}
	}
}