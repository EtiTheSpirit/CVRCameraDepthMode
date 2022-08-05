# Camera Depth Mode
Note: This mod is incredibly niche, and is directed towards avatar creators that write custom shaders. It has little use outside of this purpose.

## Wait: An Important Notice
This mod and its author is **not affiliated with AB Interactive, and this is unofficial content.** DO NOT report errors with rendering and shaders to them while this mod is installed!! 

**ALWAYS UNINSTALL MODS *BEFORE* MAKING BUG REPORTS TO DEVELOPERS.** Failure to do so can mean **wasting time that devs could be spending on fixing actual, real bugs**, by luring them in with *something that isn't even caused by their game in the first place.* Don't be the that-guy in their support tickets. Be smart - test first, then report.

## Details

The Camera Depth Mode mod allows switching certain depth texture flags of the local camera on or off, as an alternative to adding a Directional Light instance to the avatar, which may introduce extra shading overhead on some remote clients' avatars depending on the world and the shaders they use.

This mod has three preferences to configure:
* <strong>Expose Depth</strong>: If enabled, the Depth Texture is exposed to shaders via unity's `_CameraDepthTexture`
* <strong>Expose Depth Normals</strong>: If enabled, the normals of objects (in view space) are exposed as well.
* <strong>Expose Motion Vectors</strong>: If enabled, per-pixel motion of each texel is packed into a texture and exposed.

