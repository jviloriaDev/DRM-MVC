﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Interpretacion_Frecuencia_cardiaca_en_EsfuerzoService : IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> _Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository;
        #endregion

        #region Ctor
        public Interpretacion_Frecuencia_cardiaca_en_EsfuerzoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository = Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> SelAll(bool ConRelaciones)
        {
            return this._Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository.Table.ToList();
        }

        public IList<Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> SelAllComplete(bool ConRelaciones)
        {
            return this._Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_EsfuerzoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Interpretacion_Frecuencia_cardiaca_en_EsfuerzoPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Interpretacion_Frecuencia_cardiaca_en_EsfuerzoRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Interpretacion_Frecuencia_cardiaca_en_EsfuerzoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo entity, Spartane.Core.Domain.User.GlobalData Interpretacion_Frecuencia_cardiaca_en_EsfuerzoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo entity, Spartane.Core.Domain.User.GlobalData Interpretacion_Frecuencia_cardiaca_en_EsfuerzoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

