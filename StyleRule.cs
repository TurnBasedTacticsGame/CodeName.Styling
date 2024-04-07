using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeName.Core.UserInterface.Styling
{
    [InlineProperty]
    [Serializable]
    public class StyleRule<T>
    {
        [ListDrawerSettings(CustomAddFunction = nameof(Inspector_AddSelector))]
        [SerializeField] private List<StyleRuleSelector<T>> selectors = new();

        public List<StyleRuleSelector<T>> Selectors => selectors;

        public T GetValue(IStyleClassNode node)
        {
            // Selectors at the end of the list override the ones before.
            // Only the last selector matters -> Use reverse for loop.
            for (var i = selectors.Count - 1; i >= 0; i--)
            {
                var selector = selectors[i];
                if (selector.IsMatch(node))
                {
                    return selector.Value;
                }
            }

            return default;
        }

        private void Inspector_AddSelector()
        {
            selectors.Add(new StyleRuleSelector<T>());
        }
    }
}
