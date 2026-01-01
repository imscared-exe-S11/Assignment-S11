using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace AssignmentS11.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class EnableNameCommand : ICommand
    {
        public string Command { get; } = "enablename";
        public string[] Aliases { get; } = { "ename" };
        public string Description { get; } = "Enable or disable the .name command.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((CommandSender)sender);

            if (!player.CheckPermission("cmd.enablename"))
            {
                response = "You do not have the permissions to enable or disable .name.";
                return false;
            }
            
            Plugin.Instance.NameCommandEnabled = !Plugin.Instance.NameCommandEnabled;

            if (Plugin.Instance.NameCommandEnabled)
            {
                response = "Enabled .name.";
            }
            else
            {
                response = "Disabled .name";
            }

            return true;
        }
    }
}