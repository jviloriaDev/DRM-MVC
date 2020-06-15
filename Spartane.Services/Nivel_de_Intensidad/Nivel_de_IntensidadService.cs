using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Nivel_de_Intensidad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Nivel_de_Intensidad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Nivel_de_IntensidadService : INivel_de_IntensidadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> _Nivel_de_IntensidadRepository;
        #endregion

        #region Ctor
        public Nivel_de_IntensidadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> Nivel_de_IntensidadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Nivel_de_IntensidadRepository = Nivel_de_IntensidadRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(bool ConRelaciones)
        {
            return this._Nivel_de_IntensidadRepository.Table.ToList();
        }

        public IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAllComplete(bool ConRelaciones)
        {
            return this._Nivel_de_IntensidadRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nivel_de_IntensidadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Nivel_de_IntensidadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nivel_de_IntensidadRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Nivel_de_IntensidadPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Nivel_de_IntensidadRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Nivel_de_IntensidadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad entity, Spartane.Core.Domain.User.GlobalData Nivel_de_IntensidadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad entity, Spartane.Core.Domain.User.GlobalData Nivel_de_IntensidadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

