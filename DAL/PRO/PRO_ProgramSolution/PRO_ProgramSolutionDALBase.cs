using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.PRO_ProgramSolution.Models;
using System.Data;
using System.Data.Common;
using static ProgrammingCode.Areas.MST_Level.Models.MST_LevelModel;
using static ProgrammingCode.Areas.MST_ProgrammingCode.Models.MST_ProgrammingLangaugeModel;
using static ProgrammingCode.Areas.PRO_Program.Models.PRO_ProgramModel;

namespace ProgrammingCode.DAL.PRO.PRO_ProgramSolution
{
    public class PRO_ProgramSolutionDALBase:DALHelper

  
    {
       
       

        #region Method:SelectALL
        public List<SelectAll_Result> SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_SelectAll");
                DataTable dt=new DataTable();
                using (IDataReader dr=sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                return ConvertDataTableToEntity<SelectAll_Result>(dt);

            }catch(Exception ex) 
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion
        #region Method:Delete
        public bool? Delete(int ProgramSolutionID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_Delete");
                sqlDB.AddInParameter(dbMST, "ProgramSolutionID", SqlDbType.Int, ProgramSolutionID);
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
        #region Method: SelectBySolutionName
        public List<SelectForSearch_Result> SelectBySolutionName(string? F_Defination, int UserID, string? F_ProgramNumber, int ProgrammingLangaugeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_SelectForSearch");
                sqlDB.AddInParameter(dbCMD, "Defination", SqlDbType.VarChar, F_Defination);
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, UserID);
                sqlDB.AddInParameter(dbCMD, "ProgramNumber", SqlDbType.VarChar, F_ProgramNumber);
                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeID", SqlDbType.Int, ProgrammingLangaugeID);
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
        public List<SelectPk_Result> SelectPk(int? ProgramSolutionID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_SelectPk");
                sqlDB.AddInParameter(dbMST, "ProgramSolutionID", SqlDbType.Int, ProgramSolutionID);

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
        public decimal? Insert(PRO_ProgramSolutionModel objSolution)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_Insert");
                sqlDB.AddInParameter(dbCMD, "ProgramSolution", SqlDbType.VarChar, objSolution.ProgramSolution);
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, objSolution.ProgramID);

                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeID", SqlDbType.Int, objSolution.ProgrammingLangaugeID);
       
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.VarChar, objSolution.Description);
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
        #region Method: Update
        public bool? Update(PRO_ProgramSolutionModel objSolution)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_Update");
                sqlDB.AddInParameter(dbCMD, "ProgramSolutionID", SqlDbType.Int, objSolution.ProgramSolutionID);
                sqlDB.AddInParameter(dbCMD, "ProgramSolution", SqlDbType.VarChar, objSolution.ProgramSolution);
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, objSolution.ProgramID);

                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeID", SqlDbType.Int, objSolution.ProgrammingLangaugeID);

                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.VarChar, objSolution.Description);
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
    #region Entity: electForSearch_Result
    public partial class SelectForSearch_Result : DALHelper
    {
        #region Properties

        public int ProgramSolutionID { get; set; }

        public string? ProgramSolution { get; set; }
        public string? Defination { get; set; }

        public string? UserName { get; set; }
        public string? ProgrammingLangaugeName { get; set; }



        public int ProgramID { get; set; }
        public int ProgrammingLangaugeID { get; set; }

        public int UserID { get; set; }

        public string? Description { get; set; }

      

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

        public int ProgramSolutionID { get; set; }

        public string? ProgramSolution { get; set; }
        public int ProgramID { get; set; }
        public int ProgrammingLangaugeID { get; set; }

        public int UserID { get; set; }

        public string? Description { get; set; }

        public string? Defination { get; set; }

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
        public int ProgramSolutionID { get; set; }

        public string? ProgramSolution { get; set; }
        public int ProgramID { get; set; }
        public int ProgrammingLangaugeID { get; set; }

        public int UserID { get; set; }

        public string? Description { get; set; }

        public string? Defination { get; set; }
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
