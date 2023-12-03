using System;

namespace HiddenBlocks
{

	internal class Config
	{

		public static float BlockHideDistance = 6.0f;
		public static bool EnableHiddenBlocks = true;

		public static BS_Utils.Utilities.Config ModPrefs = new BS_Utils.Utilities.Config("HiddenBlocks");

		public static void Read()
		{
			Config.EnableHiddenBlocks = ModPrefs.GetBool("HiddenBlocks", "Enabled", false, false);
			Config.BlockHideDistance = ModPrefs.GetFloat("HiddenBlocks", "BlockHideDistance", 6.0f, false);
			bool flag = Config.BlockHideDistance < 4.5f;
			if (flag)
			{
				Config.BlockHideDistance = 4.5f;
			}
		}

		public static void Write()
		{
			ModPrefs.SetBool("HiddenBlocks", "Enabled", Config.EnableHiddenBlocks);
			ModPrefs.SetFloat("HiddenBlocks", "BlockHideDistance", Config.BlockHideDistance);
		}

	}
}
