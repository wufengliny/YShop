using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Yax.BLL
{
    public partial class Power
    {
        public readonly static Power Instance = new Power();

        /// <summary>
        /// 添加数据
        /// </summary>
        public int Add(Model.Power model)
        {
            return SQLServerDAL.DataProvider.Instance.PowerAdd(model);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public int Update(Model.Power model)
        {
            return SQLServerDAL.DataProvider.Instance.PowerUpdate(model);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public int Delete(int ID)
        {
            string strWhere = string.Format("Id={0}", ID);
            return Yax.SqlHelper.DBHelper.Delete("Power", strWhere);
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        public Model.Power GetModel(int ID)
        {
            return SQLServerDAL.DataProvider.Instance.GetModelByPower(ID);
        }
        /// <summary>
        /// 读取数据,多条件
        /// </summary>
        public List<Model.Power> GetList(int top, string fldName, string strWhere, string fldSort)
        {
            return SQLServerDAL.DataProvider.Instance.GetListPower(top, fldName, strWhere, fldSort);
        }
        public List<Model.Power> GetPage(int pageIndex, int pageSize, string StrWhere, string orderString, string Field, out int TotalRecord, out int TotalPage)
        {
            List<Model.Power> list = new List<Model.Power>();
            list = SQLServerDAL.DataProvider.Instance.GetPagePower(pageIndex, pageSize, StrWhere, orderString, Field, out TotalRecord);
            TotalPage = TotalRecord / pageSize;
            if (TotalRecord % pageSize > 0)
            {
                TotalPage = TotalPage + 1;
            }
            return list;
        }
        //
        public int AddPowers(string SQLPower)
        {
            return SQLServerDAL.DataProvider.Instance.PowerAdd_list(SQLPower);
        }


        public List<Model.Power> GetPowerListCache(int roleID,string menutype)
        {
            List<Yax.Model.Power> list;
            object obj = Yax.Common.DataCache.GetCache("AdminPower" + roleID + menutype);
            if (obj == null)
            {
                int t1;
                int t2;
                string strwhere = "AdminGroupID=" + roleID + " and MenuType='"+ menutype + "'";
                list =this.GetPage(1, 1000, strwhere,"ID desc", "*", out t1, out t2);
                Yax.Common.DataCache.SetCache("AdminPower" + roleID + menutype, list);
            }
            else
            {
                list = (List<Yax.Model.Power>)obj;
            }
            return list;
        }
        //
        private  static Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> LoadMenuList(string adminxmlName)
        {
            Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> menulist = null;
            string filename =System.Web.HttpContext.Current.Server.MapPath("/Areas/Admin/Content/XML/" + adminxmlName + ".xml");
            if (System.IO.File.Exists(filename))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.XmlResolver = null;
                xmlDocument.Load(filename);
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("Menu/Module");
                StringBuilder sb = new StringBuilder();
                if (xmlNodeList != null && xmlNodeList.Count != 0)
                {
                    menulist = new Dictionary<string, Yax.Common.DataModelHelper.AdminMenu>();
                    Yax.Common.DataModelHelper.AdminMenu model = null;
                    foreach (XmlNode xmlNode in xmlNodeList)
                    {
                        model = new Yax.Common.DataModelHelper.AdminMenu();
                        model.ID = xmlNode.Attributes["ID"].Value;
                        model.Title = xmlNode.Attributes["Title"].Value;
                        model.Link = xmlNode.Attributes["Link"].Value;
                        model.Mark = xmlNode.Attributes["Mark"].Value;
                        model.ItemList = LoadItem(xmlNode);
                        menulist.Add(model.ID, model);
                    }
                }
            }
            return menulist;
        }

        private static Dictionary<string, Yax.Common.DataModelHelper.AdminMenuChild> LoadItem(XmlNode node)
        {
            XmlNodeList xmlNodeList = node.SelectNodes("Item");
            Dictionary<string, Yax.Common.DataModelHelper.AdminMenuChild> itemlist = new Dictionary<string, Yax.Common.DataModelHelper.AdminMenuChild>();
            if (xmlNodeList != null && xmlNodeList.Count > 0)
            {
                Yax.Common.DataModelHelper.AdminMenuChild model = null;
                foreach (XmlNode xmlNode in xmlNodeList)
                {
                    model = new Yax.Common.DataModelHelper.AdminMenuChild();
                    model.ID = xmlNode.Attributes["ID"].Value;
                    model.Title = xmlNode.Attributes["Title"].Value;
                    model.Link = xmlNode.Attributes["Link"].Value;
                    model.Icon = xmlNode.Attributes["Icon"].Value;
                    model.Mark = xmlNode.Attributes["Mark"].Value;
                    itemlist.Add(model.ID, model);
                }
            }
            return itemlist;
        }

        public static Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> LoadMenuListFromCache()
        {
            Dictionary<string, Yax.Common.DataModelHelper.AdminMenu> menulist = null;
            string adminxmlName = new Yax.BLL.Config().GetModelBy_key("htmenutype").Value;
            object obj = Yax.Common.DataCache.GetCache("XmlMenu"+adminxmlName);
            if (obj == null)
            {
                menulist = LoadMenuList(adminxmlName);
                Yax.Common.DataCache.SetCache("XmlMenu" + adminxmlName, menulist);
            }
            else
            {
                menulist=(Dictionary<string, Yax.Common.DataModelHelper.AdminMenu>)obj;
            }
            return menulist;
        }
        //





    }
}
