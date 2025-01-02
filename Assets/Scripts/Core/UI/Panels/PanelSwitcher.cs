using System;
using System.Collections.Generic;
using Core.MVVM;
using UnityEngine;

namespace Core.UI.Panels {
	public class PanelSwitcher: MonoBehaviour {
		private Dictionary<Type, IUIPanel> _panels = new Dictionary<Type, IUIPanel>();
		private IUIPanel _current;

		public IUIPanel Current => _current;
		
		public void Change(IUIPanel panel) {
			_current?.Hide();
			_current = panel;
			_current?.Show();
		}
		public bool Change<TViewModel>(TViewModel viewModel) where TViewModel: IViewModel {
			if (_panels.TryGetValue(typeof(TViewModel), out var panel) && panel is UIPanel<TViewModel> uiPanel) {
				uiPanel.Bind(viewModel);
				Change(panel);
				return true;
			}
			return false;
		}

		public void AddPanel<TViewModel>(UIPanel<TViewModel> panel) where TViewModel: IViewModel {
			if (!_panels.ContainsKey(typeof(TViewModel))){
				_panels.Add(typeof(TViewModel), panel);
			}
		}
		public void RemovePanel<TViewModel>(UIPanel<TViewModel> panel) where TViewModel: IViewModel {
			if (_panels.ContainsKey(typeof(TViewModel))) {
				_panels.Remove(typeof(TViewModel));
			}
		}
	}
}