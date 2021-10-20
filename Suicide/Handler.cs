// -----------------------------------------------------------------------
// <copyright file="Handler.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.CustomItems.API.Features;
using Mistaken.API.Diagnostics;
using Mistaken.API.Extensions;

namespace Mistaken.Suicide
{
    internal class Handler : Module
    {
        public static readonly HashSet<int> InSuicidalState = new HashSet<int>();

        public Handler(PluginHandler p)
            : base(p)
        {
        }

        public override string Name => "Suicide";

        public override void OnEnable()
        {
            Exiled.Events.Handlers.Server.RestartingRound += this.Handle(() => this.Server_RestartingRound(), "RoundRestart");
            Exiled.Events.Handlers.Player.Shooting += this.Handle<Exiled.Events.EventArgs.ShootingEventArgs>((ev) => this.Player_Shooting(ev));
            Exiled.Events.Handlers.Player.ChangingRole += this.Handle<Exiled.Events.EventArgs.ChangingRoleEventArgs>((ev) => this.Player_ChangingRole(ev));
        }

        public override void OnDisable()
        {
            Exiled.Events.Handlers.Server.RestartingRound -= this.Handle(() => this.Server_RestartingRound(), "RoundRestart");
            Exiled.Events.Handlers.Player.Shooting -= this.Handle<Exiled.Events.EventArgs.ShootingEventArgs>((ev) => this.Player_Shooting(ev));
            Exiled.Events.Handlers.Player.ChangingRole -= this.Handle<Exiled.Events.EventArgs.ChangingRoleEventArgs>((ev) => this.Player_ChangingRole(ev));
        }

        internal static void KillPlayer(Player player, ItemType type = ItemType.None)
        {
            string reason;
            switch (type)
            {
                case ItemType.GunCOM15:
                    reason = PluginHandler.Instance.Translation.DeadMsg9x11;
                    break;
                case ItemType.GunCOM18:
                    reason = PluginHandler.Instance.Translation.DeadMsg9x11;
                    break;
                case ItemType.GunCrossvec:
                    reason = PluginHandler.Instance.Translation.DeadMsg9x11;
                    break;
                case ItemType.GunFSP9:
                    reason = PluginHandler.Instance.Translation.DeadMsg9x11;
                    break;
                case ItemType.GunLogicer:
                    reason = PluginHandler.Instance.Translation.DeadMsg762x39;
                    break;
                case ItemType.GunE11SR:
                    reason = PluginHandler.Instance.Translation.DeadMsg556x45;
                    break;
                case ItemType.GunRevolver:
                    reason = PluginHandler.Instance.Translation.DeadMsg44cal;
                    break;
                case ItemType.GunShotgun:
                    reason = PluginHandler.Instance.Translation.DeadMsg12gauge;
                    break;
                case ItemType.GunAK:
                    reason = PluginHandler.Instance.Translation.DeadMsg762x39;
                    break;

                default:
                    reason = PluginHandler.Instance.Translation.DeadMsgUnknown;
                    break;
            }

            player.Kill(reason);
        }

        private void Server_RestartingRound()
        {
            InSuicidalState.Clear();
        }

        private void Player_ChangingRole(Exiled.Events.EventArgs.ChangingRoleEventArgs ev)
        {
            if (InSuicidalState.Contains(ev.Player.Id))
                InSuicidalState.Remove(ev.Player.Id);
        }

        private void Player_Shooting(Exiled.Events.EventArgs.ShootingEventArgs ev)
        {
            if (InSuicidalState.Contains(ev.Shooter.Id))
            {
                ev.IsAllowed = false;
                if (CustomItem.TryGet(ev.Shooter.CurrentItem, out _))
                    return;
                KillPlayer(ev.Shooter, ev.Shooter.CurrentItem.Type);
                InSuicidalState.Remove(ev.Shooter.Id);
            }
        }
    }
}
