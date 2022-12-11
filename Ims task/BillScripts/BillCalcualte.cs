namespace Ims_task.BillScripts
{
    public class BillCalculate
    {
        public int unit { get; set; }

        public BillCalculate(int unit)
        {
            this.unit = unit;
        }

        public decimal GetServiceCharge()
        {
            if (unit <= 20)
            {
                return 30;
            }
            else if (unit <= 50)
            {
                return 50;
            }
            else if (unit <= 100)
            {
                return 75;
            }
            else if (unit <= 200)
            {
                return 100;
            }
            return 150;
        }
        public decimal GetEnergyCharge()
        {
            if (unit <= 10)
            {
                return 0;
            }
            else if (unit <= 20)
            {
                return (unit - 10) * 3;
            }
            else if (unit <= 30)
            {
                return (decimal)(30 + (unit - 20) * 6.5);
            }
            else if (unit <= 50)
            {
                return 95 + (unit - 30) * 8;
            }
            else if (unit <= 100)
            {
                return 255 + (unit - 50) * 9;
            }
            else if (unit <= 200)
            {
                return 700 + (unit - 100) * 10;
            }
            return 1700 + (unit - 100) * 11;
        }
    }
}
