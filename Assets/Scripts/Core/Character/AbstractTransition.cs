namespace Core.Character {
	public abstract class AbstractTransition {
		public abstract void StartTracking();
		public abstract bool Check();
		public abstract void StopTracking();
	}
}