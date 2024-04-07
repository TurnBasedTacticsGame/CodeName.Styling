namespace CodeName.Styling
{
    public static class StyleClassNodeUtility
    {
        public static bool HasClassOnParent(this IStyleClassNode node, string styleClass)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (parent.HasClass(styleClass))
                {
                    return true;
                }

                parent = parent.Parent;
            }

            return false;
        }

        public static bool HasClassOnChild(this IStyleClassNode node, string styleClass)
        {
            foreach (var child in node.Children)
            {
                if (child.HasClass(styleClass) || HasClassOnChild(child, styleClass))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
