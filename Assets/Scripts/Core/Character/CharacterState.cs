namespace Core.Character {
	public abstract class CharacterState: AbstractCharacterState, IHasDefaultTransition {
		public abstract AbstractTransition GetDefaultTransition();
	}
}