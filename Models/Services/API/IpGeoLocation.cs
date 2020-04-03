using System.Net;
using IPGeolocation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ISSCFG.Models.Services.API
{
    public class IpGeoLocation : IIpGeoLocation
    {
        private readonly ILogger<IpGeoLocation> Logger; 
        private readonly IPGeolocationAPI Api;
        private Geolocation geoInfo; 

        public IpGeoLocation(IConfiguration configuration, ILogger<IpGeoLocation> logger)
        {
            Logger = logger;
            Api = new IPGeolocationAPI(configuration.GetValue<string>("IpGeoLocationAPIKey"));
        }

        public void LocateAddress(IPAddress address)
        {
            Logger.LogDebug($"address=|{address.ToString()}|");
            if (!IPAddress.IsLoopback(address))
            {
                GeolocationParams geoParams = new GeolocationParams();                                  
                geoParams.SetIp(address.ToString());
                geoInfo = Api.GetGeolocation(geoParams);
                if(geoInfo.GetStatus() != (int)HttpStatusCode.OK) 
                    Logger.LogError(geoInfo.GetMessage());
            }                                            
        }

        public string GetCoordinates()
        {
            return geoInfo != null ? $"{geoInfo.GetLatitude()},{geoInfo.GetLongitude()}" : string.Empty;
        }

        public string GetCountryName()
        {
            return geoInfo != null ? geoInfo.GetCountryName() : string.Empty;
        }

        public string GetCity()
        {
            return geoInfo != null ? geoInfo.GetCity() : string.Empty;
        }

        public string GetOrganization()
        {
            return geoInfo != null ? geoInfo.GetOrganization() : string.Empty;
        } 
    }
}