using System;
using CodeName.Styling.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeName.Styling.MatchConditions
{
    [Obsolete("Use ParentSelectorMatchCondition instead")]
    [Serializable]
    public class AbilityMatchCondition : IMatchCondition
    {
        [HorizontalGroup] [HideLabel]
        [StyleClassValueDropdown]
        [SerializeField] private string styleClass;

        [ShowInInspector]
        [HideLabel] private string Name => "AbilityMatch";

        public string StyleClass
        {
            get => styleClass;
            set => styleClass = value;
        }

        public bool IsMatch(IStyleClassNode node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (parent.HasClass("Ability"))
                {
                    return parent.HasClass(StyleClass);
                }

                parent = parent.Parent;
            }

            return false;
        }
    }
}
