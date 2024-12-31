namespace Core.Items {
	public class CountableItem: Item {
		public override AbstractItemStack GetStack() {
			return new CountableItemStack(this, 1);
		}
		public CountableItemStack GetStack(int count) {
			return new CountableItemStack(this, count);
		}
	}
}