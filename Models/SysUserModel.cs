using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTL.Models
{

    public class SysUserModel
    {
        private string userId;

        private string userName;

        private bool isAdmin;

        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        private string password;

        private string imageID;

        public string ImageID
        {
            get { return imageID; }
            set { imageID = value; }
        }
        private bool runMsn;

        public bool RunMsn
        {
            get { return runMsn; }
            set { runMsn = value; }
        }
        private bool independentMsn;

        public bool IndependentMsn
        {
            get { return independentMsn; }
            set { independentMsn = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }



        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

       

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }



        

         

        
    }
}
