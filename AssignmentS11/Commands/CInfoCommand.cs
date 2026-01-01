using System;
using CommandSystem;
using Exiled.API.Features;

namespace AssignmentS11.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class CInfoCommand : ICommand
    {
        public string Command { get; } = "setcustominfo";
        public string[] Aliases { get; } = { "cinfo" };
        public string Description { get; } = "Sets the player's custom info.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Plugin.Instance.NameCommandEnabled)
            {
                response = ".name is not enabled! Enable with .enablecinfo.";
                return false;
            }
            
            Player player = Player.Get((CommandSender)sender);
            
            string cInfo = string.Join(" ", arguments);

            player.CustomInfo = cInfo;
            
            if (arguments.Count > 0)
            {
                response = $"Set custom info to {cInfo}.";
            }
            else
            {
                response = "Custom information reset.";
            }

            return true;
        }
    }
}