namespace EscapeChanges
{
    using EscapeChanges.Handlers;
    using Exiled.API.Features;
    using System;
    using PlayerHandler = Exiled.Events.Handlers.Player;

    public class Plugin : Plugin<Config>
    {
        public static Plugin? Instance { get; private set; } = null;
        public override string Name { get; } = "EscapeChanges";
        public override string Author { get; } = "NotIntense";
        public override string Prefix { get; } = "EC";
        public override Version Version { get; } = new(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new(8, 2, 0);

        public override void OnEnabled()
        {
            Instance = this;
            PlayerHandler.Escaping += EscapeHandler.Escape;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandler.Escaping -= EscapeHandler.Escape;
            Instance = null;
            base.OnDisabled();
        }
    }
}