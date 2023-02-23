using System;

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
        public decimal? Insert(MST_ProgrammingLangaugeModel Obj_MST_ProgrammingLangauge)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_Insert");
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeName", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeName) ? null : Obj_MST_ProgrammingLangauge.ProgrammingLangaugeName.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeShortDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeShortDescription) ? null : Obj_MST_ProgrammingLangauge.ProgrammingLangaugeShortDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeDetailedDescription", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeDetailedDescription) ? null : Obj_MST_ProgrammingLangauge.ProgrammingLangaugeDetailedDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeLogo", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeLogo) ? null : Obj_MST_ProgrammingLangauge.ProgrammingLangaugeLogo.Trim());
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_MST_ProgrammingLangauge.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaTitle) ? null : Obj_MST_ProgrammingLangauge.MetaTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaKeywords) ? null : Obj_MST_ProgrammingLangauge.MetaKeywords.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaDescription) ? null : Obj_MST_ProgrammingLangauge.MetaDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaAuthor) ? null : Obj_MST_ProgrammingLangauge.MetaAuthor.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgTitle) ? null : Obj_MST_ProgrammingLangauge.MetaOgTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgImage) ? null : Obj_MST_ProgrammingLangauge.MetaOgImage.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgType) ? null : Obj_MST_ProgrammingLangauge.MetaOgType.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgDescription) ? null : Obj_MST_ProgrammingLangauge.MetaOgDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgUrl) ? null : Obj_MST_ProgrammingLangauge.MetaOgUrl.Trim());
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.Description) ? null : Obj_MST_ProgrammingLangauge.Description.Trim());
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
        public List<SelectByProgrammingLangaugeName_Result> SelectByProgrammingLangaugeName(int ProgrammingLangaugeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_SelectForSearch");
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeID", SqlDbType.Int, ProgrammingLangaugeID);
                
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
        public bool? Update(MST_ProgrammingLangaugeModel Obj_MST_ProgrammingLangauge)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_ProgrammingLangauge_Update");
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeID", SqlDbType.Int, Obj_MST_ProgrammingLangauge.ProgrammingLangaugeID);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeName", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeName) ? null : Obj_MST_ProgrammingLangauge.ProgrammingLangaugeName.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeShortDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeShortDescription) ? null : Obj_MST_ProgrammingLangauge.ProgrammingLangaugeShortDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeDetailedDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeDetailedDescription) ? null : Obj_MST_ProgrammingLangauge.ProgrammingLangaugeDetailedDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeLogo", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.ProgrammingLangaugeLogo) ? null : Obj_MST_ProgrammingLangauge.ProgrammingLangaugeLogo.Trim());
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_MST_ProgrammingLangauge.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaTitle) ? null : Obj_MST_ProgrammingLangauge.MetaTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaKeywords) ? null : Obj_MST_ProgrammingLangauge.MetaKeywords.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaDescription) ? null : Obj_MST_ProgrammingLangauge.MetaDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaAuthor) ? null : Obj_MST_ProgrammingLangauge.MetaAuthor.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgTitle) ? null : Obj_MST_ProgrammingLangauge.MetaOgTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgImage) ? null : Obj_MST_ProgrammingLangauge.MetaOgImage.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgType) ? null : Obj_MST_ProgrammingLangauge.MetaOgType.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgDescription) ? null : Obj_MST_ProgrammingLangauge.MetaOgDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.MetaOgUrl) ? null : Obj_MST_ProgrammingLangauge.MetaOgUrl.Trim());
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_ProgrammingLangauge.Description) ? null : Obj_MST_ProgrammingLangauge.Description.Trim());
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