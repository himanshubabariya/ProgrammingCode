using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace ProgrammingCode.DAL
{
    public abstract class MST_DALBase : DALHelper
    {

        #region Method: dbo_PR_UMS_Demo_DeleteByPK
        public bool? dbo_PR_UMS_Demo_DeleteByPK(int? DemoID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_UMS_Demo_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "DemoID", SqlDbType.Int, DemoID);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_UMS_Demo_Insert
        public decimal? dbo_PR_UMS_Demo_Insert(string FirstName, string MiddleName, string LastName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_UMS_Demo_Insert");
                sqlDB.AddInParameter(dbCMD, "FirstName", SqlDbType.VarChar, FirstName);
                sqlDB.AddInParameter(dbCMD, "MiddleName", SqlDbType.VarChar, MiddleName);
                sqlDB.AddInParameter(dbCMD, "LastName", SqlDbType.VarChar, LastName);
                var vResult = sqlDB.ExecuteScalar(dbCMD);
                if (vResult == null)
                    return null;

                return (decimal)Convert.ChangeType(vResult, vResult.GetType());
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion
        

        #region Method: dbo_PR_UMS_Demo_SelectAll
        public List<dbo_PR_UMS_Demo_SelectAll_Result> dbo_PR_UMS_Demo_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_UMS_Demo_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return ConvertDataTableToEntity<dbo_PR_UMS_Demo_SelectAll_Result>(dt);
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_UMS_Demo_SelectByPK
        public List<dbo_PR_UMS_Demo_SelectByPK_Result> dbo_PR_UMS_Demo_SelectByPK(int? DemoID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_UMS_Demo_SelectByPK");
                sqlDB.AddInParameter(dbCMD, "DemoID", SqlDbType.Int, DemoID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return ConvertDataTableToEntity<dbo_PR_UMS_Demo_SelectByPK_Result>(dt);
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_UMS_Demo_UpdateByPK
        public bool? dbo_PR_UMS_Demo_UpdateByPK(int? DemoID, string FirstName, string MiddleName, string LastName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_UMS_Demo_UpdateByPK");
                sqlDB.AddInParameter(dbCMD, "DemoID", SqlDbType.Int, DemoID);
                sqlDB.AddInParameter(dbCMD, "FirstName", SqlDbType.VarChar, FirstName);
                sqlDB.AddInParameter(dbCMD, "MiddleName", SqlDbType.VarChar, MiddleName);
                sqlDB.AddInParameter(dbCMD, "LastName", SqlDbType.VarChar, LastName);

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == -1 ? false : true);
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion
        

    }









    #region All Entities

    #region Entity: dbo_PR_UMS_Demo_SelectAll_Result
    public partial class dbo_PR_UMS_Demo_SelectAll_Result : DALHelper
    {
        #region Properties
        public int DemoID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_UMS_Demo_SelectByPK_Result
    public partial class dbo_PR_UMS_Demo_SelectByPK_Result : DALHelper
    {
        #region Properties
        public int DemoID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #endregion


}