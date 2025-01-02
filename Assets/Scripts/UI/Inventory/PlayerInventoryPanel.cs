using Core.UI.Panels;

namespace Game.UI.Inventory {
	public class PlayerInventoryPanel: UIPanel<PlayerInventoryViewModel> {
		public override void Bind(PlayerInventoryViewModel viewModel) {
			base.Bind(viewModel);

			foreach (var component in GetComponentsInChildren<IPlayerInventoryComponent>(true)) {
				component.Bind(viewModel);
			}
		}
	}
}