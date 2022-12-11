

using Ims_task.Model;

namespace Ims_task.TariffDB
{
    public interface ITariffService
    {
        void AddTariff(int id, int startUnit, int endUnit, decimal energyRate, decimal serviceCharge);

        void UpdateTariff(int id, int startUnit, int endUnit, decimal energyRate, decimal serviceCharge);

        TariffMaster getTariff(int id);
        IList<TariffMaster> getTariffs();
    }
}
