namespace Game.Character {
	public interface IAttackable {
		public void TakeDamage(AbstractCharacter from, int damage);
	}
}