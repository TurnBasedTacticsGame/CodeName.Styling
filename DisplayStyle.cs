using System.Collections.Generic;
using System.Linq;
using CodeName.Styling.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeName.Styling
{
    public class DisplayStyle : MonoBehaviour, ISerializationCallbackReceiver, IStyleClassNode
    {
        [ShowInInspector] [ReadOnly]
        private DisplayStyle parent;

        [ShowInInspector] [ReadOnly]
        private readonly HashSet<DisplayStyle> children = new();

        [HideInInspector]
        [SerializeField] private List<string> serializedSelfClasses = new();

        [ShowInInspector]
        [StyleClassValueDropdown]
        private readonly HashSet<string> selfClasses = new();

        public DisplayStyle Parent => parent;
        public IReadOnlyCollection<DisplayStyle> Children => children;

        IStyleClassNode IStyleClassNode.Parent => parent;
        IReadOnlyCollection<IStyleClassNode> IStyleClassNode.Children => children;

        public IReadOnlyCollection<string> SelfClasses => selfClasses;

        private void OnEnable()
        {
            UpdateParent();
            UpdateClosestChildren(transform);
        }

        private void OnDisable()
        {
            foreach (var child in children.ToList())
            {
                child.SetParent(parent);
            }

            if (parent != null)
            {
                parent.children.Remove(this);
                parent = null;
            }
        }

        private void OnTransformParentChanged()
        {
            UpdateParent();
        }

        public bool HasClass(string styleClass)
        {
            return selfClasses.Contains(styleClass);
        }

        public void AddClass(string styleClass)
        {
            if (selfClasses.Add(styleClass))
            {
                serializedSelfClasses.Add(styleClass);
            }
        }

        public void SetClass(string styleClass, bool isActive)
        {
            if (isActive)
            {
                AddClass(styleClass);
            }
            else
            {
                RemoveClass(styleClass);
            }
        }

        public void RemoveClass(string styleClass)
        {
            selfClasses.Remove(styleClass);
        }

        public void Clear()
        {
            selfClasses.Clear();
        }

        private void UpdateParent()
        {
            SetParent(GetNewParent());
        }

        private void UpdateClosestChildren(Transform current)
        {
            // Depth first search that stops search on each branch when a DisplayStyle is encountered
            foreach (Transform child in current)
            {
                if (child.TryGetComponent(out DisplayStyle style))
                {
                    style.UpdateParent();

                    continue;
                }

                UpdateClosestChildren(child);
            }
        }

        private void SetParent(DisplayStyle newParent)
        {
            if (parent != null)
            {
                parent.children.Remove(this);
            }

            parent = newParent;

            if (parent != null)
            {
                parent.children.Add(this);
            }
        }

        private DisplayStyle GetNewParent()
        {
            if (transform.parent == null)
            {
                return null;
            }

            // GetComponentInParent also includes the current GameObject, so must exclude current
            return transform.parent.GetComponentInParent<DisplayStyle>();
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
            serializedSelfClasses.Clear();
            serializedSelfClasses.AddRange(selfClasses);
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            selfClasses.Clear();
            selfClasses.UnionWith(serializedSelfClasses);
        }
    }
}
