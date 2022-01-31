namespace CameraBazaar.Web.Infrastructure.Extentions
{
    using CameraBazaar.Data.Enums;
    public static class DisplayNameExtention
    {
        public static string DisplayName (this LightMetering lightMetering)
        {
            if (lightMetering.ToString() == "centerWeighted")
            {
                return "Center-Weighted";
            }

            return lightMetering.ToString();
        }
    }
}
