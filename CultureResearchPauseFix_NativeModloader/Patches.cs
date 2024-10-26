using HarmonyLib;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace CultureResearchPauseFix_NativeModloader
{
    public static class Patches
    {
        public static IEnumerable<CodeInstruction> updateProgress_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var codes = new List<CodeInstruction>(instructions);

            var label = generator.DefineLabel();

            var newCodes = new List<CodeInstruction>
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(World), "get_world")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(MapBox), "isPaused")),
                new CodeInstruction(OpCodes.Brtrue, label)
            };

            codes.InsertRange(0, newCodes);

            codes.Last().labels.Add(label);

            return codes.AsEnumerable();
        }

        public static IEnumerable<CodeInstruction> updateRecalcValues_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
        {
            var codes = new List<CodeInstruction>(instructions);

            var label = generator.DefineLabel();

            var newCodes = new List<CodeInstruction>
            {
                new CodeInstruction(OpCodes.Call, AccessTools.Method(typeof(World), "get_world")),
                new CodeInstruction(OpCodes.Callvirt, AccessTools.Method(typeof(MapBox), "isPaused")),
                new CodeInstruction(OpCodes.Brtrue, label)
            };

            codes.InsertRange(0, newCodes);

            codes.Last().labels.Add(label);

            return codes.AsEnumerable();
        }
    }
}
