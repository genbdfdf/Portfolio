using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Rwork2
{
    internal class GlobalVar
    {
        public static string strDBConnectionString = "Data Source =.;Initial Catalog = SellingCentre;Integrated Security = True";
        public static string NowLoginID = "";
        public static string NowLoginName = "";
        public static int NowLoginclass = -1;//-1不存在,0非會員，1會員，2員工，3主管
        public static int NowLoginMemberLevel = -1;//-1不存在,0未設定，1普通會員，2好一點會員，3不錯的會員，4真會員，5神會員，6真神級會員，7停權
        public static int NowLoginPersonLevel = -1;
        public static List<ArrayList> ArrayListBuys = new List<ArrayList>();
    }
}
