using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uroboros.Extension;

namespace bloomtown_cheats
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        // description of this mod
        private const string modGUID = "codesprint.bloomtown_cheats";
        private const string modName = "Bloomtown Cheats";
        private const string modVersion = "1.0.0";

        // we need harmony to patch our code into the game
        private readonly Harmony harmony = new Harmony(modGUID);

        // BepInEx configurable values 
        public static ConfigEntry<bool> EnableConsumableStay;
        public static ConfigEntry<bool> EnableMaterialStay;
        public static ConfigEntry<bool> EnableFishStay;
        public static ConfigEntry<bool> EnableLockpickStay;

        void Awake()
        {

            // init BepInEx configuration value
            EnableConsumableStay = Config.Bind(
                "General",              // Config section
                "Infinte consumable Use.",         // Config key
                true,                     // Default value
                "Food, meds and battle items do not decrease when used."       // Description
            );

            EnableMaterialStay = Config.Bind(
                "General",              // Config section
                "Infinte material use.",         // Config key
                true,                     // Default value
                "Materials used in crafting do not decrease when used."       // Description
            );

            EnableFishStay = Config.Bind(
                "General",              // Config section
                "Infinte raw fish use.",         // Config key
                true,                     // Default value
                "Raw fishes do not decrease when cooked or used."       // Description
            );

            EnableLockpickStay = Config.Bind(
               "General",              // Config section
               "Infinte Lockpicks use.",         // Config key
               true,                     // Default value
               "Lockpick amount does not decrease when used."       // Description
           );

            // on init, run patch all to patch our code into the game 
            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(PatchStackable));

            Logger.LogInfo("Bloomtown Cheats Loaded.");


        }

    }
}
