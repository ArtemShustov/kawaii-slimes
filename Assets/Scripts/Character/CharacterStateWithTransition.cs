namespace Game.Character {
	public abstract class CharacterStateWithTransition: CharacterState, IHasDefaultTransition {
		public abstract Transition GetDefaultTransition();
	}
}