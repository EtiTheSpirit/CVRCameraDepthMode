using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;

namespace DepthModeMod {
	public class Prefs {

		private static MelonPreferences_Category _settingsCategory { get; set; }

		/// <summary>
		/// The current user-defined depth texture mode based on their preferences.
		/// This property is computed every time it is referenced.
		/// </summary>
		public static DepthTextureMode DepthMode {
			get {
				DepthTextureMode mode = DepthTextureMode.None;
				if (_settingsCategory == null) return mode;
				if (_settingsCategory.GetEntry<bool>("ExposeDepth").Value) mode |= DepthTextureMode.Depth;
				if (_settingsCategory.GetEntry<bool>("ExposeNormals").Value) mode |= DepthTextureMode.DepthNormals;
				if (_settingsCategory.GetEntry<bool>("ExposeMotion").Value) mode |= DepthTextureMode.MotionVectors;
				return mode;
			}
		}

		/// <summary>
		/// Called by the mod to create the default preferences.
		/// </summary>
		public static void InitializePrefs() {
			_settingsCategory = MelonPreferences.CreateCategory("Depth Mode Setter");
			_settingsCategory.CreateEntry("ExposeDepth", true, "Expose Depth", "If true, the Depth Texture is enabled.");
			_settingsCategory.CreateEntry("ExposeNormals", false, "Expose Depth Normals", "If true, the Depth Normals Texture is enabled.");
			_settingsCategory.CreateEntry("ExposeMotion", false, "Expose Motion Vectors", "If true, the Motion Vectors Texture is enabled.");
			_settingsCategory.SaveToFile();
		}

	}
}
