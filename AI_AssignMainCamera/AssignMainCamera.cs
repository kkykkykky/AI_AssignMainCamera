using System;
using Studio;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace AssignMainCamera
{
    [BepInPlugin(GUID, PLUGINNAME, VERSION)]
    [BepInProcess("StudioNEOV2.exe")]
    public class AssignMainCamera : BaseUnityPlugin
    {
        public const string GUID = "kky.ai.assignmaincamera";
        public const string PLUGINNAME = "AI Assign Main Camera";
        public const string VERSION = "1.0.1";

        private void Awake()
        {
            var harmony = new Harmony(nameof(AssignMainCamera));
            harmony.PatchAll(typeof(AssignMainCamera));
        }

        [HarmonyPatch(typeof(Studio.CameraControl), "Awake")]
        [HarmonyPostfix]
        public static void setMainCamera(Studio.CameraControl __instance)
        {
            if (__instance.mainCmaera == null) __instance.mainCmaera = Camera.main;
        }
    }
}