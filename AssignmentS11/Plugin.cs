using System;
using Exiled.API.Features;

namespace AssignmentS11
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "Site11 Assignment";
        public override string Prefix { get; } = "assignment";
        public override Version Version { get; } = new Version(2026, 01, 01);
        public override string Author { get; } = "imscared.exe";

        public bool NameCommandEnabled = true;
        public bool CInfoCommandEnabled = true;
        public bool HeightCommandEnabled = true;

        public static Plugin Instance;

        public override void OnEnabled()

        {
			Instance = this;
            Log.Info("Enable assignment plugin by imscared.exe");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Instance = null;
            Log.Info("Disabled assignment plugin by imscared.exe");
            base.OnDisabled();
        }
    }
}