using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTL.Models;


namespace CTL.DAL
{

    public interface ISysUser
    {
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="Custom"></param>
        /// <returns></returns>
        int Addcustom(SysUserModel Custom);
        /// <summary>
        /// 概据帐户名获取用户的信息
        /// </summary>
        /// <param name="nename"></param>
        /// <returns></returns>
        SysUserModel Getsinglecname(string nename);
        /// <summary>
        /// 更样用户的密码
        /// </summary>
        /// <param name="Custom"></param>
        void Updatepassword(SysUserModel Custom);
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        List<SysUserModel> Getcustom();
        /// <summary>
        /// 根据ID删除用户记录
        /// </summary>
        /// <param name="nid"></param>
        void Deletecustom(int nid);
        /// <summary>
        /// 根据ID获取用户信息
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        SysUserModel Getcustomer(int nid);
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="Custom"></param>
        void updatecustom(SysUserModel Custom);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        List<SysUserModel> Getdepartcustom(int nid);
    }
}
