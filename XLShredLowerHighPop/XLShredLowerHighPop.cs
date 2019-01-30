using UnityEngine;
using XLShredLib;
using XLShredLib.UI;

using System;

namespace XLShredLowerHighPop
{
    internal class XLShredLowerHighPop : MonoBehaviour
    {
        public void Start()
        {
            ModUIBox modUIBox = ModMenu.Instance.RegisterModMaker("OneShot", "OneShot", 0);
            modUIBox.AddLabel(", / . - Adjust High Pop Force", 0, () => Main.enabled, 0);
        }

        public void Update()
        {
            if (Main.enabled)
            {
                ModMenu.Instance.KeyPress(46, 0.2f, delegate ()
                {
                    Main.settings.IncreaseHighPopForce();
                    ModMenu.Instance.ShowMessage("High Pop Force: " + Main.settings.HighPopForce + " Default: 0.75");
                });
                ModMenu.Instance.KeyPress(44, 0.2f, delegate ()
                {
                    Main.settings.DecreaseHighPopForce();
                    ModMenu.Instance.ShowMessage("High Pop Force: " + Main.settings.HighPopForce + " Default: 0.75");
                });
            }
        }
    }
}
namespace XLShredLowerHighPop.Patches
{
    [HarmonyPatch(typeof(PlayerState_Setup), "OnNextState")]
    internal static class PlayerState_SetUp_OnNextState_Patch
    {
        private static void Prefix(ref float ____highPoPForce)
        {
            if (Main.enabled)
            {
                ____highPopForce = Main.settings.customHighPopForce;
            }
        }
    }
}
