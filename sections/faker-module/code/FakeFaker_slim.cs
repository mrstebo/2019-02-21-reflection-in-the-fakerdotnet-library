internal class FakeFaker : IFakeFaker
{
    private readonly IFakerContainer _fakerContainer;

    public FakeFaker(IFakerContainer fakerContainer)
    {
        _fakerContainer = fakerContainer;
    }

    public string F(string format)
    {
        // ...
    }
}
