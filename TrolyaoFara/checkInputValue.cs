using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrolyaoFara
{
    class checkInputValue
    {
        private bool checkInputBody(string strCheck, int min, int max, string mes)
        {
            bool check = !string.IsNullOrEmpty(strCheck);
            if (check)
            {
                int valueCheck = Convert.ToInt32(strCheck);
                if (min >= valueCheck || valueCheck > max)
                {
                    check = false;
                    alert.Show(string.Format("'{0}' không hợp lệ!", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(mes.ToLower())), alert.AlertType.error);
                }
            }
            else
                alert.Show(string.Format("Vui lòng nhập '{0}'!", mes), alert.AlertType.error);
            return check;
        }

        public bool validateOld(string strOld)
        {
            return checkInputBody(strOld, 0, 130, "tuổi");
        }

        public bool validateHeight(string strHeight)
        {
            return checkInputBody(strHeight, 0, 260, "chiều cao");
        }

        public bool validateWeight(string strWeight)
        {
            return checkInputBody(strWeight, 0, 600, "cân nặng");
        }

        public bool validateNeck(string strNeck)
        {
            return checkInputBody(strNeck, 10, 200, "số đo vòng cổ");
        }

        public bool validateWaist(string strWaist)
        {
            return checkInputBody(strWaist, 33, 250, "số đo vòng 2");
        }

        public bool validateHip(string strHip)
        {
            return checkInputBody(strHip, 33, 250, "số đo vòng 3");
        }
    }
}
