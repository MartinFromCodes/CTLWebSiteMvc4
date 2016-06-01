using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTL.Models
{
    public class UsersModel
    {
        private int uId;

        public int UId
        {
            get { return uId; }
            set { uId = value; }
        }
        private string uName;

        public string UName
        {
            get { return uName; }
            set { uName = value; }
        }
        private int uAge;

        public int UAge
        {
            get { return uAge; }
            set { uAge = value; }
        }
        private string uGender;

        public string UGender
        {
            get { return uGender; }
            set { uGender = value; }
        }
        private string u_Remark;

        public string U_Remark
        {
            get { return u_Remark; }
            set { u_Remark = value; }
        }
    }
}
