using System;
using UnityEngine;

namespace Game {
	[Obsolete("For testing purposes only")]
	public class LockFPS: MonoBehaviour {
		[SerializeField] private int _targetFrameRate = 60;

		private void Awake() {
			Application.targetFrameRate = _targetFrameRate;
		}
	}
}