using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace AssignmentS11.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class EnableCInfoCommand : ICommand
    {
        public string Command { get; } = "enablecinfo";
        public string[] Aliases { get; } = { "ecinfo" };
        public string Description { get; } = "Enable or disable the .cinfo command.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((CommandSender)sender);

            if (!player.CheckPermission("cmd.enablecinfo"))
            {
                response = "You do not have the permissions to enable or disable .cinfo.";
                return false;
            }
            
            Plugin.Instance.CInfoCommandEnabled = !Plugin.Instance.CInfoCommandEnabled;

            if (Plugin.Instance.CInfoCommandEnabled)
            {
                response = "Enabled .cinfo.";
            }
            else
            {
                response = "Disabled .cinfo";
            }

            return true;
        }
    }
}