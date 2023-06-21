using System;
namespace ConsoleAppTestTask
{
    public class Pallet : Item

    {

        public List<Box> Boxes { get; set; }
        public DateTime? ExpirationDate
        {
            get
            {
                if (Boxes != null && Boxes.Count > 0)
                {
                    DateTime? minExpirationDate = Boxes.Min(b => b.ExpirationDate);
                    if (minExpirationDate.HasValue)
                    {
                        return minExpirationDate;
                    }
                }
                return null;
            }
        }

        public double TotalWeight
        {
            get
            {
                double totalWeight = 30; // 30kg for the pallet itself
                if (Boxes != null && Boxes.Count > 0)
                {
                    totalWeight += Boxes.Sum(b => b.Weight);
                }
                return totalWeight;
            }
        }

        public double TotalVolume
        {
            get
            {
                double totalVolume = Width * Height * Depth;
                if (Boxes != null && Boxes.Count > 0)
                {
                    totalVolume += Boxes.Sum(b => b.Width * b.Height * b.Depth);
                }
                return totalVolume;
            }
        }

    }

}

