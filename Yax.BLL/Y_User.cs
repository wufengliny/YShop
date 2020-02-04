using System;
using System.Collections.Generic;
using System.Text;


namespace Yax.BLL
{
    public partial class Y_User
    {
        public readonly static Y_User Instance = new Y_User();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserAdd(model);
        }
        public int reg_phone(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserRegphone(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdate(model);
        }
        public int Update_RZ(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdateRZ(model);
        }
        public int Update_RZIDCard(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdateRZIDCard(model);
        }
        public int UpdateEnable(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdateEnable(model);
        }
        public int UpdateMoney(decimal money,int uid)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdateMoney(money,uid);
        }
        public int UpdateEnable_RZstate(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdateRZstate(model);
        }
        public int UpdateAddress(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdateAddress(model);
        }
        public int Update_info(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdate_info(model);
        }
        public int Update_BuC(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdate_BuC(model);
        }
        public int Update_Bank(string Bname,string BNO,string phone,int rzstate)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdate_Bank(Bname,BNO, phone, rzstate);
        }
        public int Update_info_member(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdate_info_Member(model);
        }
        public int Update_logininfo(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdate_logininfo(model);
        }
        public int Update_infoHT(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdate_infoHT(model);
        }
        public int Update_pwd(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdate_pwd(model);
        }

        public int UpdateErr(Model.Y_User model)
        {
            return SQLServerDAL.DataProvider.Instance.Y_UserUpdateErr(model);
        }
  
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Y_User", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Y_User GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByY_User(ID);
        }
        public Model.Y_User GetModelAccount(string Account)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByY_UserAccount(Account);
        }

        public Model.Y_User GetModelPhone(string Phone)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByY_UserPhone(Phone);
        }
        public Model.Y_User GetModelPhoneAndEffect(string Phone)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByY_UserPhoneAndEffect(Phone);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Y_User> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListY_User(top, fldName, strWhere, fldSort);
        }
        public List<Model.Y_User> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Y_User> list = new List<Model.Y_User>();
            list = SQLServerDAL.DataProvider.Instance.GetPageY_User(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
    }
}
