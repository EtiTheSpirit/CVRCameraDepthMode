using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DepthModeMod {
	public class DepthMode : MelonMod {

		/// <summary>
		/// The frequency at which <see cref="Camera.main"/> is referenced and has its depth mode updated.
		/// </summary>
		private const float UPDATE_DELAY = 0.5f;

		/// <summary>
		/// The amount of time counted since the last OnUpdate call.
		/// This is lazier than caching the information of the last user-set mode, but makes it resistant
		/// </summary>
		private float _totalDelta = 0;

		public override void OnApplicationStart() {
			Prefs.InitializePrefs();
		}

		public override void OnUpdate() {
			// TODO: Camera.current? The VRC mod I made for my Seeker used Camera.main so I will use that here too.
			Camera mainCamera = Camera.main;
			if (mainCamera == null) return;

			_totalDelta += Time.deltaTime;
			if (_totalDelta >= UPDATE_DELAY) {
				_totalDelta = 0;
				mainCamera.depthTextureMode = Prefs.DepthMode;
			}
		}
	}
}
