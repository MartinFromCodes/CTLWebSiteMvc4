using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTL.Models;
using CTL.DAL;
using System.Data;

namespace CTL.BLL
{
    public class SysUserInfo
    {
		public static readonly UsersInfoMessage message = new UsersInfoMessage();
		
		public static  List<UsersModel> UsersList()
        {
			return message.UsersList();
        
        }

		public static DataTable GetUsers()
		{
			return message.GetUsers();

		}

	
        
    }
}
