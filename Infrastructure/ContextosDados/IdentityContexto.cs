using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JdMarketplace.Infra.ContextosDados
{
    public class CatalogoContexto : IdentityDbContext
    {
        public CatalogoContexto(DbContextOptions<CatalogoContexto> options) : base(options) { }
    }
}
