﻿using UnityEngine;
using XLShredLib;
using XLShredLib.UI;

using System;

namespace XLShredRespawnNearBail {
    class XLShredRespawnNearBail : MonoBehaviour {
        ModUIBox uiBox;
        ModUILabel uiLabelRespawnNearBail;
        public void Start() {
            uiBox = ModMenu.Instance.RegisterModMaker("com.kiwi", "Kiwi");
            uiLabelRespawnNearBail = uiBox.AddLabel(LabelType.Toggle, "Respawn Near Bail (R)", Side.left, () => Main.enabled, Main.settings.respawnNearBail && Main.enabled, (b) => Main.settings.respawnNearBail = b);
        }

        public void Update() {
            if (Main.enabled) {
                ModMenu.Instance.KeyPress(KeyCode.R, 0.2f, () => {
                    Main.settings.respawnNearBail = !Main.settings.respawnNearBail;
                    uiLabelRespawnNearBail.SetToggleValue(Main.settings.respawnNearBail);
                    if (Main.settings.respawnNearBail) {
                        ModMenu.Instance.ShowMessage("Respawn Near Bail: ON");
                    } else {
                        ModMenu.Instance.ShowMessage("Respawn Near Bail: OFF");
                    }
                });
            }
        }
    }
}
