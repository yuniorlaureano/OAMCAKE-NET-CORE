using OamCake.Data.Context;
using OamCake.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OamCake.Repository
{
    public interface ISupplyRepository: IRepository<Supply>
    {

    }

    public class SupplyRepository : Repository<Supply>, ISupplyRepository
    {
        public SupplyRepository(OamCakeContext oamCakeContext) : base(oamCakeContext) { }
    }
}
