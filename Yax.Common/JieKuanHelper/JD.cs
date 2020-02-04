using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yax.Common.JieKuanHelper
{
    public  class JD
    {

        public static double CalFee(string months,string fees,int JieTime,double money,out double month_fee,out double month_pay)
        {
            string[] str_mons = months.Split(',');
            string[] str_lvs = fees.Split(',');
            string str_fei = "";
            for (int i = 0; i < str_mons.Count(); i++)
            {
                if (str_mons[i] == JieTime.ToString())
                {
                    str_fei = str_lvs[i];
                }
            }
            double db_lv = double.Parse(str_fei);               //日利率
            double day_fei = Math.Round(money * db_lv / 100,2); //日息
            double Month_fei = Math.Round(day_fei * 30, 2);     //月息
            double Month_pay = money / JieTime + Month_fei;      //月供
            Month_pay = Math.Round(Month_pay,2);

            month_fee = Month_fei;
            month_pay = Month_pay;
            return db_lv;
        }

        public static string GetJieKuanStateName(int idex)
        {
            switch (idex)
            {
                case 1:
                    return "审核未通过";
                case 2:
                    return "正在审核";
                case 3:
                    return "审核通过";
                case 4:
                    return "还款保证";
                case 5:
                    return "提现成功 ";
                case 6:
                    return "待激活账户 ";
                case 7:
                    return "贷款资金冻结 ";
                case 8:
                    return "收取保险费";
                case 9:
                    return "银行流水不足";
                case 10:
                    return "VIP加急到账";
                case 11:
                    return "二次通过";
                case 12:
                    return "订单退款";
                default:
                    return "审核未通过";
            }
        }


        public static string GetRzStateName(int idex)
        {
            switch(idex)
            {
                case 1:
                    return "未认证";
                case 2:
                    return "等待审核";
                case 3:
                    return "已认证";
                case 4:
                    return "审核不通过";
                default:
                    return "未认证";
            }
        }

        public static string GetMoneyDetailTypeName(int idex)
        {
            switch (idex)
            {
                case 1:
                    return "后台充值";
                case 2:
                    return "会员提现";
                default:
                    return "后台充值";
            }
        }
    }
}
