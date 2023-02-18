using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ProgrammingCode.Areas.SEC_User.Models;
using System.Data;
using System.Data.Common;

namespace ProgrammingCode.DAL.SEC.SEC_User
{
    public class SEC_UserDALBase : DALHelper
    {
        #region Method:SelectALL
        public List<SelectAll_Result> SelectAll()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_SEC_User_SelectAll");
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
        public bool? Delete(int UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_SEC_User_Delete");
                sqlDB.AddInParameter(dbMST, "UserID", SqlDbType.Int, UserID);
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
        public List<SelectPk_Result> SelectPk(int? UserID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbMST = sqlDB.GetStoredProcCommand("dbo.PR_SEC_User_SelectPk");
                sqlDB.AddInParameter(dbMST, "UserID", SqlDbType.Int, UserID);

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
          public decimal? Insert(SEC_UserModel objUser)

          {
              try
              {
                  SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                  DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_SEC_User_Insert");
                  sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, objUser.UserName);
                  sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, objUser.Password);
                  sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, objUser.Email);
                sqlDB.AddInParameter(dbCMD, "MobileNo", SqlDbType.VarChar, objUser.MobileNo);
                sqlDB.AddInParameter(dbCMD, "DisplayName", SqlDbType.VarChar, objUser.DisplayName);
                  sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.VarChar, objUser.Description);
                  sqlDB.AddInParameter(dbCMD, "CreatedUserID", SqlDbType.Int, 1);
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
          public bool? Update(SEC_UserModel objUser)

          {
              try
              {
                  SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                  DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_PRO_Program_Update");
                sqlDB.AddInParameter(dbCMD, "UserID", SqlDbType.Int, objUser.UserID);
                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, objUser.UserName);
                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, objUser.Password);
                sqlDB.AddInParameter(dbCMD, "Email", SqlDbType.VarChar, objUser.Email);
                sqlDB.AddInParameter(dbCMD, "MobileNo", SqlDbType.VarChar, objUser.MobileNo);
                sqlDB.AddInParameter(dbCMD, "DisplayName", SqlDbType.VarChar, objUser.DisplayName);
                sqlDB.AddInParameter(dbCMD, "Description", SqlDbType.VarChar, objUser.Description);
                sqlDB.AddInParameter(dbCMD, "CreatedUserID", SqlDbType.Int, 1);
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
          #endregion*/
    }

    #region All Entities 

    #region Entity: SelectAll_Result
    public partial class SelectAll_Result : DALHelper
    {
        #region Properties

        public int UserID { get; set; }
            
        
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string? Email { get; set; }



        public string? MobileNo { get; set; }


        public string? DisplayName { get; set; }


        public int CreatedUserID { get; set; }
        public string? CreatedUser { get; set; }

        public int IsActive { get; set; }


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

    #region Entity: SelectPK_Result
    public partial class SelectPk_Result : DALHelper
    {
        #region Properties
        public int UserID { get; set; }


        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string? Email { get; set; }



        public string? MobileNo { get; set; }


        public string? DisplayName { get; set; }


        public int CreatedUserID { get; set; }
        public string? CreatedUser { get; set; }
     

        public int IsActive { get; set; }


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

    #endregion
}
