using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace aed.org.mt.Models
{
    public class AEDEntity : TableEntity
    {
        public AEDEntity(string partitionKey, string locationName, string personInCharge, string mobile, double latitude, double longitude, bool isApproved)
        {
            PartitionKey = partitionKey;
            RowKey = Guid.NewGuid().ToString();

            LocationName = locationName;
            PersonInCharge = personInCharge;
            Mobile = mobile;
            Latitude = latitude;
            Longitude = longitude;
            IsApproved = isApproved;
        }

        public AEDEntity() { }

        public string LocationName { get; set; }
        public string PersonInCharge { get; set; }
        public string Mobile { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsApproved { get; set; }
    }
}
