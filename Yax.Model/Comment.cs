using System;
namespace Yax.Model
{
    /// <summary>
    /// 实体类Comment(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Comment
    {
        public Comment()
        { }
        #region Model
        private int _id;
        private int _goodid;
        private int _uid;
        private int _commenttype;
        private string _message;
        private int _pid;
        private string _uname;
        private int _utype;
        private string _img;
        private string _img2;
        private string _img3;
        private int _stars;
        private int _enable;
        private DateTime _addtime;
        private string _orderno;
        private int _orderitemid;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int GoodID
        {
            set { _goodid = value; }
            get { return _goodid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UID
        {
            set { _uid = value; }
            get { return _uid; }
        }
        /// <summary>
        /// 1:好评 2 中评   3差评
        /// </summary>
        public int CommentType
        {
            set { _commenttype = value; }
            get { return _commenttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PID
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 评论者名称
        /// </summary>
        public string UName
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 1:会员评论 2 管理员回复
        /// </summary>
        public int UType
        {
            set { _utype = value; }
            get { return _utype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Img
        {
            set { _img = value; }
            get { return _img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Img2
        {
            set { _img2 = value; }
            get { return _img2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Img3
        {
            set { _img3 = value; }
            get { return _img3; }
        }
        /// <summary>
        /// 星星 
        /// </summary>
        public int Stars
        {
            set { _stars = value; }
            get { return _stars; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderNO
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderItemID
        {
            set { _orderitemid = value; }
            get { return _orderitemid; }
        }




        //view
        private string _goodName;

        public string GoodName
        {
            get { return _goodName; }
            set { _goodName = value; }
        }

        private string _goodImg;

        public string GoodImg
        {
            get { return _goodImg; }
            set { _goodImg = value; }
        }
        #endregion Model
    }
}
