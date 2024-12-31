namespace Core.Items {
	public class CountableItem: Item {
		public CountableItemStack GetStack(int count) {
			return new CountableItemStack(this, count);
		}
	}
}