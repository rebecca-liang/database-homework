using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class UserInfo
    {
        private string _userID;
        private string _userName;
        private string _usePassword;
        private bool _gender;
        private string _userDepartment;
        private string _userAddress;
        private string _userPhone;
        private DateTime  _userBirthdate;
        private int _roleID;


        public UserInfo()
        {
        }


        #region  Ù–‘
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
                this._usePassword = value;
            }
            get
            {
                return this._usePassword;
            }
        }
        public bool Gender
        {
            set
            {
                this._gender = value;
            }
            get
            {
                return this._gender;
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
        public DateTime  UserBirthdate
        {
            set
            {
                this._userBirthdate = value;

            }
            get
            {
                return this._userBirthdate;
            }
        }
        public int  RoleID
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



    }
}
