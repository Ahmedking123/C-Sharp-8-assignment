using System;
using System.Collections.Generic;
using System.Text;

namespace C_Sharp__8_assignment
{
    internal class DeliveryCenter
    {
        #region Fields

        private Shipment[] shipments;
        public string CenterName;

        #endregion
        #region Constructors

        public DeliveryCenter()
        {
            shipments = new Shipment[20];
        }

        #endregion
        #region Properties

        public Shipment this[int index]
        {
            get
            {
                if (shipments != null && index > 0 && index < 10)
                {
                    return shipments[index];
                }
                return default;

            }
            set
            {
                if (shipments != null && index > 0 && index < 10)
                {
                    shipments[index] = value;
                }
            }
        }
        public Shipment this[string trackingCode]
        {
            get
            {
                if (shipments != null)
                {
                    return shipments.FirstOrDefault(x => x.TrackingCode == trackingCode);
                }
                return default;
            }
        }

        #endregion
        #region Methods

        public bool AddShipment(Shipment shipment)
        {
            if (shipments != null)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] == null)
                    {
                        shipments[i] = shipment;
                        return true;
                    }
                }
            }
            return false;
        }
        public bool RemoveShipment(string TrackingCode)
        {
            if (Array.Exists(shipments, x => x.TrackingCode == TrackingCode))
            {
                int index = Array.FindIndex(shipments, x => x.TrackingCode == TrackingCode);
                shipments[index] = null!;
                return true;
            }
            return false;
        }
        public void PrintAllShipments()
        {
            if (shipments != null)
            {
                foreach (var shipment in shipments)
                {
                    if (shipment != null)
                    {
                        shipment.PrintShipment();
                        Console.WriteLine("--------------------");
                    }
                }
            }
        }
        public void PrintTrackingStatues(ITrackable[] items)
        {
            foreach (var t in items)
            {
                Console.WriteLine(t.GetTrackingStatus());
            }
        }
        public void PrintInsuranceCost(Iensurable[] items)
        {
            foreach (var i in items)
            {
                Console.WriteLine($"Shipment {i} insurance cost is: {i.CalculateInsurance()}");
            }
        }
        #endregion
    }
}
