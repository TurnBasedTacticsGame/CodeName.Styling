using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeName.Styling.MatchConditions
{
    [Serializable]
    public class CompositeMatchCondition : IMatchCondition
    {
        [InlineProperty]
        [HideReferenceObjectPicker]
        [ListDrawerSettings(ShowFoldout = false)]
        [SerializeReference] private List<IMatchCondition> conditions = new();

        [SerializeField] private bool requireAllConditions = true;

        public CompositeMatchCondition() {}

        public CompositeMatchCondition(IEnumerable<IMatchCondition> conditions)
        {
            this.conditions.AddRange(conditions);
        }

        public List<IMatchCondition> Conditions
        {
            get => conditions;
            set => conditions = value;
        }

        public bool RequireAllConditions
        {
            get => requireAllConditions;
            set => requireAllConditions = value;
        }

        public bool IsMatch(IStyleClassNode node)
        {
            if (conditions.Count == 0)
            {
                // Always return true when there aren't any conditions defined
                return true;
            }

            switch (requireAllConditions)
            {
                case true:
                {
                    foreach (var condition in conditions)
                    {
                        if (!condition.IsMatch(node))
                        {
                            return false;
                        }
                    }

                    return true;
                }
                case false:
                {
                    foreach (var condition in conditions)
                    {
                        if (condition.IsMatch(node))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }
    }
}
