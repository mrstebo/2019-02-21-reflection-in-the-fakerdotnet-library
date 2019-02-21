private PropertyInfo GetFaker(string name)
{
    const BindingFlags flags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;

    return _fakerContainer.GetType().GetProperty(name, flags)
        ?? throw new FormatException($"Invalid module: {name}");
}
