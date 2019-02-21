private static FakerMatch ExtractMatchFrom(string input)
{
    const string pattern = @"\{(\w+).(\w+)\}";
    var match = Regex.Match(input, pattern);

    return match.Success
        ? new FakerMatch
        {
            Success = true,
            Index = match.Index,
            Length = match.Length,
            Name = match.Groups[1].Value,
            Method = match.Groups[2].Value
        }
        : new FakerMatch();
}
