namespace CameraBazaar.Data.Enums
{
    using System; 
     
    [Flags]
    public enum LightMetering
    {
        spot = 1,
        centerWeighted = 2,
        evaluative = 4
    }
}
