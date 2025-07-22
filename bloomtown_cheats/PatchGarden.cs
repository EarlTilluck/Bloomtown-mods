using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace bloomtown_cheats
{
    [Harmony]
    class PatchGarden
    {

        // on update grow progress...
        // set the last watered time to now, so you never need to water plants

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Garden), nameof(Garden.UpdateGrowProgress))]
        public static void Pre_UpdateGrowProgress(ref Garden __instance)
        {
            if (Plugin.EnableWaterCheat.Value == false) return;

            // set the last watered time to now
            FieldInfo lastWatered = AccessTools.Field(typeof(Garden), "m_lastWatered");
            lastWatered.SetValue(__instance, DateTimeManager.instance.DateTime);
        }


        // whenever the game want to find how long for a crop to grow, use our value instead.

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Seed), nameof(Seed.GetMinutesToMature))]
        public static bool Pre_GetMinutesToMature(ref int __result, ref Fertilizer fertilizer)
        {
            if (Plugin.EnableGrowTimeCheat.Value == false) return true;

            __result = Plugin.GrowTimeCheatValue.Value;
            return false;

        }

    }

}

