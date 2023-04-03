using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.PRO_ProgramSolution.Models;
using ProgrammingCode.BAL;
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
        public List<SelectForSearch_Result> SelectBySolutionName(int ProgramID, int ProgrammingLangaugeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_SelectForSearch");
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int,ProgramID);
              
               
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
        #region Method: LangaugeUrl
        public List<SelectPk_Result> SelectByProgramUrlLangaugeUrl(string? ProgramUrlForsolution,string? LanguageUrl)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_SelectByProgramUrlLangaugeUrl");
				sqlDB.AddInParameter(dbMST, "ProgramUrl", SqlDbType.NVarChar, ProgramUrlForsolution);
				sqlDB.AddInParameter(dbMST, "LanguageUrl", SqlDbType.NVarChar, LanguageUrl);

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
        #region Method: SelectSolutionCount
        public int SelectSolutionCount(string? LanguageUrl)
        {
           
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_SelectSolutionCount");
                sqlDB.AddInParameter(dbMST, "LanguageUrl", SqlDbType.NVarChar, LanguageUrl);
                int count = (int)sqlDB.ExecuteScalar(dbMST);
                return count; 
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return 0;
            }
        }
        #endregion
        #region Method: Insert
        public decimal? Insert(PRO_ProgramSolutionModel Obj_PRO_ProgramSolution)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_Insert");
                sqlDB.AddInParameter(dbCMD, "ProgramSolution", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_ProgramSolution.ProgramSolution) ? null:  Obj_PRO_ProgramSolution.ProgramSolution.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, Obj_PRO_ProgramSolution.ProgramID);

                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeID", SqlDbType.Int, Obj_PRO_ProgramSolution.ProgrammingLangaugeID);
       
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace( Obj_PRO_ProgramSolution.Description) ? null : Obj_PRO_ProgramSolution.Description.Trim());
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
        public bool? Update(PRO_ProgramSolutionModel Obj_PRO_ProgramSolution)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramSolution_Update");
                sqlDB.AddInParameter(dbCMD, "ProgramSolutionID", SqlDbType.Int, Obj_PRO_ProgramSolution.ProgramSolutionID);
                sqlDB.AddInParameter(dbCMD, "ProgramSolution", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_ProgramSolution.ProgramSolution) ? null : Obj_PRO_ProgramSolution.ProgramSolution.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, Obj_PRO_ProgramSolution.ProgramID);

                sqlDB.AddInParameter(dbCMD, "ProgrammingLangaugeID", SqlDbType.Int, Obj_PRO_ProgramSolution.ProgrammingLangaugeID);

                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_ProgramSolution.Description) ? null : Obj_PRO_ProgramSolution.Description.Trim());
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

        public int ProgramSolutionID { get; set; }

        public string? ProgramSolution { get; set; }
        public int ProgramID { get; set; }
        public int ProgrammingLangaugeID { get; set; }

        public int UserID { get; set; }

        public string? Description { get; set; }

        public string? Defination { get; set; }
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
        public int ProgramSolutionID { get; set; }

        public string? ProgramSolution { get; set; }
        public int ProgramID { get; set; }
        public int ProgrammingLangaugeID { get; set; }

        public int UserID { get; set; }

        public string? Description { get; set; }

        public string? Defination { get; set; }
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
