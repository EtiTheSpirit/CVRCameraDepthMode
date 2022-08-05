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
		private const float UPDATE_RATE = 0.5f;

		/// <summary>
		/// The amount of time counted since the last OnUpdate call.
		/// </summary>
		private float _totalDelta = 0;

		public override void OnApplicationStart() {
			Prefs.InitializePrefs();
		}

		public override void OnUpdate() {
			_totalDelta += Time.deltaTime;
			if (_totalDelta >= UPDATE_RATE) {
				_totalDelta = 0;
				Camera.main.depthTextureMode = Prefs.DepthMode;
			}
		}
	}
}
