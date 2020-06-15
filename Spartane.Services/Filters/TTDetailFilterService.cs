using Spartane.Core.Data;
using Spartane.Core.Domain.Columns;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Filters;
using Spartane.Core.Domain.Search;
using Spartane.Core.Domain.User;
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
    public partial class TTDetailFilterService : ITTDetailFilterService
    {
        #region Fields
        public int iProcess = 6590;

        private readonly IRepository<TTDetailFilter> _ttFilterRepository;
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
        public TTDetailFilterService(IRepository<TTDetailFilter> ttFilterRepository, IDataProvider dataProvider, IDbContext dbContext, ITTSearchAdvancedDataService tTSearchAdvancedDataService)
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

        public IList<Core.Domain.Filters.TTDetailFilter> SelAll(bool ConRelaciones)
        {
            return this._ttFilterRepository.Table.ToList();
        }

        public IList<Core.Domain.Filters.TTDetailFilter> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ttFilterRepository.Table.ToList();
        }

        public Core.Domain.Filters.TTDetailFilter GetByKey(string Key, bool ConRelaciones)
        {
            return this._ttFilterRepository.GetById(Key);
        }

        public bool Delete(string Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
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

        public string Insert(Core.Domain.Filters.TTDetailFilter entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = string.Empty;
            try
            {
                _ttFilterRepository.Insert(entity);
                rta = entity.Folio.ToString();
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

        public string Update(Core.Domain.Filters.TTDetailFilter entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = string.Empty;
            try
            {
                _ttFilterRepository.Update(entity);
                rta = entity.Folio.ToString();
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

        public bool ValidaExistencia(string Key)
        {
            var existencia = _ttFilterRepository.GetById(Key);
            return existencia != null;
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataIdTTFiltro(object ctr)
        {
            var columns = _dbContext.ExecuteStoredProcedureList<sp_selTTFiltro_Detalle_Relacion_TTFiltro_Result>(
                "sp_selTTFiltro_Detalle_Relacion_TTFiltro");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "ProcesoID";
                ((ComboBox)ctr).ValueMember = "IdFiltro";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(columns.Select(v => Convert.ToString(v.ProcesoID)).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = columns;
                ((ListBox)ctr).DisplayMember = "ProcesoID";
                ((ListBox)ctr).ValueMember = "IdFiltro";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "ProcesoID";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdFiltro";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataFolio(object ctr)
        {
            var columns = _dbContext.ExecuteStoredProcedureList<sp_selTTFiltro_Detalle_Relacion_TTDNT_Result>(
                "sp_selTTFiltro_Detalle_Relacion_TTDNT");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "Nombre_Tabla";
                ((ComboBox)ctr).ValueMember = "DNTID";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(columns.Select(v => v.Nombre_Tabla).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = columns;
                ((ListBox)ctr).DisplayMember = "Nombre_Tabla";
                ((ListBox)ctr).ValueMember = "DNTID";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre_Tabla";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "DNTID";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataDNTFiltro(object ctr)
        {
            var columns = _dbContext.ExecuteStoredProcedureList<sp_selTTFiltro_Detalle_Relacion_TTDNT_Result>(
                "sp_selTTFiltro_Detalle_Relacion_TTDNT");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "Nombre_Tabla";
                ((ComboBox)ctr).ValueMember = "DNTID";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(columns.Select(v => v.Nombre_Tabla).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = columns;
                ((ListBox)ctr).DisplayMember = "Nombre_Tabla";
                ((ListBox)ctr).ValueMember = "DNTID";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre_Tabla";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "DNTID";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataDt_Filtro(object ctr)
        {
            var columns = _dbContext.ExecuteStoredProcedureList<sp_selTTFiltro_Detalle_Relacion_TTMetadata_Result>(
                "sp_selTTFiltro_Detalle_Relacion_TTMetadata");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "Nombre";
                ((ComboBox)ctr).ValueMember = "DTID";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(columns.Select(v => v.Nombre).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = columns;
                ((ListBox)ctr).DisplayMember = "Nombre";
                ((ListBox)ctr).ValueMember = "DTID";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "DTID";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataDt_Filtro(object ctr, int Key)
        {
            var dntId = _dataProvider.GetParameter();
            dntId.ParameterName = "DNTID";
            dntId.DbType = DbType.Int32;
            dntId.Value = Key;

            var columns = _dbContext.ExecuteStoredProcedureList<sp_selTTFiltro_Detalle_Relacion_TTMetadata_Result>(
                "sp_selTTFiltro_Detalle_Relacion_TTMetadata",
                dntId);

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "Nombre";
                ((ComboBox)ctr).ValueMember = "DTID";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(columns.Select(v => v.Nombre).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = columns;
                ((ListBox)ctr).DisplayMember = "Nombre";
                ((ListBox)ctr).ValueMember = "DTID";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "DTID";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataMes(object ctr)
        {
            var columns = _dbContext.ExecuteStoredProcedureList<sp_selTTFiltro_Detalle_Relacion_TTMes_Result>(
                "sp_selTTFiltro_Detalle_Relacion_TTMes");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "Descripcion";
                ((ComboBox)ctr).ValueMember = "IdMes";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(columns.Select(v => v.Descripcion).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = columns;
                ((ListBox)ctr).DisplayMember = "Descripcion";
                ((ListBox)ctr).ValueMember = "IdMes";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdMes";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataSi_No(object ctr)
        {
            var columns = _dbContext.ExecuteStoredProcedureList<sp_selTTFiltro_Detalle_Relacion_TTSI_NO_Result>(
                "sp_selTTFiltro_Detalle_Relacion_TTSI_NO");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "Descripcion";
                ((ComboBox)ctr).ValueMember = "IdSI_NO";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(columns.Select(v => v.Descripcion).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = columns;
                ((ListBox)ctr).DisplayMember = "Descripcion";
                ((ListBox)ctr).ValueMember = "IdSI_NO";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdSI_NO";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataCondicionTexto(object ctr)
        {
            var columns = _dbContext.ExecuteStoredProcedureList<sp_selTTFiltro_Detalle_Relacion_TTOperador_Result>(
                "sp_selTTFiltro_Detalle_Relacion_TTOperador");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "Descripcion";
                ((ComboBox)ctr).ValueMember = "IdOperador";
                ((ComboBox)ctr).SelectedItem = null;
                if (((ComboBox)ctr).DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ((ComboBox)ctr).AutoCompleteMode = AutoCompleteMode.Suggest;
                    ((ComboBox)ctr).AutoCompleteSource = AutoCompleteSource.CustomSource;
                    AutoCompleteStringCollection ls = new AutoCompleteStringCollection();
                    ls.AddRange(columns.Select(v => v.Descripcion).ToArray());
                    ((ComboBox)ctr).AutoCompleteCustomSource = ls;
                }
            }
            else if (ctr.GetType() == typeof(ListBox))
            {
                ((ListBox)ctr).DataSource = columns;
                ((ListBox)ctr).DisplayMember = "Descripcion";
                ((ListBox)ctr).ValueMember = "IdOperador";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Descripcion";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdOperador";
            }
        }
        #endregion
    }
}
