﻿using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.MST_Level.Models;
using ProgrammingCode.Areas.MST_ProgrammingCode.Models;
using ProgrammingCode.BAL;
using System.Data;
using System.Data.Common;
using static ProgrammingCode.Areas.MST_Level.Models.MST_LevelModel;

namespace ProgrammingCode.DAL.MST.MST_Level
{
    public class MST_LevelDALBase:DALHelper
    {
        #region Method:SelectComboBoxLevel
        public List<MST_LevelComboboxModel> SelectComboBoxLevel()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_Level_SelectComboBox");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                List<MST_LevelComboboxModel> list = new List<MST_LevelComboboxModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    MST_LevelComboboxModel vlst = new MST_LevelComboboxModel();
                    vlst.LevelID = Convert.ToInt32(dr["LevelID"]);
                    vlst.LevelName = dr["LevelName"].ToString();
                    list.Add(vlst);
                }
                return list;

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
        #region Method: SelectAll
        public List<SelectForSearch_Result> SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Level_SelectAll");
                DataTable dt=new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return ConvertDataTableToEntity<SelectForSearch_Result>(dt);
            }
            catch(Exception ex) {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion
        #region Method: SelectForSearch
        public List<SelectForSearch_Result> SelectForSearch(string? F_LevelName)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Level_SelectForSearch");
                sqlDB.AddInParameter(dbCMD, "LevelName", SqlDbType.NVarChar, F_LevelName);
               
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return ConvertDataTableToEntity<SelectForSearch_Result>(dt);
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

        #region Method: Delete
        public bool? Delete(int? LevelID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_Level_Delete");
                sqlDB.AddInParameter(dbMST, "LevelID", SqlDbType.Int, LevelID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbMST);
                return vReturnValue == -1 ? false : true;
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

        #region Method: Insert
        public decimal? Insert(MST_LevelModel Obj_MST_Level)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Level_Insert");
                sqlDB.AddInParameter(dbCMD, "LevelName", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Level.LevelName) ? null:  Obj_MST_Level.LevelName.Trim());
                sqlDB.AddInParameter(dbCMD, "LevelDescription", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_Level.LevelDescription) ? null:  Obj_MST_Level.LevelDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_MST_Level.Sequence);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Level.Description) ? null: Obj_MST_Level.Description.Trim());
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int,CV.UserID());
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

        #region Method: SelectPk
        public List<SelectPk_Result> SelectPk(int? LevelID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_Level_SelectPk");
                sqlDB.AddInParameter(dbMST, "LevelID", SqlDbType.Int, LevelID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }

                return ConvertDataTableToEntity<SelectPk_Result>(dt);
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

        #region Method: Update
        public bool? Update(MST_LevelModel Obj_MST_Level)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Level_Update");
                sqlDB.AddInParameter(dbCMD, "LevelID", SqlDbType.Int, Obj_MST_Level.LevelID);
                sqlDB.AddInParameter(dbCMD, "LevelName", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Level.LevelName) ? null : Obj_MST_Level.LevelName.Trim());
                sqlDB.AddInParameter(dbCMD, "LevelDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Level.LevelDescription) ? null : Obj_MST_Level.LevelDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_MST_Level.Sequence);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Level.Description) ? null : Obj_MST_Level.Description.Trim());
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return vReturnValue == -1 ? false : true;
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
    #region Entity: SelectForSearch_Result
    public partial class SelectForSearch_Result : DALHelper
    {
        #region Properties

        public int LevelID { get; set; }



        public string? LevelName { get; set; }



        public string? LevelDescription { get; set; }






        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public string? UserName { get; set; }


        public string? Description { get; set; }

        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }


        #endregion

        #region Convert Entity to String
        public override string ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: SelectAll_Result
    public partial class SelectAll_Result : DALHelper
    {
        #region Properties

        public int LevelID { get; set; }



        public string? LevelName { get; set; }



        public string? LevelDescription { get; set; }


    



        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public string? UserName { get; set; }


        public string? Description { get; set; }

        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }


        #endregion

        #region Convert Entity to String
        public override string ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: SelectPK_Result
    public partial class SelectPk_Result : DALHelper
    {
        #region Properties
        public int LevelID { get; set; }



        public string? LevelName { get; set; }



        public string? LevelDescription { get; set; }






        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public string? UserName { get; set; }


        public string? Description { get; set; }
        public DateTime Created { get; set; }


        public DateTime Modified { get; set; }
        #endregion

        #region Convert Entity to String
        public override string ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #endregion
}
