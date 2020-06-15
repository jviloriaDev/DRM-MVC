using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Terapia_Hormonal;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Terapia_Hormonal
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Terapia_HormonalService : IDetalle_Terapia_HormonalService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> _Detalle_Terapia_HormonalRepository;
        #endregion

        #region Ctor
        public Detalle_Terapia_HormonalService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> Detalle_Terapia_HormonalRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Terapia_HormonalRepository = Detalle_Terapia_HormonalRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_HormonalPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Terapia_HormonalPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Terapia_HormonalRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Terapia_HormonalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal entity, Spartane.Core.Domain.User.GlobalData Detalle_Terapia_HormonalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Terapia_Hormonal.Detalle_Terapia_Hormonal entity, Spartane.Core.Domain.User.GlobalData Detalle_Terapia_HormonalInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

