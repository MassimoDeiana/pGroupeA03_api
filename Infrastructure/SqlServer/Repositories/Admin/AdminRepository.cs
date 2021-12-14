using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repositories.Admin
{
    public partial class AdminRepository : EntityRepository<Domain.Admin>
    {
        public AdminRepository(AdminFactory factory) : base(factory)
        {
        }

        public override Domain.Admin Create(Domain.Admin t)
        {
            throw new NotImplementedException();
        }
    }
}