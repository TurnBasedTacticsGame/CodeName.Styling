using System;
using CodeName.Styling.MatchConditions;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeName.Styling
{
    [Serializable]
    public class StyleRuleSelector<T>
    {
        private const int LabelWidth = 45;

        [HorizontalGroup]
        [LabelWidth(LabelWidth)]
        [SerializeField] private T value;

        [UsedImplicitly]
        [HorizontalGroup(0, 4)]
        [LabelWidth(LabelWidth)]
        [Tooltip("Notes and comments about how this selector is used.")]
        [SerializeField] private string notes;

        [HideLabel]
        [InlineProperty]
        [SerializeField] private CompositeMatchCondition condition = new();

        public T Value
        {
            get => value;
            set => this.value = value;
        }

        public CompositeMatchCondition Condition
        {
            get => condition;
            set => condition = value;
        }

        public bool IsMatch(IStyleClassNode node)
        {
            return condition.IsMatch(node);
        }
    }
}
