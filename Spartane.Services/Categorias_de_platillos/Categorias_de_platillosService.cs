using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Categorias_de_platillos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Categorias_de_platillos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Categorias_de_platillosService : ICategorias_de_platillosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos> _Categorias_de_platillosRepository;
        #endregion

        #region Ctor
        public Categorias_de_platillosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos> Categorias_de_platillosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Categorias_de_platillosRepository = Categorias_de_platillosRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos> SelAll(bool ConRelaciones)
        {
            return this._Categorias_de_platillosRepository.Table.ToList();
        }

        public IList<Core.Domain.Categorias_de_platillos.Categorias_de_platillos> SelAllComplete(bool ConRelaciones)
        {
            return this._Categorias_de_platillosRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Categorias_de_platillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Categorias_de_platillosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Categorias_de_platillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Categorias_de_platillosPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Categorias_de_platillosRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Categorias_de_platillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos entity, Spartane.Core.Domain.User.GlobalData Categorias_de_platillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Categorias_de_platillos.Categorias_de_platillos entity, Spartane.Core.Domain.User.GlobalData Categorias_de_platillosInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

