public string F(string format)
{
    if (string.IsNullOrEmpty(format)) return string.Empty;

    var result = format;
    FakerMatch match;
    while ((match = ExtractMatchFrom(result)).Success)
    {
        var faker = GetFaker(match.Name);
        var value = GetValue(faker, match.Method);
        var start = result.Substring(0, match.Index);
        var end = result.Substring(match.Index + match.Length);

        result = $"{start}{value}{end}";
    }

    return result;
}
