using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Respuesta_Logica;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Respuesta_Logica
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Respuesta_LogicaService : IRespuesta_LogicaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> _Respuesta_LogicaRepository;
        #endregion

        #region Ctor
        public Respuesta_LogicaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> Respuesta_LogicaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Respuesta_LogicaRepository = Respuesta_LogicaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> SelAll(bool ConRelaciones)
        {
            return this._Respuesta_LogicaRepository.Table.ToList();
        }

        public IList<Core.Domain.Respuesta_Logica.Respuesta_Logica> SelAllComplete(bool ConRelaciones)
        {
            return this._Respuesta_LogicaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Respuesta_LogicaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Respuesta_LogicaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Respuesta_LogicaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Respuesta_Logica.Respuesta_LogicaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Respuesta_LogicaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Respuesta_LogicaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Respuesta_LogicaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica entity, Spartane.Core.Domain.User.GlobalData Respuesta_LogicaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Respuesta_Logica.Respuesta_Logica entity, Spartane.Core.Domain.User.GlobalData Respuesta_LogicaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

