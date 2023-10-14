namespace EscapeChanges.Handlers
{
    using EscapeChanges;
    using Nebuli.API.Features.Player;
    using Nebuli.Events.EventArguments.Player;
    using Nebuli.API.Extensions;
    using PlayerRoles;

    public static class EscapeHandler
    {
        public static Config? Config => Plugin.Instance.Config;

        public static void Escape(PlayerEscapingEvent ev)
        {
            if (ev.EscapeScenario != Nebuli.API.Features.Enum.EscapeType.PluginEscape)
                return;

            if (Config.RoleConversionDictionary.TryGetValue(ev.Player.RoleType, out RoleConversionInfo? roleConversionInfo))
            {
                if (roleConversionInfo.NeedToBeCuffed && !ev.Player.IsCuffed)
                    return;

                ev.NewRole = roleConversionInfo.TargetRole;
                ev.IsCancelled = false;

                if (Config.DisplayCustomEscapeMessage && !string.IsNullOrEmpty(roleConversionInfo.Message))
                {
                    DisplayEscapeMessage(ev.Player, roleConversionInfo.Message, roleConversionInfo.TargetRole);
                }
            }
        }

        public static void DisplayEscapeMessage(NebuliPlayer player, string message, RoleTypeId newRole)
        {
            string edit = message.Replace("{newRole}", $"<color={newRole.GetRoleColor().ToHex()}>{newRole.FullRoleName()}</color>");
            player.Broadcast(edit, 5, clearCurrent: true);
        }
    }
}
