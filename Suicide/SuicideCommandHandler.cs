// -----------------------------------------------------------------------
// <copyright file="SuicideCommandHandler.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using CommandSystem;
using Mistaken.API.Commands;
using Mistaken.API.Extensions;

namespace Mistaken.Suicide
{
    [CommandSystem.CommandHandler(typeof(CommandSystem.ClientCommandHandler))]
    internal class SuicideCommandHandler : IBetterCommand
    {
        public override string Command => "suicide";

        public override string[] Aliases => new string[] { };

        public override string Description => "DO IT";

        public override string[] Execute(ICommandSender sender, string[] args, out bool success)
        {
            success = false;
            var player = sender.GetPlayer();
            if (player.IsHuman)
            {
                success = true;
                if (!SuicideHandler.InSuicidalState.Contains(player.Id))
                {
                    SuicideHandler.InSuicidalState.Add(player.Id);
                    return new string[] { PluginHandler.Instance.Translation.SuicideEnter };
                }
                else
                {
                    SuicideHandler.InSuicidalState.Remove(player.Id);
                    return new string[] { PluginHandler.Instance.Translation.SuicideExit };
                }
            }

            return new string[] { "Only Human Suicide" };
        }
    }
}
