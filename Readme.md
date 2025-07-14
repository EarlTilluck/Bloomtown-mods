# My Bloomtown Mods

## Get BepInEx for these mods

use the following version of BepInEx, which is ready for to use for bloomtown

- Unstripped_2022.3.30_BepInEx_win_x64_5.4.23.2.zip
- https://github.com/Albeoris/Memoria.Bloomtown/
- https://www.nexusmods.com/bloomtownadifferentstory/mods/2?tab=description

use the following version of configuration manager

- BepInEx.ConfigurationManager_BepInEx5_v18.4.1
- https://github.com/BepInEx/BepInEx.ConfigurationManager/releases

F1 key is used by both configuration manager and Memoria mod, refer to Memoria mod page to learn how to change key settings.

## Download releases from nexus

https://www.nexusmods.com/games/bloomtownadifferentstory

## How to create mods for Unity games (with BepInEx and Harmony)

1. Use Visual Studio

2. New Project = C#, Windows, Library => Class Library .Net framework

3. Add references from `game/game_data/managed/`

- Assembly-Csharp.dll
- UnityEngine.dll (optional)
- UnityEngine.CoreModule.dll (optional)

4. Add reference to `game/BepInEx/core/` (BepInEx for this game must be present)

- BepInEx.dll
- 0Harmony.dll

5. Set `Copy Local` for each dependency to `false` (Under references in project window, right click, choose properties)

6. These five references cover most of what you need. You can add other references from the `managed` folder if necessary.

7. copy gitignore from existing project to new project so dll files don't commit.
