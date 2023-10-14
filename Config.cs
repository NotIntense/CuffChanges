namespace EscapeChanges
{
    using EscapeChanges.Handlers;
    using Nebuli.API.Interfaces;
    using PlayerRoles;
    using System.ComponentModel;

    public sealed class Config : IConfiguration
    {
        [Description("Gets or sets if the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Gets or sets if the plugin's debug logs are enabled.")]
        public bool Debug { get; set; } = false;

        [Description("Gets or sets if the player will get the custom escape message for their role change. FOR ESCAPE MESSAGES, '{newRole}' WILL BE THE NEW ROLE THE PLAYER IS SET TO.")]
        public bool DisplayCustomEscapeMessage { get; set; } = false;

        [Description("The role assigned to players upon escape based on their previous role.For Example, if a Facility Guard escapes, they'll become a NTF Private.")]
        public Dictionary<RoleTypeId, RoleConversionInfo> RoleConversionDictionary { get; set; } = new()
        {
            { RoleTypeId.FacilityGuard, new RoleConversionInfo { TargetRole = RoleTypeId.NtfPrivate, NeedToBeCuffed = false, Message = "You've escaped and became a {newRole}!" } },
        };
    }
}
