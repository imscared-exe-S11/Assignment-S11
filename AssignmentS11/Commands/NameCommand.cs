using System;
using CommandSystem;
using Exiled.API.Features;

namespace AssignmentS11.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class NameCommand : ICommand
    {
        public string Command { get; } = "setname";
        public string[] Aliases { get; } = { "name" };
        public string Description { get; } = "Sets the player's custom name.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Plugin.Instance.NameCommandEnabled)
            {
                response = ".name is not enabled! Enable with .enablename.";
                return false;
            }
            
            Player player = Player.Get((CommandSender)sender);
            
            string cName = string.Join(" ", arguments);

            player.CustomName = cName;
            
            if (arguments.Count > 0)
            {
                response = $"Set name to {cName}.";
            }
            else
            {
                response = "Custom name reset.";
            }

            return true;
        }
    }
}