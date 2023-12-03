using System;
using System.Reflection;
using BS_Utils;
using HarmonyLib;
using IPA;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HiddenBlocks
{
	[Plugin(RuntimeOptions.SingleStartInit)]
	public class Plugin
	{
		public static bool NegativeNoteJumpSpeed;
		private Harmony _harmony;
		public static IPA.Logging.Logger log;

		[Init]
		public void Init(IPA.Logging.Logger logger)
        {
			log = logger;
        }

		[OnStart]
		public void OnApplicationStart()
		{
			Config.Read();
			_harmony = new Harmony("com.kyle1413.beatsaber.hiddenblocks");
			_harmony.PatchAll(Assembly.GetExecutingAssembly());
            BS_Utils.Utilities.BSEvents.gameSceneLoaded += BSEvents_gameSceneLoaded;
            BeatSaberMarkupLanguage.GameplaySetup.GameplaySetup.instance.AddTab("HiddenBlocks", "HiddenBlocks.Resources.ModifiersUI.bsml", ModifierUI.instance);

		}

        private void BSEvents_gameSceneLoaded()
        {
			Config.Read();
			if (!BS_Utils.Plugin.LevelData.IsSet) return;
			Plugin.NegativeNoteJumpSpeed = (BS_Utils.Plugin.LevelData.GameplayCoreSceneSetupData.difficultyBeatmap.noteJumpMovementSpeed < 0f);
		}


		[OnExit]
		public void OnApplicationQuit()
		{
			_harmony.UnpatchSelf();
		}
	}
}
