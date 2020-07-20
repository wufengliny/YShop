using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;

namespace BLL
{
    public class BS_UserLoginIP
    {
        DS_UserLoginIP dal = new DS_UserLoginIP();
        public int Add(MS_UserLoginIP model)
        {
            return dal.Add(model);
        }
        public int CountByUID(int UID)
        {
            return dal.CountByUID(UID);
        }
        public MS_UserLoginIP GetModelByIPUID(string IP, int UID)
        {
            return dal.GetModelByIPUID(IP, UID);
        }
        public MS_UserLoginIP UpdateCount(int ID)
        {
            return dal.UpdateCount(ID);
        }
    }
}
