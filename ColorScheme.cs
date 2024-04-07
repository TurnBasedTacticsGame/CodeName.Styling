using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeName.Core.UserInterface.Styling
{
    public class ColorScheme : SerializedScriptableObject
    {
        // Not using properties in this class because it introduces too much code duplication and provides little benefit

        [Header("UnitDisplay")]
        public bool DisplayUnitSelectionBox;
        public StyleRule<Color> UnitColor = new();

        [Header("WeaponDisplay")]
        public bool DisplayWeaponSelectionBox;
        public StyleRule<Color> WeaponColor = new();

        [Header("AbilityDisplay")]
        public bool DisplayAbilitySelectionBox;
        public StyleRule<Color> AbilityColor = new ();

        [Header("AbilityEffectCellDisplay")]
        public StyleRule<Color> AbilityEffectColor = new();

        [Header("AbilityRangeIndicator")]
        public StyleRule<Color> RangeIndicatorColor = new();
    }
}
