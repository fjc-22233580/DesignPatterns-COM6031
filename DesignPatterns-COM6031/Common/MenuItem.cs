namespace DesignPatterns_COM6031.Common;

/// <summary>
/// Represents an option shown in a console menu.
/// </summary>
public sealed record MenuItem(string Title, Action Action);