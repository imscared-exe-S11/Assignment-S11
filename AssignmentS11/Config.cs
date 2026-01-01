using System.ComponentModel;
using Exiled.API.Interfaces;

namespace AssignmentS11
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
        public bool Debug { get; set; }

        [Description("Minimum height (float, cm)")]
        public float MinimumHeight { get; set; } = 160;

        [Description("Minimum height (string, x'y\"")]
        public string MinimumHeightFI { get; set; } = "5'3\"";
        [Description("Maximum height (float, cm)")]

        public float MaximumHeight { get; set; } = 200;

        [Description("Maximum height (string, x'y\"")]
        public string MaximumHeightFI { get; set; } = "6'7\"";

        [Description("Reference height (float, cm) (default height)")]
        public float ReferenceHeight { get; set; } = 180;
    }
}