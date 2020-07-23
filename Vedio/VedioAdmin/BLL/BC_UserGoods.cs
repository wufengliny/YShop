using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
namespace BLL
{
    public class BC_UserGoods
    {
        DC_UserGoods dal = new DC_UserGoods();
        public int Add(MC_UserGoods model)
        {
            return dal.Add(model);
        }
        public int Delete(int VedioID, int UID)
        {
            return dal.Delete(VedioID,UID);
        }
        public MC_UserGoods GetModel(int VedioID, int UID)
        {
            return dal.GetModel(VedioID,UID);
        }
    }
}
