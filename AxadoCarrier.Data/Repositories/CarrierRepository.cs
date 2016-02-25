using AxadoCarrier.Domain.Entities.Registers;
using System.Linq;

namespace AxadoCarrier.Data.Repositories
{
    public class CarrierRepository : RespositoryBase<Carrier>
    {
        public Carrier FindByEmail(string email) {
            try
            {
                return Db.Carrier.Where(x => x.Email == email).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}
