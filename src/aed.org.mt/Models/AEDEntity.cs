using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace aed.com.mt.Models
{
    public class AEDEntity : TableEntity
    {
        public AEDEntity(string name, string mobile, double latitude, double longitude)
        {
            this.PartitionKey = "Malta";
            this.RowKey = Guid.NewGuid().ToString();

            this.Name = name;
            this.Mobile = mobile;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public AEDEntity() { }

        public string Name { get; set; }
        public string Mobile { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
