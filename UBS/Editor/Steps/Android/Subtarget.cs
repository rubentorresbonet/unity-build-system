using UnityEngine;
using System.Collections;
using UnityEditor;

namespace UBS.Android
{
	[BuildStepPlatformFilterAttribute(BuildTarget.Android)]
	[BuildStepDescriptionAttribute("Sets the subtarget (texture compression type) for android. Values: Generic, DXT, PVRTC,	ATC, ETC, ETC2, ASTC")]
#if !UNITY_5
	[BuildStepParameterFilterAttribute(typeof(AndroidBuildSubtarget))]
#else
	[BuildStepParameterFilterAttribute(typeof(MobileTextureSubtarget))]
#endif
	public class Subtarget : IBuildStepProvider
	{
		#region IBuildStepProvider implementation
		
		public void BuildStepStart (BuildConfiguration pConfiguration)
		{
#if !UNITY_5
			EditorUserBuildSettings.androidBuildSubtarget = (AndroidBuildSubtarget)System.Enum.Parse(typeof(AndroidBuildSubtarget),pConfiguration.Params);
#else
			EditorUserBuildSettings.androidBuildSubtarget = (MobileTextureSubtarget)System.Enum.Parse(typeof(MobileTextureSubtarget),pConfiguration.Params);
#endif
		}
		
		public void BuildStepUpdate ()
		{
		}
		
		public bool IsBuildStepDone ()
		{
			return true;
		}
		
		#endregion
	}
}

