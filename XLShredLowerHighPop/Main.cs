using System;
using System.Reflection;
using Harmony12;
using UnityModManagerNet;
using XLShredLib;
using UnityEngine;
using XLShredLib.UI;

namespace XLShredLowerHighPop {
    [Serializable]
    public class Settings : UnityModManager.ModSettings
    {
        public void IncreaseHighPopForce()
        {
            this.HighPopForce += 0.05f;
        }

        public void DecreaseHighPopForce()
        {
            this.HighPopForce -= 0.05f;
        }

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            UnityModManager.ModSettings.Save<Settings>(this, modEntry);
        }

        public float HighPopForce = 0.3f;

    }

    static class Main
    {
        private static bool Load(UnityModManager.ModEntry modEntry)
        {
            Main.settings = UnityModManager.ModSettings.Load<Settings>(modEntry);
            HarmonyInstance.Create(modEntry.Info.Id).PatchAll(Assembly.GetExecutingAssembly());
            modEntry.OnSaveGUI = new Action<UnityModManager.ModEntry>(Main.OnSaveGUI);
            modEntry.OnToggle = new Func<UnityModManager.ModEntry, bool, bool>(Main.OnToggle);
            ModMenu.Instance.gameObject.AddComponent<XLShredLowerHighPop>();
            return true;
        }

        private static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Main.enabled = value;
            return true;
        }

        private static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            Main.settings.Save(modEntry);
        }

        public static bool enabled;

        public static Settings settings;
    }     
}
