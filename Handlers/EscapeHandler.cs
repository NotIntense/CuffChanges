namespace EscapeChanges
{
    using Exiled.API.Extensions;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Player;
    using PlayerRoles;

    public static class EscapeHandler
    {
        public static Config? Config => Plugin.Instance.Config;

        public static void Escape(EscapingEventArgs ev)
        {
            if (ev.EscapeScenario != Exiled.API.Enums.EscapeScenario.CustomEscape)
                return;

            if (Config.RoleConversionDictionary.TryGetValue(ev.Player.Role.Type, out RoleConversionInfo? roleConversionInfo))
            {
                if (roleConversionInfo.NeedToBeCuffed && !ev.Player.IsCuffed)
                    return;

                ev.NewRole = roleConversionInfo.TargetRole;
                ev.IsAllowed = true;

                if (Config.DisplayCustomEscapeMessage && !string.IsNullOrEmpty(roleConversionInfo.Message))
                {
                    DisplayEscapeMessage(ev.Player, roleConversionInfo.Message, roleConversionInfo.TargetRole);
                }
            }
        }

        public static void DisplayEscapeMessage(Player player, string message, RoleTypeId newRole) 
        {
            string edit = message.Replace("{newRole}", $"<color={newRole.GetColor().ToHex()}>{newRole.GetFullName()}</color>");
            player.Broadcast(new Broadcast(edit, 5), true);
        }
    }

    public class RoleConversionInfo
    {
        public RoleTypeId TargetRole { get; set; }
        public bool NeedToBeCuffed { get; set; } = false;
        public string? Message { get; set; } = string.Empty;
    }
}
