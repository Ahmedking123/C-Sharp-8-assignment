using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp__8_assignment
{
    internal abstract class Shipment
    {
        #region Fields

        private string? _trackingCode;
        private string _description;
        private decimal _weight;
        private decimal _DeliveryFee;

        #endregion
        #region Properties

        public string? TrackingCode
        {
            get
            {
                return _trackingCode;
            }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _trackingCode = value;
                }
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _description = value;
                }
            }
        }
        public decimal Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value > 0)
                {
                    _weight = value;
                }
            }
        }
        public decimal DeliveryFee
        {
            get
            {
                return _DeliveryFee;
            }
            set
            {
                if (value > 0)
                {
                    _DeliveryFee = value;
                }
            }
        }
        public DeliveryAddress Destination { get; set; }
        public abstract decimal EstimatedCost { get; }

        #endregion
        #region Constructors

        public Shipment(string trackingCode)
        {
            TrackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = default;
        }
        public Shipment(string trackingCode, string description, decimal weight, decimal delivaryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = delivaryFee;
            Destination = destination;
        }

        #endregion
        #region Methods
        public void UpdateDelivaryFee(decimal newDelivaryFee)
        {
            if (newDelivaryFee > 0)
            {
                DeliveryFee = newDelivaryFee;
            }
        }
        public abstract void PrintShipment();

        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }
        public void UpdateWeight(decimal newWeight, decimal extraWeight)
        {
            if (newWeight > 0 && extraWeight > 0)
            {
                Weight = newWeight + extraWeight;
            }
        }

        #endregion
    }
}
