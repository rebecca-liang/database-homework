using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;


namespace BusinessLogicLayer
{
    public class Users
    {
        #region  ˽�г�Ա

        private string _userID;                     //�û����
        private string _userName;
        private string _userPassword;
        private bool _userGender;
        private string _userDepartment;
        private string _userAddress;
        private string _userPhone;
        private string _userBirthday;
        private int _roleID;

        #endregion



        #region ����
        public string UserID
        {
            set
            {
                this._userID = value;
            }
            get
            {
                return this._userID;
            }
        }
        public string UserName
        {
            set
            {
                this._userName = value;
            }
            get
            {
                return this._userName;
            }
        }
        public string UserPassword
        {
            set
            {
                this._userPassword = value;

            }
            get
            {
                return this._userPassword;

            }
        }
        public bool UserGender
        {
            set
            {
                this._userGender = value;

            }
            get
            {
                return this._userGender;

            }
        }
        public string UserDepartment
        {
            set
            {
                this._userDepartment = value;

            }
            get
            {
                return this._userDepartment;

            }
        }
        public string UserAddress
        {
            set
            {
                this._userAddress = value;

            }
            get
            {
                return this._userAddress;

            }
        }
        public string UserPhone
        {
            set
            {
                this._userPhone = value;

            }
            get
            {
                return this._userPhone;

            }
        }
        public string UserBirthday
        {
            set
            {
                this._userBirthday = value;

            }
            get
            {
                return this._userBirthday;

            }
        }
        public int RoleID
        {
            set
            {
                this._roleID = value;

            }
            get
            {
                return this._roleID;

            }
        }
        #endregion
        
        
        
        
        //public bool CheckPassword(string XUserID)
        //{
        //    string sqlStr = "select * from User WHERE userID='" + XUserID + "'";
        //    DataBase db = new DataBase();
        //    if (db. GetRecord(sqlStr))
        //    {
        //        return true;
        //    }
        //    else
        //        return false;

        //}


        //����UserID��UserPassword�ж������Ƿ���ȷ
        //���룺
        //      XUserID - �û����
        //�����
        //      �û����ڣ�����True��
        //      �û����ڣ�����False��
        public bool CheckPassword(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[1];
            DataBase DB = new DataBase();
            Params[0] = DB.MakeInParam("@UserID", SqlDbType.VarChar, 50, XUserID);                            

            SqlDataReader DR = DB.RunProcGetReader("Proc_UsersDetail", Params);
            if (!DR.Read())
            {
                return false;
            }
            else
            {
                this._userPassword = DR["userPassword"].ToString();
                this._roleID = int.Parse(DR["roleID"].ToString());
                return true;
            }
        }


        public DataSet GetUserInfoByID(string XuserID)
        {
            DataSet ds = new DataSet();
            UserID = XuserID;
            DataBase DB = new DataBase();
            SqlParameter[] Params = new SqlParameter[1];
            Params[0] = DB.MakeInParam("@UserID", SqlDbType.NVarChar, XuserID.Length, UserID);
            ds = DB.GetDataSet("Proc_UsersDetail", Params);
            return ds;

        }

       



        public bool  AddUser(string   XInsertStr)
        {
            DataBase DB = new DataBase();
            int val=DB.ExecuteNonQuery(XInsertStr);
            if (val == 0)
                return false;
            else
                return  true;
        }


        public DataSet GetBorrowBook(string userID)
        {
            DataBase DB = new DataBase();
            SqlParameter[] Params = new SqlParameter[] { DB.MakeInParam("@userID", SqlDbType.NVarChar, userID.Length, userID) };
            DataSet ds = DB.GetDataSet("Proc_GetCurrentBorrow", Params);
            return ds;

        }
        /// <summary>
        /// ��ѯ����ע���û�
        /// </summary>
        /// <returns>����users�Ľ����</returns>
        public DataSet QueryUsers()
        {
            DataBase DB = new DataBase();   
            DataSet ds = DB.GetDataSet("Proc_GetUsers");

            return ds;

        }

        //ɾ���û�
        //���룺
        //      XUserID - �û���ţ�
        //�����
        //      ɾ���ɹ�������True��
        //      ɾ��ʧ�ܣ�����False��
        public bool DeleteByProc(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[1];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@userID", SqlDbType.VarChar, 50, XUserID);               //�û����          

            int Count = -1;
            Count = DB.RunProc("Proc_DeleteUsers", Params);
            if (Count > 0)
                return true;
            else 
                return false;
        }

        //����Ա�����û�����Ϣ
        public bool UpdateByProc(string XUserID)
        {
            SqlParameter[] Params = new SqlParameter[6];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@userID", SqlDbType.VarChar, 50, XUserID);               //�û����            
            Params[1] = DB.MakeInParam("@roleID", SqlDbType.SmallInt, 2, RoleID);         //�û�Ȩ��
            Params[2] = DB.MakeInParam("@userName", SqlDbType.VarChar, 50, UserName);           //�û�����            
            Params[3] = DB.MakeInParam("@userDepartment", SqlDbType.VarChar, 50, UserDepartment);        //�û�ϵԺ
            Params[4] = DB.MakeInParam("@userGender", SqlDbType.Bit,2, UserGender); //�û��绰
            Params[5] = DB.MakeInParam("@userAddress", SqlDbType.VarChar, 50, UserAddress);         //�û�EMail

            int Count = -1;
            Count = DB.RunProc("Proc_UpdateUser", Params);
            if (Count > 0)
                return true;
            else return false;
        }
        //������ɫ��ͬ���޸Ĺ���
        public bool UpdateUserComm(string XUserID)
        {
            

            SqlParameter[] Params = new SqlParameter[4];

            DataBase DB = new DataBase();

            Params[0] = DB.MakeInParam("@userID", SqlDbType.VarChar, 50, XUserID);               //�û����            
            Params[1] = DB.MakeInParam("@userDepartment", SqlDbType.VarChar, 50, UserDepartment);        //�û�ϵԺ
            Params[2] = DB.MakeInParam("@userAddress", SqlDbType.VarChar, 50, UserAddress);         //�û�EMail
            Params[3] = DB.MakeInParam("@userPhone", SqlDbType.VarChar, 50, UserPhone);           //�û�����            
           

            int Count = -1;
            Count = DB.RunProc("Proc_UpdateUserInfo", Params);
            if (Count > 0)
                return true;
            else return false;

        }

        public DataSet GetBorrowHistory(string XUserID)
        {
            DataBase DB = new DataBase();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = DB.MakeInParam("@userID", SqlDbType.VarChar, 50, XUserID);

            DataSet ds = new DataSet();
            ds = DB.GetDataSet("Proc_GetBorrowHistory", param);
            return ds;
        }



    }
}
