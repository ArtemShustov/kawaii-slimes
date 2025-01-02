using UnityEngine.UIElements;

namespace Game.UI.Elements {
	[UxmlElement]
	public partial class CommandButton: Button {
		[UxmlAttribute] private string Command { get; set; }

		public CommandButton() {
			clicked += OnClick;
		}

		private void OnClick() {
			var source = dataSource ?? GetHierarchicalDataSourceContext().dataSource;
			source.GetType().GetMethod(Command)?.Invoke(source, null);
		}
	}
}