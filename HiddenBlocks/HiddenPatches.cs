using System;
using HarmonyLib;

namespace HiddenBlocks
{
	// Token: 0x02000005 RID: 5
	[HarmonyPatch(typeof(BeatmapObjectManager))]
	[HarmonyPatch("SetNoteControllerEventCallbacks", MethodType.Normal)]
	public class HiddenPatches
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000020FC File Offset: 0x000002FC
		public static void Postfix(NoteController noteController)
		{
			if (Config.EnableHiddenBlocks && !noteController.GetComponent<HiddenBlock>())
			{
				noteController.gameObject.AddComponent<HiddenBlock>();
			}
		}
	}
}
