using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entity;
using Webdiyer.WebControls.Mvc;

namespace BLL
{
    public class BC_Vedios
    {
        DC_Vedios dal = new DC_Vedios();
        public PagedList<MC_Vedios> Pager(int pageIndex, int pageSize, string strWhere, string strOrder)
        {
            List<object> list = dal.Pager(pageIndex, pageSize, strWhere, strOrder);
            PagedList<MC_Vedios> pl = new PagedList<MC_Vedios>((List<MC_Vedios>)list[1], pageIndex, pageSize, int.Parse(list[0].ToString()));
            return pl;
        }
        public int Add(MC_Vedios model)
        {
            return dal.Add(model);
        }
        public int Update(MC_Vedios model)
        {
            return dal.Update(model);
        }
        public MC_Vedios GetModelByID(int ID)
        {
            return dal.GetModelByID(ID);
        }
        public MC_Vedios GetModelByUrl(string Url)
        {
            return dal.GetModelByUrl(Url);
        }
        public int GetMaxSort()
        {
            MC_Vedios model = dal.GetMaxSort();
            if(model==null)
            {
                return 100000;
            }
            else
            {
                return model.Sort;
            }
        }
        /// <summary>
        /// 软删除 或还原 进回收站
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateEnable(int ID, int Enable)
        {
            return dal.UpdateEnable(ID,Enable);
        }
        /// <summary>
        /// 硬删除  无法恢复
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteHard(int ID)
        {
            return dal.DeleteHard(ID);
        }
        public int UpdatePrice(int ID, decimal price)
        {
            return dal.UpdatePrice(ID,price);
        }
        public int UpdateTop(int ID, int istop)
        {
            return dal.UpdateTop(ID,istop);
        }
        public int UpdateHit(int ID)
        {
            return dal.UpdateHit(ID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="AddOrCancel">1 加 2 减</param>
        /// <returns></returns>
        public int UpdateLike(int ID, int AddOrCancel)
        {
            return dal.UpdateLike(ID,AddOrCancel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="AddOrCancel">1 加 2 减</param>
        /// <returns></returns>
        public int UpdateGoods(int ID, int AddOrCancel)
        {
            return dal.UpdateGoods(ID, AddOrCancel);
        }
    }
}
