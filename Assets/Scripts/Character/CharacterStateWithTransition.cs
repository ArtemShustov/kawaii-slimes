namespace Game.Character {
	public abstract class CharacterStateWithTransition: CharacterState, IHasDefaultTransition {
		public abstract AbstractTransition GetDefaultTransition();
	}
}