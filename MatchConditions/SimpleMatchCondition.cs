using System;
using CodeName.Styling.Attributes;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeName.Styling.MatchConditions
{
    [InlineProperty]
    [Serializable]
    public class SimpleMatchCondition : IMatchCondition
    {
        /// <summary>
        /// Where to look for the required <see cref="SimpleMatchCondition.StyleClass"/>. Multiple conditions are combined using the OR operator.
        /// </summary>
        [Flags]
        public enum Types
        {
            None = 0,

            /// <summary>
            ///     Class must exist on self.
            /// </summary>
            Self = 1 << 0,

            /// <summary>
            ///     Class must exist on parent.
            /// </summary>
            Parent = 1 << 1,

            /// <summary>
            ///     Class must exist on child.
            /// </summary>
            Child = 1 << 2,
        }

        /// <summary>
        /// Used to rename members of <see cref="Types"/> and for additional inspector functionality.
        /// </summary>
        [Flags]
        private enum InspectorTypes
        {
            [UsedImplicitly] P = Types.Parent,
            [UsedImplicitly] S = Types.Self,
            [UsedImplicitly] C = Types.Child,
        }

        [HorizontalGroup] [HideLabel]
        [StyleClassValueDropdown]
        [SerializeField] private string styleClass;

        [HideInInspector]
        [SerializeField] private Types type = Types.Self;

        [ShowInInspector]
        [HorizontalGroup] [HideLabel] [EnumToggleButtons]
        private InspectorTypes InspectorType
        {
            get => (InspectorTypes)type;
            set => type = (Types)value;
        }

        public string StyleClass
        {
            get => styleClass;
            set => styleClass = value;
        }

        public Types Type
        {
            get => type;
            set => type = value;
        }

        public bool IsMatch(IStyleClassNode node)
        {
            // Only one condition needs to succeed
            if ((Type & Types.Self) != 0 && node.HasClass(StyleClass))
            {
                return true;
            }

            if ((Type & Types.Parent) != 0 && node.HasClassOnParent(StyleClass))
            {
                return true;
            }

            if ((Type & Types.Child) != 0 && node.HasClassOnChild(StyleClass))
            {
                return true;
            }

            return false;
        }
    }
}
