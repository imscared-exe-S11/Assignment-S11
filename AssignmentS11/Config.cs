using System.ComponentModel;
using Exiled.API.Interfaces;

namespace AssignmentS11
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        [Description("Minimum height (float, cm)")]
        public float MinimumHeight { get; set; } = 160;
        
        [Description("Maximum height (float, cm)")] 
        public float MaximumHeight { get; set; } = 201;
        
        [Description("Reference height (float, cm) (default height)")]
        public float ReferenceHeight { get; set; } = 180;

        [Description("Minimum height (int, feet) (only for displaying)")]
        public int MinimumHeightF { get; set; } = 5;
        
        [Description("Minimum height (int, inches) (only for displaying)")]
        public int MinimumHeightI { get; set; } = 3;
        
        [Description("Minimum height (int, feet) (only for displaying)")]
        public int MaximumHeightF { get; set; } = 6;
        
        [Description("Minimum height (int, inches) (only for displaying)")]
        public int MaximumHeightI { get; set; } = 7;
    }

}
