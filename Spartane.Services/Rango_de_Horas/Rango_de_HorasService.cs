using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Rango_de_Horas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Rango_de_Horas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Rango_de_HorasService : IRango_de_HorasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> _Rango_de_HorasRepository;
        #endregion

        #region Ctor
        public Rango_de_HorasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> Rango_de_HorasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Rango_de_HorasRepository = Rango_de_HorasRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> SelAll(bool ConRelaciones)
        {
            return this._Rango_de_HorasRepository.Table.ToList();
        }

        public IList<Core.Domain.Rango_de_Horas.Rango_de_Horas> SelAllComplete(bool ConRelaciones)
        {
            return this._Rango_de_HorasRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rango_de_HorasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Rango_de_HorasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Rango_de_HorasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Rango_de_Horas.Rango_de_HorasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Rango_de_HorasPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Rango_de_HorasRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Rango_de_HorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas entity, Spartane.Core.Domain.User.GlobalData Rango_de_HorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Rango_de_Horas.Rango_de_Horas entity, Spartane.Core.Domain.User.GlobalData Rango_de_HorasInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

