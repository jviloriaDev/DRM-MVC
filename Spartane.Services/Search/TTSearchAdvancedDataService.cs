using Spartane.Core.Data;
using Spartane.Core.Domain.Filters;
using Spartane.Core.Domain.Search;
using Spartane.Data.EF;
using Spartane.Core.Exceptions.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Exceptions;

namespace Spartane.Services.Search
{
    public class TTSearchAdvancedDataService : ITTSearchAdvancedDataService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly ITTSearchAdvancedDataService _tTSearchAdvancedDataService;

        private readonly IRepository<TTVista> _ttViewRepository;
        private readonly IRepository<TTVista_Detalle> _ttViewDetailRepository;
        private readonly IRepository<TTVista_ListaDependientes> _ttViewDetailDepRepository;
        #endregion

        #region Ctor
        public TTSearchAdvancedDataService(IRepository<TTVista> ttViewRepository, IDataProvider dataProvider, IDbContext dbContext, ITTSearchAdvancedDataService tTSearchAdvancedDataService, IRepository<TTVista_Detalle> ttViewDetailRepository, IRepository<TTVista_ListaDependientes> ttViewDetailDepRepository)
        {
            this._ttViewRepository = ttViewRepository;
            this._ttViewDetailRepository = ttViewDetailRepository;
            this._ttViewDetailDepRepository = ttViewDetailDepRepository;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._tTSearchAdvancedDataService = tTSearchAdvancedDataService;
        }
        #endregion

        #region Methods
        public Core.Domain.Search.TTSearchAdvancedData GetStructView(int vistaId)
        {
            TTSearchAdvancedData MyView = new TTSearchAdvancedData();

            var vista = _ttViewRepository.Table.SingleOrDefault(v => v.Vistaid == vistaId);
            if (vista != null)
            {
                MyView.VistaID = vista.Vistaid;
                MyView.Name = vista.Nombre;
                MyView.Default = vista.Default ?? false;
                MyView.Empty = vista.Vacio ?? false;
                MyView.Obligatory = vista.Obligatorio;
                MyView.ProcessID = vista.ProcesoId ?? 0;
                MyView.UserID = vista.Usuario ?? 0;
                MyView.Sql = vista.SQL;

                MyView.Details = _ttViewDetailRepository.Table.Where(v => v.VistaId == vistaId)
                    .Select(v => new TTSearchAdvancedDataDetails()
                    {
                        ConditionText = (TypesTextFilter)v.Condicion,
                        ControlScreenSearchAdvanced = (TypeControlSearchAdvanced)v.TipoDeControlBusqueda,
                        DNTID = v.DNTid,
                        DTID = Convert.ToInt32(v.Dtid),
                        From = v.Orden_desde,
                        To = v.Orden_hasta,
                        Order = v.Orden ?? 0,
                        FromDate = v.Orden_Desde_Date,
                        ToDate = v.Orden_Hasta_Date,
                        Month = v.Mes,
                        Visible = v.Visible ?? false,
                        Week = v.Semana,
                        Year = v.Año,
                        Yes_Not = v.SI_NO,
                        ListaDependientes = _ttViewDetailDepRepository.Table
                                                .Where(d => d.VistaId == vistaId && d.DTId == v.Dtid)
                                                .Select(x => x.Valor).ToList()
                    }).ToList();
            }

            return MyView;
        }

        public void Delete(int vistaId, Core.Domain.User.GlobalData userInformation, Core.Domain.Data.DataLayerFieldsBitacora dataReference)
        {
            try
            {
                var entity = _ttViewRepository.GetById(vistaId);
                _ttViewRepository.Delete(entity);
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
