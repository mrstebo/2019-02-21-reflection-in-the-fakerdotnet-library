private string GetValue(PropertyInfo propertyInfo, string methodName)
{
    const BindingFlags flags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
    var method = propertyInfo.PropertyType.GetMethod(methodName, flags)
        ?? throw new FormatException($"Invalid method: {propertyInfo.Name}.{methodName}");

    var parameters = method.GetParameters().Select(DefaultValue).ToArray();
    var value = method.Invoke(propertyInfo.GetValue(_fakerContainer, null), parameters);

    return Convert.ToString(value);
}

private static object DefaultValue(ParameterInfo parameterInfo)
{
    return parameterInfo.ParameterType.IsValueType
        ? Activator.CreateInstance(parameterInfo.ParameterType)
        : null;
}
