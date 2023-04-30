using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.PRO_ProgramTestCase.Models;
using ProgrammingCode.BAL;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Printing;


namespace ProgrammingCode.DAL.PRO.PRO_ProgramTestCase
{
    public class PRO_ProgramTestCaseDALBase : DALHelper
    {

        #region Method: SelectForSearch
        public List<SelectForSearch_Result> SelectForSearch(int ProgramID)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTestCase_SelectForSearch");
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, ProgramID);
               
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
        #region Method: PageSelectForSearch
        public List<SelectForSearch_Result> PageSelectForSearch(int ProgramID, int PageNo, int PageSize)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTestCase_PageSelectForSearch");
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, ProgramID);
                sqlDB.AddInParameter(dbCMD, "PageNo", SqlDbType.Int, PageNo);
                sqlDB.AddInParameter(dbCMD, "PageSize", SqlDbType.Int, PageSize);
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
        #region Method:SelectALL
        public List<SelectAll_Result> SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTestCase_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
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
        #region Method:Delete
        public bool? Delete(int ProgramTestCaseID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTestCase_Delete");
                sqlDB.AddInParameter(dbMST, "ProgramTestCaseID", SqlDbType.Int, ProgramTestCaseID);
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
        #region Method: SelectPk
        public List<SelectPk_Result> SelectPk(int? ProgramTestCaseID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTestCase_SelectPk");
                sqlDB.AddInParameter(dbMST, "ProgramTestCaseID", SqlDbType.Int, ProgramTestCaseID);

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
        #region Method: SelectbyProgramID
        public List<SelectPk_Result> SelectTestCaseByProgramUrl(string? ProgramUrl)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTestCase_SelectbyProgramUrl");
                sqlDB.AddInParameter(dbMST, "ProgramUrl", SqlDbType.NVarChar, ProgramUrl);

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
        #region Method: Insert
        public decimal? Insert(PRO_ProgramTestCaseModel objProgramTestCaseModel)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTestCase_Insert");
              
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, objProgramTestCaseModel.ProgramID);
                sqlDB.AddInParameter(dbCMD, "TastCaseDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(objProgramTestCaseModel.TastCaseDescription) ? null: objProgramTestCaseModel.TastCaseDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "IsPositive", SqlDbType.Bit, objProgramTestCaseModel.IsPositive);
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, objProgramTestCaseModel.Sequence);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(objProgramTestCaseModel.Description) ? null: objProgramTestCaseModel.Description.Trim());
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

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
        #region Method: Update
        public bool? Update(PRO_ProgramTestCaseModel objProgramTestCaseModel)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTestCase_Update");
                sqlDB.AddInParameter(dbCMD, "ProgramTestCaseID", SqlDbType.Int, objProgramTestCaseModel.ProgramTestCaseID);
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, objProgramTestCaseModel.ProgramID);
                sqlDB.AddInParameter(dbCMD, "TastCaseDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(objProgramTestCaseModel.TastCaseDescription) ? null : objProgramTestCaseModel.TastCaseDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "IsPositive", SqlDbType.Bit, objProgramTestCaseModel.IsPositive);
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, objProgramTestCaseModel.Sequence);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(objProgramTestCaseModel.Description) ? null : objProgramTestCaseModel.Description.Trim());
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
        public int ProgramTestCaseID { get; set; }

        public int ProgramID { get; set; }
        public string? TastCaseDescription { get; set; }
        public bool? IsPositive { get; set; }
        public decimal Sequence { get; set; }
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }
        public string? Description { get; set; }
        public int? UserID { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        #endregion

        #region Convert Entity to String
        public override string ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion



    #region Entity: SelectaAll_Result
    public partial class SelectAll_Result : DALHelper
    {
        #region Properties
        public int ProgramTestCaseID { get; set; }

        public int ProgramID { get; set; }
        public string? TastCaseDescription { get; set; }
        public bool? IsPositive { get; set; }
        public decimal Sequence { get; set; }

        public string? Description { get; set; }
        public int? UserID { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
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
        public int ProgramTestCaseID { get; set; }

        public int ProgramID { get; set; }
        public string? TastCaseDescription { get; set; }
        public bool? IsPositive { get; set; }
        public decimal Sequence { get; set; }
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }
        public string? Description { get; set; }
        public int? UserID { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
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
