namespace EscapeChanges.Handlers
{
    using PlayerRoles;

    public class RoleConversionInfo
    {
        public RoleTypeId TargetRole { get; set; } = RoleTypeId.None;
        public bool NeedToBeCuffed { get; set; } = false;
        public string? Message { get; set; } = string.Empty;
    }
}
