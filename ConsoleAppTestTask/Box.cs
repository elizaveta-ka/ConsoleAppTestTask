using System;
namespace ConsoleAppTestTask
{
	public class Box : Item
	{
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate
        {
            get
            {
                if (ProductionDate.HasValue)
                {
                    return ProductionDate.Value.AddDays(100);
                }
                return null;
            }
        }

    }
}

