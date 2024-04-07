using CodeName.Core.UserInterface;
using CodeName.Core.UserInterface.Capabilities;
using CodeName.Core.UserInterface.Formatting;

namespace CodeName.Styling
{
    public static class StyleClasses
    {
        // --- Interactions ---
        /// <summary>
        /// Managed by <see cref="HoverInteractionCapability"/>.
        /// </summary>
        [DeclareStyleClass] public static string Hovered { get; } = nameof(Hovered);

        /// <summary>
        /// Managed by <see cref="HoverInteractionCapability"/>.
        /// </summary>
        [DeclareStyleClass] public static string HoveredWithin { get; } = nameof(HoveredWithin);

        [DeclareStyleClass] public static string Selected { get; } = nameof(Selected);

        // --- WeaponDisplay ---
        /// <summary>
        /// Managed by <see cref="WeaponDisplay"/>.
        /// </summary>
        [DeclareStyleClass] public static string WeaponDisplay { get; } = nameof(WeaponDisplay);
        [DeclareStyleClass] public static string ActiveWeaponAbility { get; } = nameof(ActiveWeaponAbility);

        // --- Targets ---
        [DeclareStyleClass] public static string UpgradeTarget { get; } = nameof(UpgradeTarget);
        [DeclareStyleClass] public static string AbilityTarget { get; } = nameof(AbilityTarget);
        [DeclareStyleClass] public static string GoalTarget { get; } = nameof(GoalTarget);


        // --- AbilityDisplay ---
        /// <summary>
        /// Managed by <see cref="AbilityDisplay"/>.
        /// </summary>
        [DeclareStyleClass] public static string DuelingAbilityStyle { get; } = nameof(DuelingAbilityStyle);

        // --- RangeCell ---
        /// <summary>
        /// Managed by <see cref="RangeCellDisplay"/>.
        /// </summary>
        [DeclareStyleClass] public static string EnemyTarget { get; } = nameof(EnemyTarget);

        /// <summary>
        /// Managed by <see cref="RangeCellDisplay"/>.
        /// </summary>
        [DeclareStyleClass] public static string AllyTarget { get; } = nameof(AllyTarget);

        /// <summary>
        /// Managed by <see cref="RangeCellDisplay"/>.
        /// </summary>
        [DeclareStyleClass] public static string CurrentTile { get; } = nameof(CurrentTile);

        // --- InstanceDisplayDataContext
        /// <summary>
        /// Used by <see cref="InstanceDisplayDataContext"/>.
        /// </summary>
        [DeclareStyleClass] public static string CtrlModifier { get; } = nameof(CtrlModifier);

        /// <summary>
        /// Used by <see cref="InstanceDisplayDataContext"/>.
        /// </summary>
        [DeclareStyleClass] public static string ShiftModifier { get; } = nameof(ShiftModifier);

        /// <summary>
        /// Used by <see cref="InstanceDisplayDataContext"/>.
        /// </summary>
        [DeclareStyleClass] public static string AltModifier { get; } = nameof(AltModifier);
    }
}
