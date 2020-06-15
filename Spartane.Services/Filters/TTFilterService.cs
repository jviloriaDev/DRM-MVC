using Spartane.Core.Data;
using Spartane.Core.Domain.Columns;
using Spartane.Core.Domain.Filters;
using Spartane.Core.Domain.Search;
using Spartane.Data.EF;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Search;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spartane.Core.Exceptions;

namespace Spartane.Services.Filters
{
    public partial class TTFilterService : ITTFilterService
    {
        #region Fields
        private readonly IRepository<TTFilter> _ttFilterRepository;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly ITTSearchAdvancedDataService _tTSearchAdvancedDataService;
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="principalPageRepository">Affiliate repository</param>
        /// <param name="eventPublisher">Event published</param>
        public TTFilterService(IRepository<TTFilter> ttFilterRepository, IDataProvider dataProvider, IDbContext dbContext, ITTSearchAdvancedDataService tTSearchAdvancedDataService)
        {
            this._ttFilterRepository = ttFilterRepository;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._tTSearchAdvancedDataService = tTSearchAdvancedDataService;
        }

        #endregion

        #region Methods
        public int SelCount()
        {
            return this._ttFilterRepository.Table.Count();
        }

        public IList<Core.Domain.Filters.TTFilter> SelAll(bool ConRelaciones)
        {
            return this._ttFilterRepository.Table.ToList();
        }

        public IList<Core.Domain.Filters.TTFilter> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ttFilterRepository.Table.ToList();
        }

        public int CurrentPosicion(int? Key)
        {
            throw new NotImplementedException();
        }

        public Core.Domain.Filters.TTFilter GetByKey(int? Key, bool ConRelaciones)
        {
            return this._ttFilterRepository.GetById(Key);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            try
            {
                var entity = _ttFilterRepository.GetById(Key);
                _ttFilterRepository.Delete(entity);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Core.Domain.Filters.TTFilter entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _ttFilterRepository.Insert(entity);
                rta = entity.IdFiltro;
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Core.Domain.Filters.TTFilter entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _ttFilterRepository.Update(entity);
                rta = entity.IdFiltro;
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public bool ValidaExistencia(int? Key)
        {
            var existencia = _ttFilterRepository.GetById(Key);
            return existencia != null;
        }

        public void FillDataProcesoID(object ctr)
        {
            var dataSource = _dbContext.ExecuteStoredProcedureList<sp_SelTTFiltro_Relacion_TTProceso_Result>(
                "sp_selTTFiltro_Relacion_TTProceso");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = dataSource;
                ((ComboBox)ctr).DisplayMember = "Nombre";
                ((ComboBox)ctr).ValueMember = "IdProceso";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(dataSource.Select(v => v.Nombre).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = dataSource;
                ((ListBox)ctr).DisplayMember = "Nombre";
                ((ListBox)ctr).ValueMember = "IdProceso";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = dataSource;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdProceso";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms. No existe el sp que ejecuta
        public void FillDataFiltro_Detalle(object ctr)
        {
            throw new NotImplementedException();
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms. No existe el sp que ejecuta
        public void FillDataFiltro_Dependientes(object ctr)
        {
            throw new NotImplementedException();
        }

        private String Leftjoin(int DTIDOrigen, int DTIDDestiny, int? DTIDOrigenRelation, out String sAlias)
        {
            sAlias = string.Empty;
            return sAlias;
        }

        private String cicleJoins(TTDetailFilter obj, int? DTLastRelation, String sJoins, out String sAlias)
        {
            sAlias = string.Empty;
            return sAlias;
        }

        private String cicleJoinsWithOutLeftJoin(TTDetailFilter obj, int? DTLastRelation, String sJoins, out String sAlias)
        {
            sAlias = string.Empty;
            return sAlias;
        }

        public string GenerateLeftJoin()
        {
            throw new NotImplementedException();
        }

        public string GenerateWhereWithLeftJoin(int? DTIDRelation)
        {
            throw new NotImplementedException();
        }

        public string GenerateWhereWithLeftJoin(int? DTIDRelation, string ParentAlias)
        {
            throw new NotImplementedException();
        }

        private Int32 ContainsCount(String SearchPhrase, String SearchText)
        {
            return 0;
        }
        
        public string GenerateWhereWithOutLeftJoin(int? DTIDRelation)
        {
            throw new NotImplementedException();
        }

        public string GenerateWhere()
        {
            throw new NotImplementedException();
        }

        private String WhereIn(int DTIDOrigen, int DTIDDestiny, int? DTIDOrigenRelation, out String sAlias)
        {
            sAlias = string.Empty;
            return sAlias;
        }
        #endregion
    }
}
