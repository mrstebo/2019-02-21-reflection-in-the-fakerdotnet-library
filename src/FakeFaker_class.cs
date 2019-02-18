
internal class FakeFaker : IFakeFaker
{
    private readonly IFakerContainer _fakerContainer;

    public FakeFaker(IFakerContainer fakerContainer)
    {
        _fakerContainer = fakerContainer;
    }

    public string F(string format)
    {
        if (string.IsNullOrEmpty(format))
            throw new FormatException("A string must be specified");

        var result = format;

        // Replace {FakerName.Method} placeholders to a values

        return result;
    }
}
