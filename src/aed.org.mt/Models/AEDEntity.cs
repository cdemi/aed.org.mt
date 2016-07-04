using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace aed.com.mt.Models
{
    public class AEDEntity : TableEntity
    {
        public AEDEntity(string locationName, string personInCharge, string mobile, double latitude, double longitude)
        {
            PartitionKey = "Malta";
            RowKey = Guid.NewGuid().ToString();

            LocationName = locationName;
            PersonInCharge = personInCharge;
            Mobile = mobile;
            Latitude = latitude;
            Longitude = longitude;
        }

        public AEDEntity() { }

        public string LocationName { get; set; }
        public string PersonInCharge { get; set; }
        public string Mobile { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
