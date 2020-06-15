using Spartane.Core.Data;
using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.User;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Binnacle
{
    public partial class BinnacleService : IBinnacleService
    {
        //private int iProcess = 6400;

        #region Fields
        private readonly IRepository<BinnacleSQL> _binnacleRepository;
        #endregion

        #region Ctor
        public BinnacleService(IRepository<BinnacleSQL> binnacleRepository)
        {
            this._binnacleRepository = binnacleRepository;
        }
        #endregion

        #region Methods
        public void InsertIntoBitacoraLog(GlobalData UserInformation, TTSecurityModeLog ModeLog)
        {
            try
            {
                if (ModeLog == TTSecurityModeLog.LogIn)
                {
                    this._binnacleRepository.Insert(new BinnacleSQL()
                    {
                        IdUsuario = Convert.ToInt16(UserInformation.UserID),
                        ComputerName = UserInformation.ComputerName,
                        ServerName = UserInformation.ServidorName,
                        DatabaseName = UserInformation.DatabaseName,
                        //SystemName = UserInformation.SystemVersion.SystemName,
                        //SystemVersion = UserInformation.SystemVersion.SystemVersion,
                        WindowsVersion = UserInformation.WindowsVersion,
                        FechaHora = DateTime.Now
                    });
                }

                if (ModeLog == TTSecurityModeLog.LogOff)
                {
                    var binnacle = this._binnacleRepository
                        .Table.SingleOrDefault(v => v.Folio == UserInformation.Folio);
                    if (binnacle != null)
                    {
                        binnacle.FechaHora = DateTime.Now;
                        this._binnacleRepository.Update(binnacle);
                    }
                }
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }
        }
        #endregion
    }
}