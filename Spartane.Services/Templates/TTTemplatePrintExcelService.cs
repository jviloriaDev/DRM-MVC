using Spartane.Core.Data;
using Spartane.Core.Domain.Columns;
using Spartane.Core.Domain.Filters;
using Spartane.Core.Domain.Search;
using Spartane.Core.Domain.Templates;
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

namespace Spartane.Services.Templates
{
    public partial class TTTemplatePrintExcelService : ITTTemplatePrintExcelService
    {
        public readonly int iProcess = 6582;

        #region Fields
        private readonly IRepository<TTTemplatePrintExcel> _ttRepository;
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly ITTSearchAdvancedDataService _tTSearchAdvancedDataService;
        #endregion

        #region Ctor

        public TTTemplatePrintExcelService(IRepository<TTTemplatePrintExcel> ttRepository, IDataProvider dataProvider, IDbContext dbContext, ITTSearchAdvancedDataService tTSearchAdvancedDataService)
        {
            this._ttRepository = ttRepository;
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._tTSearchAdvancedDataService = tTSearchAdvancedDataService;
        }

        #endregion

        #region Methods
        public int SelCount()
        {
            return this._ttRepository.Table.Count();
        }

        public IList<TTTemplatePrintExcel> SelAll(bool ConRelaciones)
        {
            return this._ttRepository.Table.ToList();
        }

        public IList<TTTemplatePrintExcel> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ttRepository.Table.ToList();
        }

        public int CurrentPosicion(int? Key)
        {
            throw new NotImplementedException();
        }

        public TTTemplatePrintExcel GetByKey(int? Key, bool ConRelaciones)
        {
            return this._ttRepository.GetById(Key);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            try
            {
                var entity = _ttRepository.GetById(Key);
                _ttRepository.Delete(entity);
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

        public int Insert(TTTemplatePrintExcel entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _ttRepository.Insert(entity);
                rta = entity.IdTemplate;
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

        public int Update(TTTemplatePrintExcel entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = 0;
            try
            {
                _ttRepository.Update(entity);
                rta = entity.IdTemplate;
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
            var existencia = _ttRepository.GetById(Key);
            return existencia != null;
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms
        public void FillDataProcesoId(object ctr)
        {
            var columns = _dbContext.ExecuteStoredProcedureList<sp_SelTTTemplatePrintExcel_Relacion_TTProceso_Result>(
                "sp_selTTTemplatePrintExcel_Relacion_TTProceso");

            if (ctr.GetType() == typeof(ComboBox))
            {
                ((ComboBox)ctr).DataSource = columns;
                ((ComboBox)ctr).DisplayMember = "Nombre";
                ((ComboBox)ctr).ValueMember = "IdProceso";
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
                ((ListBox)ctr).ValueMember = "IdProceso";
                ((ListBox)ctr).ClearSelected();
            }
            else if (ctr.GetType() == typeof(DataGridViewComboBoxColumn))
            {
                ((DataGridViewComboBoxColumn)ctr).DataSource = columns;
                ((DataGridViewComboBoxColumn)ctr).DisplayMember = "Nombre";
                ((DataGridViewComboBoxColumn)ctr).ValueMember = "IdProceso";
            }
        }

        //TODO: Revisar este metodo. Implementa controles de Windows Forms. No existe el sp que ejecuta
        public void FillDataConfiguracionCampos(object ctr)
        {
            throw new NotImplementedException();
        }

        public void applyFilterToObject(IList<TTTemplatePrintExcel> filters, Core.Domain.Search.TTSearchAdvancedDataDetails tTSearchAdvancedDataDetails, int indexFilter)
        {
            switch (tTSearchAdvancedDataDetails.ControlScreenSearchAdvanced)
            {
                case TypeControlSearchAdvanced.Text:
                    {
                        #region Variable Filter del Bussiness Object para Textos
                        StringFilterType filter = new StringFilterType();
                        filter.Order = (FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.ConditionText != TypesTextFilter.None)
                        {
                            if (tTSearchAdvancedDataDetails.From != "" && tTSearchAdvancedDataDetails.ConditionText != TypesTextFilter.None)
                            {
                                switch (tTSearchAdvancedDataDetails.ConditionText)
                                {
                                    case TypesTextFilter.Igual:
                                        {
                                            filter.FilterType = TypesTextFilter.Igual;
                                            break;
                                        }
                                    case TypesTextFilter.Contenga:
                                        {
                                            filter.FilterType = TypesTextFilter.Contenga;
                                            break;
                                        }
                                    case TypesTextFilter.Empieze:
                                        {
                                            filter.FilterType = TypesTextFilter.Empieze;
                                            break;
                                        }
                                    case TypesTextFilter.Termine:
                                        {
                                            filter.FilterType = TypesTextFilter.Termine;
                                            break;
                                        }
                                }
                                filter.Text = tTSearchAdvancedDataDetails.From;
                            }
                        }
                        AddFilterXDT(filters, tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case TypeControlSearchAdvanced.Numeric:
                    {
                        #region Variable Filter del Bussiness Object para Numericos
                        NumericFilterType filter = new NumericFilterType();
                        filter.Order = (FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if ((tTSearchAdvancedDataDetails.ConditionText == TypesTextFilter.None) && (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != ""))
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Convert.ToInt16(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Convert.ToInt16(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(filters, tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case TypeControlSearchAdvanced.Logic:
                    {
                        #region Variable Filter del Bussiness Object para Logicos
                        LogicFilterType filter = new LogicFilterType();
                        filter.Order = (FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.Yes_Not != null)
                            filter.Active = tTSearchAdvancedDataDetails.Yes_Not;
                        AddFilterXDT(filters, tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case TypeControlSearchAdvanced.Money:
                    {
                        #region Variable Filter del Bussiness Object para Decimal
                        FilDecimalFilterType filter = new FilDecimalFilterType();
                        filter.Order = (FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != "")
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Convert.ToDecimal(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Convert.ToDecimal(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(filters, tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case TypeControlSearchAdvanced.Hour:
                    {
                        break;
                    }
                case TypeControlSearchAdvanced.Dependiente:
                    {
                        #region Variable Filter del Bussiness Object para Dependientes
                        DependentFilterType filter = new DependentFilterType();
                        filter.Order = (FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        filter.DependentList = tTSearchAdvancedDataDetails.ListaDependientes.ToArray();
                        AddFilterXDT(filters, tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case TypeControlSearchAdvanced.Decimal:
                    {
                        #region Variable Filter del Bussiness Object para Decimal
                        FilDecimalFilterType filter = new FilDecimalFilterType();
                        filter.Order = (FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.From != "" || tTSearchAdvancedDataDetails.To != "")
                        {
                            if (tTSearchAdvancedDataDetails.From != "")
                                filter.From = Convert.ToDecimal(tTSearchAdvancedDataDetails.From);
                            if (tTSearchAdvancedDataDetails.To != "")
                                filter.To = Convert.ToDecimal(tTSearchAdvancedDataDetails.To);
                        }
                        AddFilterXDT(filters, tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case TypeControlSearchAdvanced.Date:
                    {
                        #region Variable Filter del Bussiness Object para Dates
                        FillDateFilterType filter = new FillDateFilterType();
                        filter.Order = (FiltersPropertiesModeOrderFields)tTSearchAdvancedDataDetails.Order;
                        if (tTSearchAdvancedDataDetails.FromDate != null || tTSearchAdvancedDataDetails.ToDate != null)
                        {
                            if (tTSearchAdvancedDataDetails.FromDate != null)
                                filter.From = tTSearchAdvancedDataDetails.FromDate;
                            if (tTSearchAdvancedDataDetails.ToDate != null)
                                filter.To = (tTSearchAdvancedDataDetails.ToDate);
                        }
                        AddFilterXDT(filters, tTSearchAdvancedDataDetails.DTID.ToString(), filter, indexFilter);
                        #endregion
                        break;
                    }
                case TypeControlSearchAdvanced.Color:
                    {
                        break;
                    }
            }
        }

        public IList<TTSearchAdvancedData> FiltersObligatories(Core.Domain.User.GlobalData GlobalInformation)
        {
            var processId = _dataProvider.GetParameter();
            processId.ParameterName = "ProcessId";
            processId.DbType = DbType.Int32;
            processId.Value = this.iProcess;

            var userID = _dataProvider.GetParameter();
            userID.ParameterName = "UserID";
            userID.DbType = DbType.Int32;
            userID.Value = GlobalInformation.UserID;

            var vistas = _dbContext.ExecuteStoredProcedureList<spTtVistasObligatories_X_ProcessAndUser_Result>(
                "spTtVistasObligatories_X_ProcessAndUser",
                processId, userID);

            var filters = new List<TTTemplatePrintExcel>();
            List<TTSearchAdvancedData> dataReturn = new List<TTSearchAdvancedData>();
            foreach (spTtVistasObligatories_X_ProcessAndUser_Result vista in vistas)
            {
                var entity = _tTSearchAdvancedDataService.GetStructView(vista.VistaID);
                dataReturn.Add(entity);

                int i = 0;
                foreach (var item in entity.Details)
                {
                    applyFilterToObject(filters, item, i);
                    i++;
                }
            }

            return dataReturn;
        }

        //TODO: Analizar el porque de este metodo. No entiendo la asignacion de object a un int
        public void AddFilterXDT(IList<TTTemplatePrintExcel> filters, string sDTid, object filter, int indexFilter)
        {
            //if (sDTid == "14077")
            //{
            //    filters[indexFilter].IdConfiguration = (NumericFilterType)filter;
            //}
            //if (sDTid == "14078")
            //{
            //    filters[indexFilter].ProcesoId = (DependentFilterType)filter;
            //}
        }

        #endregion
    }
}
