using System;
using System.Text.RegularExpressions;

namespace FakerDotNet.Fakers
{
    public interface IFakeFaker
    {
        string F(string format);
    }

    internal class FakeFaker : IFakeFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public FakeFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string F(string format)
        {
            if (string.IsNullOrEmpty(format)) return string.Empty;

            var result = format;
            FakerMatch match;
            while ((match = ExtractMatchFrom(result)).Success)
            {
                var value = GetValue(match.Name, match.Method);
                var start = result.Substring(0, match.Index);
                var end = result.Substring(match.Index + match.Length);

                result = $"{start}{value}{end}";
            }

            return result;
        }

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

        private object GetValue(string faker, string method)
        {
            object value = null;
            switch (faker.ToLowerInvariant())
            {
                default:
                    throw new FormatException($"Invalid module: {faker}");
            }

            return value ?? throw new FormatException($"Invalid method: {faker}.{method}");
        }

        private struct FakerMatch
        {
            public bool Success;
            public int Index;
            public int Length;
            public string Name;
            public string Method;
        }
    }
}
