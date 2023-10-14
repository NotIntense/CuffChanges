namespace EscapeChanges
{
    using EscapeChanges.Handlers;
    using Nebuli.API.Features;
    using Nebuli.Events.Handlers;
    using System;

    public class Plugin : Plugin<Config>
    {
        public static Plugin? Instance { get; private set; } = null;
        public override string Name { get; } = "EscapeChanges";
        public override string Creator { get; } = "NotIntense";
        public override Version Version { get; } = new(1, 0, 0);
        public override Version NebuliVersion { get; } = new(1, 2, 6);
        
        public override void OnEnabled()
        {
            Instance = this;
            PlayerHandlers.Escaping += EscapeHandler.Escape;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandlers.Escaping -= EscapeHandler.Escape;
            Instance = null;
            base.OnDisabled();
        }
    }
}