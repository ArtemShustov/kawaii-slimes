using Game.UI;
using UnityEngine;

namespace Game.GameFlow {
	public class GameStateWithUI: GameState {
		[Header("UI")]
		[SerializeField] private UIPanel _panel;
		[SerializeField] private PanelSwitcher _switcher;

		private UIPanel _last;
		
		public override void OnEnter() {
			_last = _switcher.Current;
			_switcher.Change(_panel);
		}
		public override void OnExit() {
			_switcher.Change(_last);
		}
	}
}