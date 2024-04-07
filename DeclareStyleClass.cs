using System;

namespace CodeName.Styling
{
    /// <summary>
    /// Allows the style class declaration to be displayed in the Unity Editor as a dropdown when creating
    /// <see cref="StyleRule{T}"/>s.
    /// <para/>
    /// Must be added to a static getter property.
    /// <example>
    /// <code>
    /// [DeclareStyleClass] public static string StyleClass { get; } = "StyleClass"
    /// </code>
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DeclareStyleClassAttribute : Attribute {}
}
