using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Convenio_Medicos_Aseguradoras
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Convenio_Medicos_AseguradorasService : IDetalle_Convenio_Medicos_AseguradorasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> _Detalle_Convenio_Medicos_AseguradorasRepository;
        #endregion

        #region Ctor
        public Detalle_Convenio_Medicos_AseguradorasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> Detalle_Convenio_Medicos_AseguradorasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Convenio_Medicos_AseguradorasRepository = Detalle_Convenio_Medicos_AseguradorasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Convenio_Medicos_AseguradorasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Convenio_Medicos_AseguradorasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Convenio_Medicos_AseguradorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity, Spartane.Core.Domain.User.GlobalData Detalle_Convenio_Medicos_AseguradorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity, Spartane.Core.Domain.User.GlobalData Detalle_Convenio_Medicos_AseguradorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

