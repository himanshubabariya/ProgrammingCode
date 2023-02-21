using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.PRO_Program.Models;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static ProgrammingCode.Areas.MST_Level.Models.MST_LevelModel;
using static ProgrammingCode.Areas.PRO_Program.Models.PRO_ProgramModel;

namespace ProgrammingCode.DAL.PRO.PRO_Program
{
    public class PRO_ProgramDALBase:DALHelper
    {
       
        #region Method:SelectComboBoxProgram
        public List<PRO_ProgramComboboxModel> SelectComboBoxProgram()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectComboBox");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                List<PRO_ProgramComboboxModel> list = new List<PRO_ProgramComboboxModel>();
                foreach (DataRow dr in dt.Rows)
                {
                    PRO_ProgramComboboxModel vlst = new PRO_ProgramComboboxModel();
                    vlst.ProgramID = Convert.ToInt32(dr["ProgramID"]);
                    vlst.Defination = dr["Defination"].ToString();
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
        #region Method:SelectALL
        public List<SelectAll_Result> SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectAll");
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
        public bool? Delete(int ProgramID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_Delete");
                sqlDB.AddInParameter(dbMST, "ProgramID", SqlDbType.Int, ProgramID);
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
        public List<SelectPk_Result> SelectPk(int? ProgramID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectPk");
                sqlDB.AddInParameter(dbMST, "ProgramID", SqlDbType.Int, ProgramID);

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
        public decimal? Insert(PRO_ProgramModel Obj_PRO_Program)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_Insert");
                sqlDB.AddInParameter(dbCMD, "LevelID", SqlDbType.Int, Obj_PRO_Program.LevelID);
                sqlDB.AddInParameter(dbCMD, "ProgramNumber", SqlDbType.NVarChar, Obj_PRO_Program.ProgramNumber);
                sqlDB.AddInParameter(dbCMD, "Defination", SqlDbType.NVarChar, Obj_PRO_Program.Defination);
                sqlDB.AddInParameter(dbCMD, "ProgramDesecription", SqlDbType.NVarChar, Obj_PRO_Program.ProgramDesecription);
                sqlDB.AddInParameter(dbCMD, "Algoritham", SqlDbType.NVarChar, Obj_PRO_Program.Algoritham);
                sqlDB.AddInParameter(dbCMD, "ProgramUrl", SqlDbType.NVarChar, Obj_PRO_Program.ProgramUrl);
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_PRO_Program.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar, Obj_PRO_Program.MetaTitle);
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, Obj_PRO_Program.MetaKeywords);
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar, Obj_PRO_Program.MetaDescription);
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar, Obj_PRO_Program.MetaAuthor);
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgTitle);
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgImage);
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgType);
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgDescription);
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgUrl);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, Obj_PRO_Program.Description);
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
        public bool? Update(PRO_ProgramModel Obj_PRO_Program)

        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_Update");
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, Obj_PRO_Program.ProgramID);
                sqlDB.AddInParameter(dbCMD, "LevelID", SqlDbType.Int, Obj_PRO_Program.LevelID);
                sqlDB.AddInParameter(dbCMD, "ProgramNumber", SqlDbType.NVarChar, Obj_PRO_Program.ProgramNumber);
                sqlDB.AddInParameter(dbCMD, "Defination", SqlDbType.NVarChar, Obj_PRO_Program.Defination);
                sqlDB.AddInParameter(dbCMD, "ProgramDesecription", SqlDbType.NVarChar, Obj_PRO_Program.ProgramDesecription);
                sqlDB.AddInParameter(dbCMD, "Algoritham", SqlDbType.NVarChar, Obj_PRO_Program.Algoritham);
                sqlDB.AddInParameter(dbCMD, "ProgramUrl", SqlDbType.NVarChar, Obj_PRO_Program.ProgramUrl);
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_PRO_Program.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar, Obj_PRO_Program.MetaTitle);
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, Obj_PRO_Program.MetaKeywords);
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar, Obj_PRO_Program.MetaDescription);
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar, Obj_PRO_Program.MetaAuthor);
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgTitle);
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgImage);
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgType);
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgDescription);
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar, Obj_PRO_Program.MetaOgUrl);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, Obj_PRO_Program.Description);
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

        public int ProgramID { get; set; }
            
        public int LevelID { get; set; }
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }

        public string? ProgramDesecription { get; set; }



        public string? Algoritham { get; set; }


        public string? ProgramUrl { get; set; }






        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public int ProgramView { get; set; }


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

    #region Entity: SelectPK_Result
    public partial class SelectPk_Result : DALHelper
    {
        #region Properties
        public int ProgramID { get; set; }

        public int LevelID { get; set; }
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }

        public string? ProgramDesecription { get; set; }



        public string? Algoritham { get; set; }


        public string? ProgramUrl { get; set; }



       


        public decimal Sequence { get; set; }



        public int UserID { get; set; }


        public int ProgramView { get; set; }


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
