using Core.MVVM;
using Core.UI.Panels;
using Game.Items;
using UnityEngine;

namespace Game.UI.Inventory {
	public class PlayerInventoryPanel: UIPanel, IView<PlayerInventoryViewModel> {
		private PlayerInventoryViewModel _viewModel;
		
		public void Bind(PlayerInventoryViewModel viewModel) {
			_viewModel = viewModel;

			var components = GetComponentsInChildren<PlayerInventoryComponent>(true);
			foreach (var component in components) {
				component.Bind(_viewModel);
			}
		}
	}
}