using System;
using CommandSystem;
using Exiled.API.Features;
using UnityEngine;

namespace AssignmentS11.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class HeightCommand : ICommand
    {
        public string Command { get; } = "setheight";
        public string[] Aliases { get; } = { "height" };
        public string Description { get; } = "Sets the player's height.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Plugin.Instance.HeightCommandEnabled)
            {
                response = ".height is not enabled! Enable with .enableheight.";
                return false;
            }
            
            float min = Plugin.Instance.Config.MinimumHeight;
            float max = Plugin.Instance.Config.MaximumHeight;
            int minF = Plugin.Instance.Config.MinimumHeightF;
            int minI = Plugin.Instance.Config.MinimumHeightI;
            int maxF = Plugin.Instance.Config.MaximumHeightF;
            int maxI = Plugin.Instance.Config.MaximumHeightF;
            
            Player player = Player.Get((CommandSender)sender);

            string result;

            if (arguments.Count == 0)
            {
                SetHeight(player, Plugin.Instance.Config.ReferenceHeight, out response);
                response = "Height has been reset.";
                return true;
            }

            double height = CalculateHeightCm(arguments.At(0), out result);

            if (result == "OK")
            {
                SetHeight(player, height, out response);
                return true;
            }

            response = $"Invalid height formatting! Enter a height between {min} cm and {max} cm ({minF}'{minI}\" and {maxF}'{maxI}\").";
            return false;
        }

        private double CalculateHeightCm(string height, out string response)
        {
            int tmp = 0;
            int cm = 0;
            double result = 0;
            string num = "";
            int len = height.Length;
            

            if (height.EndsWith("'") && (!height.Contains("\"")))
            {
                num = height.Substring(0, len - 1);
                if (!int.TryParse(num, out tmp))
                {
                    response = "UF";
                    return 0;
                }

                response = "OK";
                return (double)(tmp * 12 * 2.54);
            }

            if (height.EndsWith("\"") && (height.Contains("'")))
            {
                tmp = 0;
                int ft = 0;
                int inches = 0;
                string[] ftAndIn = height.Split(new[] { '\'', '"' }, StringSplitOptions.RemoveEmptyEntries);

                bool ftOK = int.TryParse(ftAndIn[0], out ft);
                bool inOK = int.TryParse(ftAndIn[1], out inches);

                if (ftOK && inOK)
                {
                    inches = (ft * 12) + inches;
                    
                    response = "OK";
                    return (double)(inches * 2.54);
                }
                

            }
            
            /*if (height.EndsWith("cm"))
            {
                num = height.Substring(0, len - 2);
                if (!int.TryParse(num, out cm))
                {
                    response = "UF"; // UF - unknown format
                    return 0;
                }

                response = "OK";
                return (double)cm;
            }*/
            
            if (!int.TryParse(height, out cm))
            {
                response = "UF"; // UF - unknown format
                return 0;
            }

            response = "OK";
            return (double)cm;

            /*response = "UF";
            return 0;*/
        }

        private void SetHeight(Player player, double height, out string response)
        {
            float min = Plugin.Instance.Config.MinimumHeight;
            float max = Plugin.Instance.Config.MaximumHeight;
            int minF = Plugin.Instance.Config.MinimumHeightF;
            int minI = Plugin.Instance.Config.MinimumHeightI;
            int maxF = Plugin.Instance.Config.MaximumHeightF;
            int maxI = Plugin.Instance.Config.MaximumHeightF;
            float reference = Plugin.Instance.Config.ReferenceHeight;

            response = $"Set height to {height} cm.";
            
            if (height < min)
            {
                height = reference;
                response = $"Your entered height was lower than {min} cm ({minF}'{minI}\"), therefore your height was reset.";
            }
            else if (height > max)
            {
                height = reference;
                response = $"Your entered height was higher than {max} cm ({maxF}'{maxI}\"), therefore your height was reset.";
            }
            
            float scaledHeight = (float)(height / reference);
            
            player.SetScale(new Vector3(1, scaledHeight, 1));
        }
    }
}