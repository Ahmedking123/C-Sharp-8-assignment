using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp__8_assignment
{
    internal class InternationalShipment : Shipment, ITrackable, Iensurable
    {
        public decimal CalculateInsurance()
        {
            return Weight * 0.12m;
        }

        public string GetTrackingStatus()
        {
            return $"Shipment {TrackingCode} has beed delivered";
        }
        #region Fields

        private string _destinationCountry;
        private decimal _customsFee;

        #endregion
        #region Properties

        public string DestinationCountry
        {
            get
            {
                return _destinationCountry;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value != "")
                {
                    _destinationCountry = value;
                }
            }
        }
        public decimal CustomsFee
        {
            get
            {
                return _customsFee;
            }
            set
            {
                if (value >= 0)
                {
                    _customsFee = value;
                }
            }
        }
        public override decimal EstimatedCost => DeliveryFee + (Weight * 5) + CustomsFee;

        #endregion
        #region Constructors

        public InternationalShipment(string trackingCode, string description, decimal weight, decimal delivaryFee, DeliveryAddress destination, string destinationCountry, decimal CustomsFee) : base(trackingCode, description, weight, delivaryFee, destination)
        {
            DestinationCountry = destinationCountry;
            this.CustomsFee = CustomsFee;
        }

        #endregion
        #region Methods

        public override void PrintShipment()
        {
            Console.WriteLine("International shipment \n");
            Console.WriteLine($"""
                Tracking Code: {TrackingCode}
                Description: {Description} 
                Weight: {Weight}
                Delivery Fee: {DeliveryFee}
                Destination: {Destination.GetFullAddress()}
                Estimated Cost: {EstimatedCost} EGP
                """);
            Console.WriteLine($"Destination Country: {DestinationCountry}");
            Console.WriteLine($"Customs Fee: {CustomsFee:C}");
        }
        public virtual void GenerateCustomsReports()
        {
            Console.WriteLine($"Customs report for Shipment: {TrackingCode}, CustomsFee: {CustomsFee:C}");
        }

        #endregion
    }
}
