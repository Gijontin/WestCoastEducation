namespace WestCoastEducation;

public interface IPurchasable //osäker om detta är för statiskt för att implementera, interface är fanimej så jäävla styvt...
{
    public decimal StandardPrice { get; } //framtida regional pricing because ethixxmaxxin'...
    public string Currency { get; }
}