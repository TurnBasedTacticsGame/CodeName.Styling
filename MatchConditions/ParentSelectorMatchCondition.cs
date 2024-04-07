using System;
using Exanite.Core.OdinInspector;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeName.Styling.MatchConditions
{
    [Serializable]
    public class ParentSelectorMatchCondition : IMatchCondition
    {
        [Inline]
        [BoxGroup("Parent Selector")]
        [HideReferenceObjectPicker]
        [SerializeReference] private IMatchCondition parentSelector;

        [Inline]
        [BoxGroup("Parent Condition")]
        [HideReferenceObjectPicker]
        [SerializeReference] private IMatchCondition parentCondition;

        public IMatchCondition ParentSelector
        {
            get => parentSelector;
            set => parentSelector = value;
        }

        public IMatchCondition ParentCondition
        {
            get => parentCondition;
            set => parentCondition = value;
        }

        public bool IsMatch(IStyleClassNode node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (ParentSelector.IsMatch(parent))
                {
                    return ParentCondition.IsMatch(parent);
                }

                parent = parent.Parent;
            }

            return false;
        }
    }
}
