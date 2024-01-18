using DataLayer;
using DataLayer.Shared;

namespace BusinessLayer
{
    public class PharaBusiness
    {
        PharmaRepo repo= new PharmaRepo();

        public List<Prescriptions> GetPrescriptions()
        {
            return repo.GetPrescriptions();
        }
        public int SetPrescriptions(Prescriptions prescriptions)
        {
            return repo.InsertPrescriptions(prescriptions);
        }

    }
}
