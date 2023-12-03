using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Util;

namespace HiddenBlocks
{
    public class ModifierUI : NotifiableSingleton<ModifierUI>
    {
        [UIValue("hiddenToggle")]
        public bool hiddenToggle
        {
            get => Config.EnableHiddenBlocks;
            set
            {
                Config.EnableHiddenBlocks = value;
                Config.Write();
            }
        }
        [UIAction("setHiddenToggle")]
        void SetHidden(bool value)
        {
            hiddenToggle = value;
        }
        [UIValue("hiddenDistance")]
        public float hiddenDistance
        {
            get => Config.BlockHideDistance;
            set
            {
                Config.BlockHideDistance = value;
                if (Config.BlockHideDistance < 4.5f)
                {
                    Config.BlockHideDistance = 4.5f;
                }
                Config.Write();
            }
        }
        [UIAction("setHideDistance")]
        void SetDistance(float value)
        {
            hiddenDistance = value;
        }
        [UIAction("distanceFormatter")]
        string distanceForValue(float value)
        {
            return value.ToString("F1") + "m";
        }

    }
}
