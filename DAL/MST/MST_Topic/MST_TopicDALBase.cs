using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.MST_Topic.Models;

namespace ProgrammingCode.DAL.MST.MST_Topic
{
    public abstract class MST_TopicDALBase : DALHelper
    {

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
        public decimal? Insert(MST_TopicModel objTopic)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_Insert");
                sqlDB.AddInParameter(dbCMD, "TopicName", SqlDbType.VarChar, objTopic.TopicName);
                sqlDB.AddInParameter(dbCMD, "TopicDescription", SqlDbType.VarChar, objTopic.TopicDescription);
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, objTopic.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.VarChar, objTopic.MetaTitle);
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.VarChar, objTopic.MetaKeywords);
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.VarChar, objTopic.MetaDescription);
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.VarChar, objTopic.MetaAuthor);
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.VarChar, objTopic.MetaOgTitle);
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.VarChar, objTopic.MetaOgImage);
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.VarChar, objTopic.MetaOgType);
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.VarChar, objTopic.MetaOgDescription);
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.VarChar, objTopic.MetaOgUrl);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.VarChar, objTopic.Description);
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
        public bool? Update(MST_TopicModel objTopic)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_MST_Topic_Update");
                sqlDB.AddInParameter(dbCMD, "TopicID", SqlDbType.Int, objTopic.TopicID);
                sqlDB.AddInParameter(dbCMD, "TopicName", SqlDbType.VarChar, objTopic.TopicName);
                sqlDB.AddInParameter(dbCMD, "TopicDescription", SqlDbType.VarChar, objTopic.TopicDescription);
               
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, objTopic.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.VarChar, objTopic.MetaTitle);
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.VarChar, objTopic.MetaKeywords);
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.VarChar, objTopic.MetaDescription);
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.VarChar, objTopic.MetaAuthor);
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.VarChar, objTopic.MetaOgTitle);
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.VarChar, objTopic.MetaOgImage);
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.VarChar, objTopic.MetaOgType);
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.VarChar, objTopic.MetaOgDescription);
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.VarChar, objTopic.MetaOgUrl);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.VarChar, objTopic.Description);
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