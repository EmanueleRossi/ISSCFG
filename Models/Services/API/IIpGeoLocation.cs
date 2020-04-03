using System.Net;

namespace ISSCFG.Models.Services.API
{
    public interface IIpGeoLocation
    {
        void LocateAddress(IPAddress address);
        string GetCoordinates();
        string GetCountryName();
        string GetCity();
        string GetOrganization();
    }
}