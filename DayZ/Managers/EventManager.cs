﻿using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;

using SDG.Unturned;

using UnityEngine;

using Steamworks;

using ChubbyQuokka.DayZ.Structures;

namespace ChubbyQuokka.DayZ.Managers
{
    internal static class EventManager
    {
        public static void Initialize()
        {
            UnturnedPlayerEvents.OnPlayerRevive += OnPlayerRevive;
            UnturnedPlayerEvents.OnPlayerDeath += OnPlayerDeath;

            U.Events.OnPlayerConnected += OnPlayerConnected;
        }

        public static void Destroy()
        {
            UnturnedPlayerEvents.OnPlayerRevive -= OnPlayerRevive;
            UnturnedPlayerEvents.OnPlayerDeath -= OnPlayerDeath;

            U.Events.OnPlayerConnected -= OnPlayerConnected;
        }

        static void OnPlayerConnected(UnturnedPlayer player)
        {
            HumanityManager.CheckPlayerJoin(player);
        }

        static void OnPlayerRevive(UnturnedPlayer player, Vector3 position, byte angle)
        {
            foreach (PlayerItemCategory category in DayZConfiguration.ItemSpawns)
            {
                ItemManager.GiveCategoryToPlayer(player, category);
            }
        }

        static void OnPlayerDeath(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            foreach (PlayerItemCategory category in DayZConfiguration.ItemDrops)
            {
                ItemManager.GiveCategoryToPlayer(player, category);
            }
        }
    }
}
