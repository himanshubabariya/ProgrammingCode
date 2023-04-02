using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.PRO_Program.Models;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Common;
using System.Data.SqlClient;
using static ProgrammingCode.Areas.MST_Level.Models.MST_LevelModel;
using static ProgrammingCode.Areas.PRO_Program.Models.PRO_ProgramModel;
using Newtonsoft.Json.Linq;
using System.Web;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using ProgrammingCode.BAL;

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
        #region Method: SelectByProgramUrl
        public List<SelectByProgramUrl_Result> SelectByProgramUrl(string? ProgramUrl)
		{
			try
			{
				SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
				DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectByProgramUrl");
				sqlDB.AddInParameter(dbMST, "ProgramUrl", SqlDbType.NVarChar, ProgramUrl);

				DataTable dt = new DataTable();
				using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
				{
					dt.Load(dr);
				}

				return ConvertDataTableToEntity<SelectByProgramUrl_Result>(dt);
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
        #region Method: SelectByTopicID
        public List<SelectByProgramUrl_Result> SelectByTopicUrl(string? TopicUrl)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectByTopicUrl");
                sqlDB.AddInParameter(dbMST, "TopicUrl", SqlDbType.NVarChar, TopicUrl);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }

                return ConvertDataTableToEntity<SelectByProgramUrl_Result>(dt);
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
                sqlDB.AddInParameter(dbCMD, "ProgramNumber", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.ProgramNumber) ? null : Obj_PRO_Program.ProgramNumber.Trim());
                sqlDB.AddInParameter(dbCMD, "Defination", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.Defination) ? null : Obj_PRO_Program.Defination.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgramDesecription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.ProgramDesecription) ? null : Obj_PRO_Program.ProgramDesecription.Trim());
                sqlDB.AddInParameter(dbCMD, "Algoritham", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.Algoritham) ? null : Obj_PRO_Program.Algoritham.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgramUrl", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.ProgramUrl) ? null : Obj_PRO_Program.ProgramUrl.Trim());
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_PRO_Program.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaTitle) ? null : Obj_PRO_Program.MetaTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaKeywords) ? null : Obj_PRO_Program.MetaKeywords.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaDescription) ? null : Obj_PRO_Program.MetaDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaAuthor) ? null : Obj_PRO_Program.MetaAuthor.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgTitle) ? null : Obj_PRO_Program.MetaOgTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgImage) ? null : Obj_PRO_Program.MetaOgImage.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgType) ? null : Obj_PRO_Program.MetaOgType.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgDescription) ? null : Obj_PRO_Program.MetaOgDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgUrl) ? null : Obj_PRO_Program.MetaOgUrl.Trim());
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar,string.IsNullOrWhiteSpace(Obj_PRO_Program.Description) ? null : Obj_PRO_Program.Description.Trim());
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());
                SqlParameter newIDParam = new SqlParameter("@pid", SqlDbType.Int);
                newIDParam.Direction = ParameterDirection.Output;
                dbCMD.Parameters.Add(newIDParam);
                var vResult = sqlDB.ExecuteScalar(dbCMD);
               
				int newID = (int)dbCMD.Parameters["@pid"].Value;

                foreach (var item in Obj_PRO_Program.arrtopic)
                {
                    DbCommand dbCMD2 = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTopic_Insert");
                    sqlDB.AddInParameter(dbCMD2, "TopicID", SqlDbType.Int, item);
                    sqlDB.AddInParameter(dbCMD2, "ProgramID", SqlDbType.Int, newID);
                    sqlDB.AddInParameter(dbCMD2, "UserID", SqlDbType.Int, 1);
                    sqlDB.ExecuteNonQuery(dbCMD2);
                }
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
				DbCommand dbMSTDelete = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTopic_DeleteByProgramID");
				sqlDB.AddInParameter(dbMSTDelete, "ProgramID", SqlDbType.Int, Obj_PRO_Program.ProgramID);
				sqlDB.ExecuteNonQuery(dbMSTDelete);

                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_Update");
                sqlDB.AddInParameter(dbCMD, "ProgramID", SqlDbType.Int, Obj_PRO_Program.ProgramID);
                sqlDB.AddInParameter(dbCMD, "LevelID", SqlDbType.Int, Obj_PRO_Program.LevelID);
                sqlDB.AddInParameter(dbCMD, "ProgramNumber", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.ProgramNumber) ? null : Obj_PRO_Program.ProgramNumber.Trim());
                sqlDB.AddInParameter(dbCMD, "Defination", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.Defination) ? null : Obj_PRO_Program.Defination.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgramDesecription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.ProgramDesecription) ? null : Obj_PRO_Program.ProgramDesecription.Trim());
                sqlDB.AddInParameter(dbCMD, "Algoritham", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.Algoritham) ? null : Obj_PRO_Program.Algoritham.Trim());
                sqlDB.AddInParameter(dbCMD, "ProgramUrl", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.ProgramUrl) ? null : Obj_PRO_Program.ProgramUrl.Trim());
                sqlDB.AddInParameter(dbCMD, "Sequence", SqlDbType.Decimal, Obj_PRO_Program.Sequence);
                sqlDB.AddInParameter(dbCMD, "MetaTitle", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaTitle) ? null : Obj_PRO_Program.MetaTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaKeywords", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaKeywords) ? null : Obj_PRO_Program.MetaKeywords.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaDescription) ? null : Obj_PRO_Program.MetaDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaAuthor", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaAuthor) ? null : Obj_PRO_Program.MetaAuthor.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgTitle", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgTitle) ? null : Obj_PRO_Program.MetaOgTitle.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgImage", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgImage) ? null : Obj_PRO_Program.MetaOgImage.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgType", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgType) ? null : Obj_PRO_Program.MetaOgType.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgDescription", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgDescription) ? null : Obj_PRO_Program.MetaOgDescription.Trim());
                sqlDB.AddInParameter(dbCMD, "MetaOgUrl", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.MetaOgUrl) ? null : Obj_PRO_Program.MetaOgUrl.Trim());
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.NVarChar, string.IsNullOrWhiteSpace(Obj_PRO_Program.Description) ? null : Obj_PRO_Program.Description.Trim());
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, CV.UserID());

                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);

                foreach (var item in Obj_PRO_Program.arrtopic)
                {
                    DbCommand dbCMD2 = sqlDB.GetStoredProcCommand("dbo.PR_PRO_ProgramTopic_Insert");
                    sqlDB.AddInParameter(dbCMD2, "TopicID", SqlDbType.Int, item);
                    sqlDB.AddInParameter(dbCMD2, "ProgramID", SqlDbType.Int, Obj_PRO_Program.ProgramID);
                    sqlDB.AddInParameter(dbCMD2, "UserID", SqlDbType.Int, 1);
                    sqlDB.ExecuteNonQuery(dbCMD2);
                }
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
        #region Method:PropgramList
        public List<SelectByLanagueUrl_Result> PropgramList(string? LanguageUrl)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectByLanguageUrl");
                sqlDB.AddInParameter(dbMST, "LanguageUrl", SqlDbType.NVarChar, LanguageUrl);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                return ConvertDataTableToEntity<SelectByLanagueUrl_Result>(dt);

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
        #region Method:TopPropgramList
        public List<SelectByLanagueUrlTop_Result> TopPropgramList(string? LanguageUrl)
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectByLanguageUrlTop");
                sqlDB.AddInParameter(dbMST, "LanguageUrl", SqlDbType.NVarChar, LanguageUrl);
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                return ConvertDataTableToEntity<SelectByLanagueUrlTop_Result>(dt);

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
        #region TopPropgramNavList
        public List<SelectByProgramUrl_Result> TopPropgramNavList()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectAllByTopView");
                
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                return ConvertDataTableToEntity<SelectByProgramUrl_Result>(dt);

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
        #region PropgramNavList
        public List<SelectByProgramUrl_Result> PropgramNavList()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_SelectAll");

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbMST))
                {
                    dt.Load(dr);
                }
                return ConvertDataTableToEntity<SelectByProgramUrl_Result>(dt);

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
    #region Entity: SelectByLanagueUrlTop_Result
    public partial class SelectByLanagueUrlTop_Result : DALHelper
    {
        #region Properties

        public int ProgramID { get; set; }

        public int LevelID { get; set; }
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }

        public string? ProgramDesecription { get; set; }

		public string? LevelName { get; set; }
		public int[] arrtopic { get; set; }
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
    
   
    #region Entity: SelectByLanagueUrl_Result
    public partial class SelectByLanagueUrl_Result : DALHelper
    {
        #region Properties

        public int ProgramID { get; set; }

        public int LevelID { get; set; }
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }

        public string? ProgramDesecription { get; set; }

		public string? LevelName { get; set; }
		public int[] arrtopic { get; set; }
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

        public int ProgramID { get; set; }
            
        public int LevelID { get; set; }
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }

        public string? ProgramDesecription { get; set; }
        public string? LevelName { get; set; }

        public int[] arrtopic { get; set; }
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
        public int ProgramID { get; set; }

        public int LevelID { get; set; }
        public string? ProgramNumber { get; set; }
        public string? Defination { get; set; }

        public string? ProgramDesecription { get; set; }


        public int[] arrtopic { get; set; }
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
	#region Entity: SelectByProgramUrl_Result
	public partial class SelectByProgramUrl_Result : DALHelper
	{
		#region Properties
		public int ProgramID { get; set; }

		public int LevelID { get; set; }
		public string? ProgramNumber { get; set; }
		public string? Defination { get; set; }
        public string? LevelName { get; set; }
        public string? ProgramDesecription { get; set; }


		public int[] arrtopic { get; set; }
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
