using System;
using System.Data;
using System.Collections.Generic;
using Spartane.Core.Domain.User;
using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Data;
using Spartane.Data.EF;

namespace Spartane.Services.Security
{
    /// <summary>
    /// Permission Service implementation
    /// </summary>
    public partial class PermissionService: IPermissionService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        #endregion

        #region Ctor
        public PermissionService(IDataProvider dataProvider, IDbContext dbContext)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
        }
        #endregion

        #region methods
        public IList<ModulesData> ModulesPermited(GlobalData UserInformation)
        {
            var userID = _dataProvider.GetParameter();
            userID.ParameterName = "UserID";
            userID.DbType = DbType.Int32;
            userID.Value = UserInformation.UserID;

            var idioma = _dataProvider.GetParameter();
            idioma.ParameterName = "Idioma";
            idioma.DbType = DbType.Int32;
            idioma.Value = UserInformation.Language.GetHashCode();

            var modules = _dbContext.ExecuteStoredProcedureList<spTTSecurity_ModulesPermited_Result>(
                "spTTSecurity_ModulesPermited",
                userID,
                idioma
                );
            List<ModulesData> dataReturn = new List<ModulesData>();
            foreach (spTTSecurity_ModulesPermited_Result result in modules)
            {
                ModulesData item = new ModulesData();
                item.Module = result.Nombre;
                item.Name = result.Nombre_Tabla;
                item.Description = result.DescriptionProcess;
                item.ProcessId = result.IdProceso;
                dataReturn.Add(item);
            }
            return dataReturn;
        }

        public IList<DashBoardData> DashBoardsPermited(GlobalData UserInformation)
        {
            var userID = _dataProvider.GetParameter();
            userID.ParameterName = "UserID";
            userID.DbType = DbType.Int32;
            userID.Value = UserInformation.UserID;

            var dashBoards = _dbContext.ExecuteStoredProcedureList<spTTSecurity_DashPermited_Result>(
                "spTTSecurity_DashPermited",
                userID
                );
            List<DashBoardData> dataReturn = new List<DashBoardData>();
            foreach (spTTSecurity_DashPermited_Result result in dashBoards)
            {
                DashBoardData item = new DashBoardData();
                item.Key= result.idDashBorad;
                item.Description = result.Titulo;
                dataReturn.Add(item);
            }
            return dataReturn;
        }

        public bool isOperationPermited(int sProcess, Operations operations, GlobalData UserInformation)
        {
            var userID = _dataProvider.GetParameter();
            userID.ParameterName = "UserID";
            userID.DbType = DbType.Int32;
            userID.Value = UserInformation.UserID;
 
            var processID = _dataProvider.GetParameter();
            processID.ParameterName = "ProcessID";
            processID.DbType = DbType.Int32;
            processID.Value = sProcess;

            var operationID = _dataProvider.GetParameter();
            operationID.ParameterName = "OperationID";
            operationID.DbType = DbType.Int32;
            operationID.Value = operations;

            var processPermited = _dbContext.ExecuteStoredProcedureList<spTTSecurity_ProcessPermited_Result>(
                "spTTSecurity_ProcessPermited",
                userID,
                processID,
                operationID
                );

            return (processPermited!=null && processPermited.Count>0);
            //SqlCommand com = new SqlCommand("spTTSecurity_ProcessPermited");
            //com.Parameters.AddWithValue("@UserID", UserInformation.UserID);
            //com.Parameters.AddWithValue("@ProcessID", sProcess);
            //com.Parameters.AddWithValue("@OperationID", operations);
            //com.CommandType = CommandType.StoredProcedure;
            //if (MyConexion.Consulta(com).Tables[0].Rows.Count >= 1)
            //    return true;
            //else
            //{
            //    return false;
            //}
        }
        #endregion
    }
}
