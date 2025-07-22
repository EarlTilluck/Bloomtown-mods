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
        public static ConfigEntry<bool> EnableWaterCheat;
        public static ConfigEntry<bool> EnableGrowTimeCheat;
        public static ConfigEntry<int> GrowTimeCheatValue;
        public static ConfigEntry<bool> EnableCraftTimeCheat;
        public static ConfigEntry<int> CraftTimeValue;


        public static ManualLogSource Log = BepInEx.Logging.Logger.CreateLogSource("Bloomtown Cheats");

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
               "Lockpicks",              // Config section
               "Infinte Lockpicks use.",         // Config key
               true,                     // Default value
               "Lockpick amount does not decrease when used."       // Description
           );


            EnableWaterCheat = Config.Bind(
               "Garden",              // Config section
               "Plants always watered.",         // Config key
               true,                     // Default value
               "Never need to water plants."       // Description
           );

            EnableGrowTimeCheat = Config.Bind(
               "Garden",              // Config section
               "Enable grow time cheat.",         // Config key
               true,                     // Default value
               "You can set how many minutes for a plant to grow."       // Description
           );

            GrowTimeCheatValue = Config.Bind(
               "Garden",              // Config section
               "Minutes for plants to grow.",         // Config key
               1,                     // Default value
               "How many minutes for a plant to grow."       // Description
           );

            EnableCraftTimeCheat = Config.Bind(
               "Crafting and Cooking",              // Config section
               "Enable craft and cook time cheat.",         // Config key
               true,                     // Default value
               "You can set how many minutes it takes to cook or craft any recipe."       // Description
           );

            CraftTimeValue = Config.Bind(
               "Crafting and Cooking",              // Config section
               "Minutes to cook or craft anything.",         // Config key
               10,                     // Default value
               "How many minutes for any craft or cooking job to finish."       // Description
           );

            // on init, run patch all to patch our code into the game 
            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(PatchStackable));
            harmony.PatchAll(typeof(PatchGarden));
            harmony.PatchAll(typeof(PatchCrafting));

            Log.LogInfo("Bloomtown Cheats Loaded.");


        }

    }
}
