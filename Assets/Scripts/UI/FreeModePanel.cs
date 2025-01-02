using Core.UI.Panels;

namespace Game.UI {
	public class FreeModePanel: AbstractUIPanel {
		public override void Show() {
			gameObject.SetActive(true);
		}
		public override void Hide() {
			gameObject.SetActive(false);
		}
	}
}