using System;
using UnityEngine;

namespace Game.Effects {
	public class PartyHat : MonoBehaviour {
		[SerializeField] private Transform _model;

		private void Awake() {
			if (_model != null) {
				DateTime currentDate = DateTime.Now;
				bool isPartyDay = currentDate.Month == 12 && currentDate.Day == 26;
				_model.gameObject.SetActive(isPartyDay);
			}
		}
	}
}