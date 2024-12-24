using UnityEngine;

namespace Game.Accessories {
	public class HandSlot: MonoBehaviour {
		[SerializeField] private GameObject _item;

		public void Put(GameObject item) {
			_item = item;
			_item.transform.SetParent(transform);
			_item.transform.localPosition = Vector3.zero;
			_item.transform.localRotation = Quaternion.identity;
		}
		public GameObject Take() {
			_item.transform.SetParent(transform);
			return _item;
		}
		public void Clear() {
			Destroy(_item.gameObject);
		}
	}
}