using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Uroboros.Extension;

namespace bloomtown_cheats
{
    [Harmony]
    class PatchStackable
    {

        public static List<string> consumables = new List<string>
        {
            "Apple",
            "AppleJelly",
            "Banana",
            "BananaChips",
            "CentralFish1_Cooked",
            "CentralFish2_Cooked",
            "CentralFish3_Cooked",
            "CentralFish4_Cooked",
            "Cheeseburger",
            "Chips",
            "ChocolateBar",
            "Coffee",
            "CommonFish1_Cooked",
            "CommonFish2_Cooked",
            "CommonFish3_Cooked",
            "CraftMaterial_butter",
            "Deer's Pleasure",
            "Demon_Catcher",
            "Doughnut",
            "Down_bomb",
            "Electric_bomb",
            "FarmFish1_Cooked",
            "FarmFish2_Cooked",
            "FarmFish3_Cooked",
            "FarmFish4_Cooked",
            "Fire_bomb",
            "ForestFish1_Cooked",
            "ForestFish2_Cooked",
            "ForestFish3_Cooked",
            "ForestFish4_Cooked",
            "Free_Candy",
            "Freeze_bomb",
            "Fried Bread",
            "FriedChicken",
            "FriedEggs",
            "GenericLollipop",
            "GummyBear",
            "Heal_all",
            "HotDog",
            "IceCream",
            "LiocoriceCandy",
            "MintCandy",
            "Orange",
            "OrangeJuice",
            "Revival Bead",
            "Revival_Basic",
            "Revive_All",
            "Smoke_screen",
            "Soda",
            "Status_healer",
            "Wooze_bomb",
            "Yakisoba Pan"
        };

        public static List<string> materials = new List<string>
        {
            "Bait",
            "CraftMaterial_cabbage",
            "CraftMaterial_chicken",
            "DaisyFlower",
            "demonic_cow_milk",
            "demonic_dressing",
            "CraftMaterial_eggs",
            "CraftMaterial_ketchup",
            "laxative",
            "Licorice",
            "Material_Tier_1",
            "Material_Tier_2",
            "Material_Tier_3",
            "Mint",
            "purple_tentacles",
            "Sugar",
            "SweetCorn",
            "CraftMaterial_tomatoes",
            "CraftMaterial_wheat",
        };

        public static List<string> fishes = new List<string>
        {
            "CentralFish1",
            "CentralFish2",
            "CentralFish3",
            "CentralFish4",
            "CommonFish1",
            "CommonFish2",
            "CommonFish3",
            "FarmFish1",
            "FarmFish2",
            "FarmFish3",
            "FarmFish4",
            "ForestFish1",
            "ForestFish2",
            "ForestFish3",
            "ForestFish4"
        };

        public const string lockpick = "Lockpick";

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Stackable), nameof(Stackable.Take))]
        public static void Pre_Stackable_Take(ref Stackable __instance, ref int amount)
        {

            ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("Logger");
            string id = __instance.uid;

            // if cheat enbabled...
            if (Plugin.EnableConsumableStay.Value == true)
            {
                if (consumables.Contains(id))
                {
                    __instance.Add(amount);
                }
            }
            if (Plugin.EnableMaterialStay.Value == true)
            {
                if (materials.Contains(id))
                {
                    __instance.Add(amount);
                }
            }
            if (Plugin.EnableFishStay.Value == true)
            {
                if (fishes.Contains(id))
                {
                    __instance.Add(amount);
                }
            }
            if (Plugin.EnableLockpickStay.Value == true)
            {
                if (id == lockpick)
                {
                    __instance.Add(amount);
                }
            }


        }
    }
}
