#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Object = UnityEngine.Object;

namespace CodeName.Styling.Attributes
{
    public class StyleClassValueDropdownAttributeProcessor : OdinAttributeProcessor
    {
        public override bool CanProcessChildMemberAttributes(InspectorProperty parentProperty, MemberInfo member)
        {
            return member.GetAttribute<StyleClassValueDropdownAttribute>() != null;
        }

        public override void ProcessChildMemberAttributes(InspectorProperty parentProperty, MemberInfo member, List<Attribute> attributes)
        {
            attributes.Add(new ValueDropdownAttribute($"@{typeof(StyleClassValueDropdownAttributeProcessor).FullName}.{nameof(GetDropdownStyleClasses)}()")
            {
                AppendNextDrawer = true,
                NumberOfItemsBeforeEnablingSearch = 0,
                DropdownWidth = 200,
                DisableListAddButtonBehaviour = true,
            });
        }

        private static IEnumerable<string> GetDropdownStyleClasses()
        {
            var results = new HashSet<string>();

            // Get classes from Scene
            results.AddRange(Object.FindObjectsOfType<DisplayStyle>(true)
                .SelectMany(s => s.SelfClasses));

            // Get classes from DeclareStyleClassAttribute
            results.AddRange(AssemblyUtilities.GetTypes(AssemblyTypeFlags.CustomTypes)
                .SelectMany(t => t.GetProperties(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                .Where(p => p.PropertyType == typeof(string) && p.GetAttribute<DeclareStyleClassAttribute>() != null)
                .Select(p => (string)p.GetValue(null)));

            return results.OrderBy(x => x).ToList();
        }
    }
}
#endif
