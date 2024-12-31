using UnityEngine;

namespace Core.Items {
	public class ItemStackFilter: MonoBehaviour {
		public virtual bool Check(AbstractItemStack stack) => true;
	}
}