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

		private Camera _lastKnownMainCamera = null;

		public override void OnApplicationStart() {
			Prefs.InitializePrefs();
		}

		public override void OnUpdate() {
			_totalDelta += Time.deltaTime;
			if (_totalDelta >= UPDATE_DELAY) {
				_totalDelta = 0;

				// TODO: Camera.current? The VRC mod I made for my avatar used Camera.main so I will use that here too.
				// NOTE: I place this code here (in the if statement) because according to unity, indexing Camera.main is "not cheap"
				// Quote: "Accessing this property has a small CPU overhead, comparable to calling GameObject.GetComponent.
				//			Where CPU performance is important, consider caching this property."
				if (_lastKnownMainCamera == null || _lastKnownMainCamera.gameObject == null) {
					// afaik Unity will return true on ==null if the Camera has been destroyed
					// but just to be safe I want to check gameObject too. I do not know if this is necessary.

					Camera mainCamera = Camera.main;
					if (mainCamera == null) return;
					_lastKnownMainCamera = mainCamera;
				}

				_lastKnownMainCamera.depthTextureMode = Prefs.DepthMode;
			}
		}
	}
}
