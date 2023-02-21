﻿using System;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.MST_ProgrammingCode.Models;
using static ProgrammingCode.Areas.MST_ProgrammingCode.Models.MST_ProgrammingLangaugeModel;

namespace ProgrammingCode.DAL.MST.MST_ProgrammingLangauge
{
    public abstract class MST_ProgrammingLangaugeDALBae : DALHelper
    {
        #region Method:SelectComboBoxLangauge
        public List<PRO_ProgrammingLangaugeComboBoxModel> SelectComboBoxProgrammingLangauge()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_SelectComboBox");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                List<PRO_ProgrammingLangaugeComboBoxModel> list = new List<PRO_ProgrammingLangaugeComboBoxModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    PRO_ProgrammingLangaugeComboBoxModel vlst = new PRO_ProgrammingLangaugeComboBoxModel();
                    vlst.ProgrammingLangaugeID = Convert.ToInt32(dr["ProgrammingLangaugeID"]);
                    vlst.ProgrammingLangaugeName = dr["ProgrammingLangaugeName"].ToString();
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

        #region Method: Delete
        public bool? Delete(int? ProgrammingLangaugeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_Delete");
                sqlDB.AddInParameter(dbMST, "ProgrammingLangaugeID", SqlDbType.Int, ProgrammingLangaugeID);
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
        public decimal? Insert(MST_ProgrammingLangaugeModel objProgrammingLangauge)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_Insert");
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeName", SqlDbType.NVarChar, objProgrammingLangauge.ProgrammingLangaugeName);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeShortDescription", SqlDbType.NVarChar, objProgrammingLangauge.ProgrammingLangaugeShortDescription);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeDetailedDescription", SqlDbType.NVarChar, objProgrammingLangauge.ProgrammingLangaugeDetailedDescription);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeLogo", SqlDbType.NVarChar, objProgrammingLangauge.ProgrammingLangaugeLogo);
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, objProgrammingLangauge.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar, objProgrammingLangauge.MetaTitle);
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, objProgrammingLangauge.MetaKeywords);
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar, objProgrammingLangauge.MetaDescription);
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar, objProgrammingLangauge.MetaAuthor);
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgTitle);
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgImage);
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgType);
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgDescription);
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgUrl);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, objProgrammingLangauge.Description);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int,1);
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
        #region Method: SelectAll
        public List<SelectAll_Result> SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return ConvertDataTableToEntity<SelectAll_Result>(dt);
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

        #region Method: SelectByProgrammingLangaugeName
        public List<SelectByProgrammingLangaugeName_Result> SelectByProgrammingLangaugeName(string? L_ProgrammingLangaugeName,int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_SelectForSearch");
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeName", SqlDbType.NVarChar, L_ProgrammingLangaugeName);
                     sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.NVarChar, UserID);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }

                return ConvertDataTableToEntity<SelectByProgrammingLangaugeName_Result>(dt);
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
        public List<SelectPk_Result> SelectPk(int? ProgrammingLangaugeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_SelectPk");
                sqlDB.AddInParameter(dbMST, "ProgrammingLangaugeID", SqlDbType.Int, ProgrammingLangaugeID);

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
        public bool? Update(MST_ProgrammingLangaugeModel objProgrammingLangauge)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_Update");
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeID", SqlDbType.Int, objProgrammingLangauge.ProgrammingLangaugeID);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeName", SqlDbType.NVarChar, objProgrammingLangauge.ProgrammingLangaugeName);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeShortDescription", SqlDbType.NVarChar, objProgrammingLangauge.ProgrammingLangaugeShortDescription);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeDetailedDescription", SqlDbType.NVarChar, objProgrammingLangauge.ProgrammingLangaugeDetailedDescription);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeLogo", SqlDbType.NVarChar, objProgrammingLangauge.ProgrammingLangaugeLogo);
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, objProgrammingLangauge.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar, objProgrammingLangauge.MetaTitle);
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, objProgrammingLangauge.MetaKeywords);
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar, objProgrammingLangauge.MetaDescription);
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar, objProgrammingLangauge.MetaAuthor);
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgTitle);
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgImage);
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgType);
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgDescription);
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar, objProgrammingLangauge.MetaOgUrl);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, objProgrammingLangauge.Description);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 1);

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
    #region Entity: SelectByProgrammingLangaugeName_Result
    public partial class SelectByProgrammingLangaugeName_Result : DALHelper
    {
        #region Properties

        public int ProgrammingLangaugeID { get; set; }



        public string? ProgrammingLangaugeName { get; set; }



        public string? ProgrammingLangaugeShortDescription { get; set; }


        public string? ProgrammingLangaugeDetailedDescription { get; set; }



        public string? ProgrammingLangaugeLogo { get; set; }



        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public int ProgrammingLangaugeView { get; set; }


        public string? Description { get; set; }



        public string? MetaTitle { get; set; }



        public string? MetaKeywords { get; set; }



        public string? MetaDescription { get; set; }



        public string? MetaAuthor { get; set; }



        public string? MetaOgTitle { get; set; }



        public string? MetaOgImage { get; set; }



        public string? MetaOgDescription { get; set; }


        public string? MetaOgUrl { get; set; }



        public string? MetaOgType { get; set; }

        public string? UserName { get; set; }




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

        public int ProgrammingLangaugeID { get; set; }



        public string? ProgrammingLangaugeName { get; set; }



        public string? ProgrammingLangaugeShortDescription { get; set; }


        public string? ProgrammingLangaugeDetailedDescription { get; set; }



        public string? ProgrammingLangaugeLogo { get; set; }



        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public int ProgrammingLangaugeView { get; set; }


        public string? Description { get; set; }



        public string? MetaTitle { get; set; }



        public string? MetaKeywords { get; set; }



        public string? MetaDescription { get; set; }



        public string? MetaAuthor { get; set; }



        public string? MetaOgTitle { get; set; }



        public string? MetaOgImage { get; set; }



        public string? MetaOgDescription { get; set; }


        public string? MetaOgUrl { get; set; }



        public string? MetaOgType { get; set; }

        public string? UserName { get; set; }




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
        public int ProgrammingLangaugeID { get; set; }



        public string? ProgrammingLangaugeName { get; set; }



        public string? ProgrammingLangaugeShortDescription { get; set; }


        public string? ProgrammingLangaugeDetailedDescription { get; set; }



        public string? ProgrammingLangaugeLogo { get; set; }



        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public int ProgrammingLangaugeView { get; set; }


        public string? Description { get; set; }



        public string? MetaTitle { get; set; }



        public string? MetaKeywords { get; set; }



        public string? MetaDescription { get; set; }



        public string? MetaAuthor { get; set; }



        public string? MetaOgTitle { get; set; }



        public string? MetaOgImage { get; set; }



        public string? MetaOgDescription { get; set; }


        public string? MetaOgUrl { get; set; }

        public string? UserName { get; set; }

        public string? MetaOgType { get; set; }
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