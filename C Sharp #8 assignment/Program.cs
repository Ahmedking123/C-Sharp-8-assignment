using System.Dynamic;

namespace C_Sharp__8_assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region First Question
            // Q1/ Abstraction is the process of hiding the implementation details and showing only the features only
            // Q2/Because it reduces the complixity and enhances the reusability and security of the code 
            #endregion

            #region Practical

            DeliveryCenter deliveryCenter = new DeliveryCenter();
           
            
            for (int i = 1; i <= 3; i++)
            {
                string TrackingCode = Console.ReadLine()!;
                string Description = Console.ReadLine()!;
                decimal Weight = decimal.Parse(Console.ReadLine()!);
                decimal DeliveryFee = decimal.Parse(Console.ReadLine()!);
                string City = Console.ReadLine()!;
                string street = Console.ReadLine()!;
                int buildingNumber = int.Parse(Console.ReadLine()!);
                DeliveryAddress deliveryAddress = new DeliveryAddress(City, street, buildingNumber);

                if (i == 1)
                {
                    StandardShipment standardShipment = new StandardShipment(TrackingCode, Description, Weight, DeliveryFee, deliveryAddress);
                    deliveryCenter.AddShipment(standardShipment);
                }
                else if (i == 2)
                {
                    decimal ExtraFee = decimal.Parse(Console.ReadLine()!);
                    ExpressShipment expressShipment = new ExpressShipment(TrackingCode, Description, Weight, DeliveryFee, deliveryAddress, ExtraFee);
                    deliveryCenter.AddShipment(expressShipment);
                }
                else
                {
                    string DestinationCountry = Console.ReadLine()!;
                    decimal CustomFee = decimal.Parse(Console.ReadLine()!);
                    InternationalShipment internationalShipment = new InternationalShipment(TrackingCode, Description, Weight, DeliveryFee, deliveryAddress, DestinationCountry, CustomFee);
                    deliveryCenter.AddShipment(internationalShipment);
                }
                Console.WriteLine("Shipment added successfully.");
            }

            for (int i = 0; i < 3;i++)
            {
                deliveryCenter[i].PrintShipment();
            }

            for (int i = 0; i < 3; i++)
            {
                if (deliveryCenter[i] is ITrackable)
                {
                    ITrackable trackableShipment = deliveryCenter[i] as ITrackable;
                    Console.WriteLine(trackableShipment.GetTrackingStatus());
                }
            }

            for (int i = 0;i < 3; i++)
            {
                if (deliveryCenter[i] is Iensurable)
                {
                    Iensurable ensurableShipment = deliveryCenter[i] as Iensurable;
                    Console.WriteLine(ensurableShipment.CalculateInsurance());
                }
            }

            ITrackable[] Shipments = new ITrackable[] 
            { (ITrackable)deliveryCenter[0], (ITrackable)deliveryCenter[1], (ITrackable)deliveryCenter[2] };
            
            deliveryCenter.PrintTrackingStatues(Shipments);

            Iensurable[] ensurableShipments = new Iensurable[]
            { (Iensurable)deliveryCenter[0], (Iensurable)deliveryCenter[1], (Iensurable)deliveryCenter[2] };
            deliveryCenter.PrintInsuranceCost(ensurableShipments);
            #endregion
        }
    }
}
