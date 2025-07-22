using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloomtown_cheats
{
    [Harmony]
    class PatchCrafting
    {


        // whenever we get minutes for a craft/cook job, we return our value instead

        [HarmonyPrefix]
        [HarmonyPatch(typeof(CraftWindow), "GetMinutesToCraft")]
        public static void Pre_GetMinutesToCraft(ref Recipe recipe)
        {
            // if not enabled, run original code
            if (Plugin.EnableCraftTimeCheat.Value == false) return;

            // set minutes to our value
            recipe.minutesToCraft = Plugin.CraftTimeValue.Value;

        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(CraftStation), nameof(CraftStation.Craft))]
        public static void Pre_Craft(ref Recipe recipe, ref int count)
        {
            // if not enabled, run original code
            if (Plugin.EnableCraftTimeCheat.Value == false) return;

            // set minutes to our value
            recipe.minutesToCraft = Plugin.CraftTimeValue.Value;

        }
    }
}
