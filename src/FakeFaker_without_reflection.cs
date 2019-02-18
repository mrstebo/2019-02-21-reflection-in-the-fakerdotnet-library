using System;
using System.Diagnostics;
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
            if (string.IsNullOrEmpty(format)) throw new FormatException("A string must be specified");

            var result = format;
            Match match;
            while ((match = Regex.Match(result, @"\{(\w+).(\w+)\}")).Success)
            {
                var (faker, method) = ExtractMatchDataFrom(match);
                var value = GetValue(faker, method);

                result = $"{result.Substring(0, match.Index)}{value}{result.Substring(match.Index + match.Length)}";
            }

            return result;
        }

        private object GetValue(string faker, string method)
        {
            object value = null;
            switch (faker.ToLowerInvariant())
            {
                case "app":
                    value = GetValueForAppFaker(method);
                    break;

                case "name":
                    value = GetValueForNameFaker(method);
                    break;

                default:
                    throw new FormatException($"Invalid module: {faker}");
            }

            return value ?? throw new FormatException($"Invalid method: {faker}.{method}");
        }

        private static (string faker, string method) ExtractMatchDataFrom(Match match)
        {
            var className = match.Groups[1].Value;
            var methodName = match.Groups[2].Value;

            return (className, methodName);
        }

        private object GetValueForAppFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "name":
                    return _fakerContainer.App.Name();

                case "version":
                    return _fakerContainer.App.Version();

                case "author":
                    return _fakerContainer.App.Author();

                default:
                    return null;
            }
        }

        private object GetValueForNameFaker(string method)
        {
            switch (method.ToLowerInvariant())
            {
                case "firstname":
                    return _fakerContainer.Name.FirstName();

                case "lastname":
                    return _fakerContainer.Name.LastName();

                case "name":
                    return _fakerContainer.Name.Name();

                case "namewithmiddle":
                    return _fakerContainer.Name.NameWithMiddle();

                case "prefix":
                    return _fakerContainer.Name.Prefix();

                case "suffix":
                    return _fakerContainer.Name.Suffix();

                case "title":
                    return _fakerContainer.Name.Title();

                default:
                    return null;
            }
        }
    }
}
