namespace CuffChanges
{
    using Exiled.API.Features;
    using System;
    using PlayerHandler = Exiled.Events.Handlers.Player;

    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "CuffChanges";
        public override string Author { get; } = "NotIntense";
        public override string Prefix { get; } = "CF";
        public override Version Version { get; } = new(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new(8, 2, 0);

        public override void OnEnabled()
        {         
            EscapeHandler.Config = Config;
            PlayerHandler.Escaping += EscapeHandler.Escape;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandler.Escaping -= EscapeHandler.Escape;
            EscapeHandler.Config = null;
            base.OnDisabled();
        }
    }
}