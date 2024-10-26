using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace CultureResearchPauseFix_NativeModloader
{
    internal class Main : MonoBehaviour
    {
        public static Harmony harmony = new Harmony(MethodBase.GetCurrentMethod().DeclaringType.Namespace);
        private bool _initialized = false;

        public void Update()
        {
            if (global::Config.gameLoaded && !_initialized)
            {
                harmony.Patch(AccessTools.Method(typeof(CultureManager), nameof(CultureManager.updateProgress)), transpiler: new HarmonyMethod(AccessTools.Method(typeof(Patches), nameof(Patches.updateProgress_Transpiler))));

                harmony.Patch(AccessTools.Method(typeof(CultureManager), nameof(CultureManager.updateRecalcValues)), transpiler: new HarmonyMethod(AccessTools.Method(typeof(Patches), nameof(Patches.updateRecalcValues_Transpiler))));

                _initialized = true;
            }
        }
    }
}
