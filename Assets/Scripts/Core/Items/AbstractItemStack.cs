using System;

namespace Core.Items {
	[Serializable]
	public abstract class AbstractItemStack {
		public abstract Item AbstractItem { get; }
	}
}