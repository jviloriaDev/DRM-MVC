using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Nivel_de_dificultad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Nivel_de_dificultad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Nivel_de_dificultadService : INivel_de_dificultadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> _Nivel_de_dificultadRepository;
        #endregion

        #region Ctor
        public Nivel_de_dificultadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> Nivel_de_dificultadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Nivel_de_dificultadRepository = Nivel_de_dificultadRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(bool ConRelaciones)
        {
            return this._Nivel_de_dificultadRepository.Table.ToList();
        }

        public IList<Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> SelAllComplete(bool ConRelaciones)
        {
            return this._Nivel_de_dificultadRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nivel_de_dificultadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Nivel_de_dificultadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Nivel_de_dificultadRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Nivel_de_dificultadPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Nivel_de_dificultadRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Nivel_de_dificultadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad entity, Spartane.Core.Domain.User.GlobalData Nivel_de_dificultadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Nivel_de_dificultad.Nivel_de_dificultad entity, Spartane.Core.Domain.User.GlobalData Nivel_de_dificultadInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

