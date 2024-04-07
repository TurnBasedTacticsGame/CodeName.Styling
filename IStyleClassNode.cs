using System.Collections.Generic;

namespace CodeName.Core.UserInterface.Styling
{
    public interface IStyleClassNode
    {
        public IStyleClassNode Parent { get; }
        public IReadOnlyCollection<IStyleClassNode> Children { get; }
        public IReadOnlyCollection<string> SelfClasses { get; }

        public bool HasClass(string styleClass);
    }
}
