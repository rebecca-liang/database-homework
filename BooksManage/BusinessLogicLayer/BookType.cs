using System;
using System.Collections.Generic;
using System.Text;


using System.Data ;
using System.Data .SqlClient;
using DataAccessLayer;
using Model;

namespace BusinessLogicLayer
{
    public class bllBookType
    {
        dalBookType DALbt=new dalBookType ();
        public DataSet GetBookType()
        {
            return DALbt.GetDS();

        }

    }
}
