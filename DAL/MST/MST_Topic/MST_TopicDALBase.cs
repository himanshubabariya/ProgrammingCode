using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.MST_Topic.Models;
using static ProgrammingCode.Areas.MST_Level.Models.MST_LevelModel;
using static ProgrammingCode.Areas.MST_Topic.Models.MST_TopicModel;

namespace ProgrammingCode.DAL.MST.MST_Topic
{
    public abstract class MST_TopicDALBase : DALHelper
    {
        #region Method:SelectComboBoxTopic
        public List<MST_TopicComboboxModel> SelectComboBoxTopic()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_SelectComboBox");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                List<MST_TopicComboboxModel> list = new List<MST_TopicComboboxModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    MST_TopicComboboxModel vlst = new MST_TopicComboboxModel();
                    vlst.TopicID = Convert.ToInt32(dr["TopicID"]);
                    vlst.TopicName = dr["TopicName"].ToString();
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

        # region Method: Delete
        public bool? Delete(int? TopicID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_Delete");
                sqlDB.AddInParameter(dbMST, "TopicID", SqlDbType.Int, TopicID);
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
        public decimal? Insert(MST_TopicModel Obj_MST_Topic)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_Insert");
                sqlDB.AddInParameter(dbCMD, "TopicName", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.TopicName) ? null : Obj_MST_Topic.TopicName.Trim());
                sqlDB.AddInParameter(dbCMD, "TopicDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.TopicDescription) ? null : Obj_MST_Topic.TopicDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_MST_Topic.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaTitle) ? null : Obj_MST_Topic.MetaTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaKeywords) ? null : Obj_MST_Topic.MetaKeywords.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaDescription) ? null : Obj_MST_Topic.MetaDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaAuthor) ? null : Obj_MST_Topic.MetaAuthor.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgTitle) ? null : Obj_MST_Topic.MetaOgTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgImage) ? null : Obj_MST_Topic.MetaOgImage.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgType) ? null : Obj_MST_Topic.MetaOgType.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgDescription) ? null : Obj_MST_Topic.MetaOgDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgUrl) ? null : Obj_MST_Topic.MetaOgUrl.Trim());
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.Description) ? null : Obj_MST_Topic.Description.Trim());
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, 1);
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
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_SelectAll");

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
        #region Method: SelectByTopicName
        public List<SelectForSearch_Result> SelectByTopicName(string? F_TopicName,int UserID) { 
       
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_SelectForSearch");
                sqlDB.AddInParameter(dbCMD, "TopicName", SqlDbType.NVarChar, F_TopicName);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.NVarChar, UserID);
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
        #region Method: SelectPk
        public List<SelectPk_Result> SelectPk(int? TopicID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_SelectPk");
                sqlDB.AddInParameter(dbMST, "TopicID", SqlDbType.Int, TopicID);

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
        public bool? Update(MST_TopicModel Obj_MST_Topic)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_Update");
                sqlDB.AddInParameter(dbCMD, "TopicID", SqlDbType.Int, Obj_MST_Topic.TopicID);
                sqlDB.AddInParameter(dbCMD, "TopicName", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.TopicName) ? null : Obj_MST_Topic.TopicName.Trim());
                sqlDB.AddInParameter(dbCMD, "TopicDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.TopicDescription) ? null : Obj_MST_Topic.TopicDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_MST_Topic.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaTitle) ? null : Obj_MST_Topic.MetaTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaKeywords) ? null : Obj_MST_Topic.MetaKeywords.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaDescription) ? null : Obj_MST_Topic.MetaDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaAuthor) ? null : Obj_MST_Topic.MetaAuthor.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgTitle) ? null : Obj_MST_Topic.MetaOgTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgImage) ? null : Obj_MST_Topic.MetaOgImage.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgType) ? null : Obj_MST_Topic.MetaOgType.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgDescription) ? null : Obj_MST_Topic.MetaOgDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.MetaOgUrl) ? null : Obj_MST_Topic.MetaOgUrl.Trim());
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_MST_Topic.Description) ? null : Obj_MST_Topic.Description.Trim());
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
    #region Entity: SSelectForSearch_Result
    public partial class SelectForSearch_Result : DALHelper
    {
        #region Properties

        public int TopicID { get; set; }



        public string? TopicName { get; set; }



        public string? TopicDescription { get; set; }










        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public int TopicView { get; set; }


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

        public int TopicID { get; set; }



        public string? TopicName { get; set; }



        public string? TopicDescription { get; set; }


        



       



        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public int TopicView { get; set; }


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
        public int TopicID { get; set; }



        public string? TopicName { get; set; }



        public string? TopicDescription { get; set; }


        



       



        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public int TopicView { get; set; }


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