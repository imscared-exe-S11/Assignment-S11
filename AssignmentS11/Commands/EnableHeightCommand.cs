using System;
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;

namespace AssignmentS11.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class EnableHeightCommand : ICommand
    {
        public string Command { get; } = "enableheight";
        public string[] Aliases { get; } = { "eheight" };
        public string Description { get; } = "Enable or disable the .height command.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((CommandSender)sender);

            if (!player.CheckPermission("cmd.enableheight"))
            {
                response = "You do not have the permissions to enable or disable .height.";
                return false;
            }
            
            Plugin.Instance.HeightCommandEnabled = !Plugin.Instance.HeightCommandEnabled;

            if (Plugin.Instance.HeightCommandEnabled)
            {
                response = "Enabled .height.";
            }
            else
            {
                response = "Disabled .height";
            }

            return true;
        }
    }
}