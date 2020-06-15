

//Begin Declarations for Foreigns fields for Detalle_Resultados_Consultas MultiRow
var Detalle_Resultados_ConsultascountRowsChecked = 0;

function GetDetalle_Resultados_Consultas_PacientesName(Id) {
    for (var i = 0; i < Detalle_Resultados_Consultas_PacientesItems.length; i++) {
        if (Detalle_Resultados_Consultas_PacientesItems[i].Folio == Id) {
            return Detalle_Resultados_Consultas_PacientesItems[i].Nombre_Completo;
        }
    }
    return "";
}

function GetDetalle_Resultados_Consultas_PacientesDropDown() {
    var Detalle_Resultados_Consultas_PacientesDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Resultados_Consultas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Resultados_Consultas_PacientesDropdown);
    if(Detalle_Resultados_Consultas_PacientesItems != null)
    {
       for (var i = 0; i < Detalle_Resultados_Consultas_PacientesItems.length; i++) {
           $('<option />', { value: Detalle_Resultados_Consultas_PacientesItems[i].Folio, text:    Detalle_Resultados_Consultas_PacientesItems[i].Nombre_Completo }).appendTo(Detalle_Resultados_Consultas_PacientesDropdown);
       }
    }
    return Detalle_Resultados_Consultas_PacientesDropdown;
}

function GetDetalle_Resultados_Consultas_Indicadores_ConsultasName(Id) {
    for (var i = 0; i < Detalle_Resultados_Consultas_Indicadores_ConsultasItems.length; i++) {
        if (Detalle_Resultados_Consultas_Indicadores_ConsultasItems[i].Clave == Id) {
            return Detalle_Resultados_Consultas_Indicadores_ConsultasItems[i].Nombre;
        }
    }
    return "";
}

function GetDetalle_Resultados_Consultas_Indicadores_ConsultasDropDown() {
    var Detalle_Resultados_Consultas_Indicadores_ConsultasDropdown = $('<select class="form-control" />');      var labelSelect = $("#Detalle_Resultados_Consultas_cmbLabelSelect").val();

    $('<option />', { value: '', text: labelSelect }).appendTo(Detalle_Resultados_Consultas_Indicadores_ConsultasDropdown);
    if(Detalle_Resultados_Consultas_Indicadores_ConsultasItems != null)
    {
       for (var i = 0; i < Detalle_Resultados_Consultas_Indicadores_ConsultasItems.length; i++) {
           $('<option />', { value: Detalle_Resultados_Consultas_Indicadores_ConsultasItems[i].Clave, text:    Detalle_Resultados_Consultas_Indicadores_ConsultasItems[i].Nombre }).appendTo(Detalle_Resultados_Consultas_Indicadores_ConsultasDropdown);
       }
    }
    return Detalle_Resultados_Consultas_Indicadores_ConsultasDropdown;
}






function GetInsertDetalle_Resultados_ConsultasRowControls(index) {
    var columnData = [];
    var inputData = "<input type='text' class='fullWidth form-control'/>";

    columnData[0] = $(GetDetalle_Resultados_Consultas_PacientesDropDown()).addClass('Detalle_Resultados_Consultas_Folio_Pacientes Folio_Pacientes').attr('id', 'Detalle_Resultados_Consultas_Folio_Pacientes_' + index).attr('data-field', 'Folio_Pacientes').after($.parseHTML(addNew('Detalle_Resultados_Consultas', 'Pacientes', 'Folio_Pacientes', 258453)));
    columnData[1] = $($.parseHTML(GetGridDatePicker())).addClass('Detalle_Resultados_Consultas_Fecha_de_Consulta Fecha_de_Consulta').attr('id', 'Detalle_Resultados_Consultas_Fecha_de_Consulta_' + index).attr('data-field', 'Fecha_de_Consulta');
    columnData[2] = $(GetDetalle_Resultados_Consultas_Indicadores_ConsultasDropDown()).addClass('Detalle_Resultados_Consultas_Indicador Indicador').attr('id', 'Detalle_Resultados_Consultas_Indicador_' + index).attr('data-field', 'Indicador').after($.parseHTML(addNew('Detalle_Resultados_Consultas', 'Indicadores_Consultas', 'Indicador', 258448)));
    columnData[3] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Resultados_Consultas_Resultado Resultado').attr('id', 'Detalle_Resultados_Consultas_Resultado_' + index).attr('data-field', 'Resultado');
    columnData[4] = $($.parseHTML(inputData)).addClass('Detalle_Resultados_Consultas_Interpretacion Interpretacion').attr('id', 'Detalle_Resultados_Consultas_Interpretacion_' + index).attr('data-field', 'Interpretacion');
    columnData[5] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Resultados_Consultas_IMC IMC').attr('id', 'Detalle_Resultados_Consultas_IMC_' + index).attr('data-field', 'IMC');
    columnData[6] = $($.parseHTML("<input type='text' class='fullWidth form-control inputNumber'/>")).addClass('Detalle_Resultados_Consultas_IMC_Pediatria IMC_Pediatria').attr('id', 'Detalle_Resultados_Consultas_IMC_Pediatria_' + index).attr('data-field', 'IMC_Pediatria');


    initiateUIControls();
    return columnData;
}

function Detalle_Resultados_ConsultasInsertRow(rowIndex) {
if (EjecutarValidacionesAntesDeGuardarMRDetalle_Resultados_Consultas("Detalle_Resultados_Consultas_", "_" + rowIndex)) {
    var iPage = Detalle_Resultados_ConsultasTable.fnPagingInfo().iPage;
    var nameOfGrid = 'Detalle_Resultados_Consultas';
    var prevData = Detalle_Resultados_ConsultasTable.fnGetData(rowIndex);
    var data = Detalle_Resultados_ConsultasTable.fnGetNodes(rowIndex);
    var counter = 1;
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Folio_Pacientes:  data.childNodes[counter++].childNodes[0].value
        ,Fecha_de_Consulta:  data.childNodes[counter++].childNodes[0].value
        ,Indicador:  data.childNodes[counter++].childNodes[0].value
        ,Resultado: data.childNodes[counter++].childNodes[0].value
        ,Interpretacion:  data.childNodes[counter++].childNodes[0].value
        ,IMC: data.childNodes[counter++].childNodes[0].value
        ,IMC_Pediatria: data.childNodes[counter++].childNodes[0].value

    }
    Detalle_Resultados_ConsultasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Resultados_ConsultasrowCreationGrid(data, newData, rowIndex);
    Detalle_Resultados_ConsultasTable.fnPageChange(iPage);
    Detalle_Resultados_ConsultascountRowsChecked--;	
    EjecutarValidacionesDespuesDeGuardarMRDetalle_Resultados_Consultas("Detalle_Resultados_Consultas_", "_" + rowIndex);
  }
}

function Detalle_Resultados_ConsultasCancelRow(rowIndex) {
    var prevData = Detalle_Resultados_ConsultasTable.fnGetData(rowIndex);
    var data = Detalle_Resultados_ConsultasTable.fnGetNodes(rowIndex);

    if (prevData.IsInsertRow) {
        Detalle_Resultados_ConsultasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
            console.log('Row deleted');
        }, true);
    } else {
        Detalle_Resultados_ConsultasrowCreationGrid(data, prevData, rowIndex);
    }
	showDetalle_Resultados_ConsultasGrid(Detalle_Resultados_ConsultasTable.fnGetData());
    Detalle_Resultados_ConsultascountRowsChecked--;
	initiateUIControls();
}

function GetDetalle_Resultados_ConsultasFromDataTable() {
    var Detalle_Resultados_ConsultasData = [];
    var gridData = Detalle_Resultados_ConsultasTable.fnGetData();
    //debugger;
    for (var i = 0; i < gridData.length; i++) {
        if (gridData[i].IsInsertRow == null || !gridData[i].IsInsertRow)
            Detalle_Resultados_ConsultasData.push({
                Folio: gridData[i].Folio

                ,Folio_Pacientes: gridData[i].Folio_Pacientes
                ,Fecha_de_Consulta: gridData[i].Fecha_de_Consulta
                ,Indicador: gridData[i].Indicador
                ,Resultado: gridData[i].Resultado
                ,Interpretacion: gridData[i].Interpretacion
                ,IMC: gridData[i].IMC
                ,IMC_Pediatria: gridData[i].IMC_Pediatria

                ,Removed: false
            });
    }

    for (i = 0; i < removedDetalle_Resultados_ConsultasData.length; i++) {
        if (removedDetalle_Resultados_ConsultasData[i] != null && removedDetalle_Resultados_ConsultasData[i].Folio > 0)
            Detalle_Resultados_ConsultasData.push({
                Folio: removedDetalle_Resultados_ConsultasData[i].Folio

                ,Folio_Pacientes: removedDetalle_Resultados_ConsultasData[i].Folio_Pacientes
                ,Fecha_de_Consulta: removedDetalle_Resultados_ConsultasData[i].Fecha_de_Consulta
                ,Indicador: removedDetalle_Resultados_ConsultasData[i].Indicador
                ,Resultado: removedDetalle_Resultados_ConsultasData[i].Resultado
                ,Interpretacion: removedDetalle_Resultados_ConsultasData[i].Interpretacion
                ,IMC: removedDetalle_Resultados_ConsultasData[i].IMC
                ,IMC_Pediatria: removedDetalle_Resultados_ConsultasData[i].IMC_Pediatria

                , Removed: true
            });
    }	

    return Detalle_Resultados_ConsultasData;
}

function Detalle_Resultados_ConsultasEditRow(rowIndex, currentRow, executeRules) {
    var rowIndexTable = (currentRow) ? Detalle_Resultados_ConsultasTable.fnGetPosition($(currentRow).parent().parent()[0]) : rowIndex;
    Detalle_Resultados_ConsultascountRowsChecked++;
    var Detalle_Resultados_ConsultasRowElement = "Detalle_Resultados_Consultas_" + rowIndex.toString();
    var prevData = Detalle_Resultados_ConsultasTable.fnGetData(rowIndexTable );
    var row = Detalle_Resultados_ConsultasTable.fnGetNodes(rowIndexTable);
    row.innerHTML = "";
    var nameOfTable = "Detalle_Resultados_Consultas_";
    var rowIndexFormed = "_" + rowIndex;
    var controls = Detalle_Resultados_ConsultasGetUpdateRowControls(prevData, "Detalle_Resultados_Consultas_", "_" + rowIndex);

    var abc = "if(dynamicFieldValidation('" + Detalle_Resultados_ConsultasRowElement + "')){ Detalle_Resultados_ConsultasInsertRow(" + rowIndex + "); }";
    var updateRowClick = '<a  onclick="' + abc + '">';

    var actionColInsert = $('<td>');
    $('<i class="fa fa-check">').appendTo($(updateRowClick).appendTo(actionColInsert));
    $('<i class="fa fa-times">').appendTo($("<a data-toggle='tooltip' title='Cancelar Registro' onclick='Detalle_Resultados_ConsultasCancelRow(" + rowIndex + ")'>").appendTo(actionColInsert));
    actionColInsert.appendTo(row);

    for (i = 0; i < controls.length; i++) {
        var idHeader = $(controls[i]).data('field') + 'Header';
        if ($(controls[i]).length > 1) {
            idHeader = $($(controls[i])[1]).data('field') + 'Header';
        }
		var classe = ($('#Detalle_Resultados_ConsultasGrid .' + idHeader).hasClass('dt-right') ? "dt-right" : "") + ($('#Detalle_Resultados_ConsultasGrid .' + idHeader).css('display') == 'none' ? ' hide' : '' );
		  if ($(controls[i]).next().length > 0) {
		        var div = $(controls[i]).next();
		        $('<td class="' + classe + '">').append($(controls[i])).append(div).appendTo(row);
		    }
		    else
                $(controls[i]).appendTo($('<td class="' + classe +  '" id="td'+nameOfTable+idHeader.replace('Header', '')+rowIndexFormed+'">').appendTo(row));                   
    }
    
    setDetalle_Resultados_ConsultasValidation();
    initiateUIControls();
    $('.Detalle_Resultados_Consultas' + rowIndexFormed + ' .inputMoney').inputmask("currency", { prefix: "", rightAlign: false });
    $('.gridDatePicker').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
    if(executeRules == null || (executeRules != null && executeRules == true))
    {
         EjecutarValidacionesEditRowMRDetalle_Resultados_Consultas(nameOfTable, rowIndexFormed);
    }
}

function Detalle_Resultados_ConsultasfnOpenAddRowPopUp() {
    var currentRowIndex = Detalle_Resultados_ConsultasTable.fnGetData().length;
    Detalle_Resultados_ConsultasfnClickAddRow();
    GetAddDetalle_Resultados_ConsultasPopup(currentRowIndex, 0);
}

function Detalle_Resultados_ConsultasEditRowPopup(rowIndex, currentRow) {
    var rowIndexTable = Detalle_Resultados_ConsultasTable.fnGetPosition($(currentRow).parent().parent()[0]);
    var Detalle_Resultados_ConsultasRowElement = "Detalle_Resultados_Consultas_" + rowIndex.toString();
    var prevData = Detalle_Resultados_ConsultasTable.fnGetData(rowIndexTable);
    GetAddDetalle_Resultados_ConsultasPopup(rowIndex, 1, prevData.Folio);

    $('#Detalle_Resultados_ConsultasFolio_Pacientes').val(prevData.Folio_Pacientes);
    $('#Detalle_Resultados_ConsultasFecha_de_Consulta').val(prevData.Fecha_de_Consulta);
    $('#Detalle_Resultados_ConsultasIndicador').val(prevData.Indicador);
    $('#Detalle_Resultados_ConsultasResultado').val(prevData.Resultado);
    $('#Detalle_Resultados_ConsultasInterpretacion').val(prevData.Interpretacion);
    $('#Detalle_Resultados_ConsultasIMC').val(prevData.IMC);
    $('#Detalle_Resultados_ConsultasIMC_Pediatria').val(prevData.IMC_Pediatria);

    initiateUIControls();









}

function Detalle_Resultados_ConsultasAddInsertRow() {
    if (Detalle_Resultados_ConsultasinsertRowCurrentIndex < 1)
    {
        Detalle_Resultados_ConsultasinsertRowCurrentIndex = 1;
    }
    return {
        Folio: null,
        IsInsertRow: true

        ,Folio_Pacientes: ""
        ,Fecha_de_Consulta: ""
        ,Indicador: ""
        ,Resultado: ""
        ,Interpretacion: ""
        ,IMC: ""
        ,IMC_Pediatria: ""

    }
}

function Detalle_Resultados_ConsultasfnClickAddRow() {
    Detalle_Resultados_ConsultascountRowsChecked++;
    Detalle_Resultados_ConsultasTable.fnAddData(Detalle_Resultados_ConsultasAddInsertRow(), true);
    Detalle_Resultados_ConsultasTable.fnPageChange('last');
    initiateUIControls();
	 //var tag = $('#Detalle_Resultados_ConsultasGrid tbody tr td .form-control').first().get(0).tagName.toLowerCase();
    //$('#Detalle_Resultados_ConsultasGrid tbody tr:nth-of-type(' + (Detalle_Resultados_ConsultasinsertRowCurrentIndex + 1) + ') ' + tag ).focus();
    EjecutarValidacionesNewRowMRDetalle_Resultados_Consultas("Detalle_Resultados_Consultas_", "_" + Detalle_Resultados_ConsultasinsertRowCurrentIndex);
}

function Detalle_Resultados_ConsultasClearGridData() {
    Detalle_Resultados_ConsultasData = [];
    Detalle_Resultados_ConsultasdeletedItem = [];
    Detalle_Resultados_ConsultasDataMain = [];
    Detalle_Resultados_ConsultasDataMainPages = [];
    Detalle_Resultados_ConsultasnewItemCount = 0;
    Detalle_Resultados_ConsultasmaxItemIndex = 0;
    $("#Detalle_Resultados_ConsultasGrid").DataTable().clear();
    $("#Detalle_Resultados_ConsultasGrid").DataTable().destroy();
}

//Used to Get Consultas Information
function GetDetalle_Resultados_Consultas() {
    var form_data = new FormData();
    for (var i = 0; i < Detalle_Resultados_ConsultasData.length; i++) {
        form_data.append('[' + i + '].Folio', Detalle_Resultados_ConsultasData[i].Folio);

        form_data.append('[' + i + '].Folio_Pacientes', Detalle_Resultados_ConsultasData[i].Folio_Pacientes);
        form_data.append('[' + i + '].Fecha_de_Consulta', Detalle_Resultados_ConsultasData[i].Fecha_de_Consulta);
        form_data.append('[' + i + '].Indicador', Detalle_Resultados_ConsultasData[i].Indicador);
        form_data.append('[' + i + '].Resultado', Detalle_Resultados_ConsultasData[i].Resultado);
        form_data.append('[' + i + '].Interpretacion', Detalle_Resultados_ConsultasData[i].Interpretacion);
        form_data.append('[' + i + '].IMC', Detalle_Resultados_ConsultasData[i].IMC);
        form_data.append('[' + i + '].IMC_Pediatria', Detalle_Resultados_ConsultasData[i].IMC_Pediatria);

        form_data.append('[' + i + '].Removed', Detalle_Resultados_ConsultasData[i].Removed);
    }
    return form_data;
}
function Detalle_Resultados_ConsultasInsertRowFromPopup(rowIndex) {
    //if (EjecutarValidacionesAntesDeGuardarMRDetalle_Resultados_Consultas("Detalle_Resultados_ConsultasTable", rowIndex)) {
    var prevData = Detalle_Resultados_ConsultasTable.fnGetData(rowIndex);
    var data = Detalle_Resultados_ConsultasTable.fnGetNodes(rowIndex);
    var newData = {
        Folio: prevData.Folio,
        IsInsertRow: false

        ,Folio_Pacientes: $('#Detalle_Resultados_ConsultasFolio_Pacientes').val()
        ,Fecha_de_Consulta: $('#Detalle_Resultados_ConsultasFecha_de_Consulta').val()
        ,Indicador: $('#Detalle_Resultados_ConsultasIndicador').val()
        ,Resultado: $('#Detalle_Resultados_ConsultasResultado').val()

        ,Interpretacion: $('#Detalle_Resultados_ConsultasInterpretacion').val()
        ,IMC: $('#Detalle_Resultados_ConsultasIMC').val()

        ,IMC_Pediatria: $('#Detalle_Resultados_ConsultasIMC_Pediatria').val()


    }

    Detalle_Resultados_ConsultasTable.fnUpdate(newData, rowIndex, null, true);
    Detalle_Resultados_ConsultasrowCreationGrid(data, newData, rowIndex);
    $('#AddDetalle_Resultados_Consultas-form').modal({ show: false });
    $('#AddDetalle_Resultados_Consultas-form').modal('hide');
    Detalle_Resultados_ConsultasEditRow(rowIndex);
    Detalle_Resultados_ConsultasInsertRow(rowIndex);
    //}
}
function Detalle_Resultados_ConsultasRemoveAddRow(rowIndex) {
    Detalle_Resultados_ConsultasTable.fnDeleteRow(rowIndex, function (dtSettings, row) {
    }, true);
}

//End Declarations for Foreigns fields for Detalle_Resultados_Consultas MultiRow


$(function () {
    function Detalle_Resultados_ConsultasinitializeMainArray(totalCount) {
        if (Detalle_Resultados_ConsultasDataMain.length != totalCount && !Detalle_Resultados_ConsultasDataMainInitialized) {
            Detalle_Resultados_ConsultasDataMainInitialized = true;
            for (var i = 0; i < totalCount; i++) {
                Detalle_Resultados_ConsultasDataMain[i] = null;
            }
        }
    }
    function Detalle_Resultados_ConsultasremoveFromMainArray() {
        for (var j = 0; j < Detalle_Resultados_ConsultasdeletedItem.length; j++) {
            for (var i = 0; i < Detalle_Resultados_ConsultasDataMain.length; i++) {
                if (Detalle_Resultados_ConsultasDataMain[i] != null && Detalle_Resultados_ConsultasDataMain[i].Id == Detalle_Resultados_ConsultasdeletedItem[j]) {
                    hDetalle_Resultados_ConsultasDataMain.splice(i, 1);
                    break;
                }
            }
        }
    }
    function Detalle_Resultados_ConsultascopyMainHistoryArray() {
        var data = [];
        for (var i = 0; i < Detalle_Resultados_ConsultasDataMain.length; i++) {
            data[i] = Detalle_Resultados_ConsultasDataMain[i];

        }
        return data;
    }
    function Detalle_Resultados_ConsultasgetNewResult() {
        var newData = copyMainDetalle_Resultados_ConsultasArray();

        for (var i = 0; i < Detalle_Resultados_ConsultasData.length; i++) {
            if (Detalle_Resultados_ConsultasData[i].Removed == null || Detalle_Resultados_ConsultasData[i].Removed == false) {
                newData.splice(0, 0, Detalle_Resultados_ConsultasData[i]);
            }
        }
        return newData;
    }
    function Detalle_Resultados_ConsultaspushToMainArray(data, pageIndex, pageSize) {
        for (var i = 0; i < data.length; i++) {
            if (Detalle_Resultados_ConsultasDataMain[(pageIndex * pageSize) - pageSize + i] == null)
                Detalle_Resultados_ConsultasDataMain[(pageIndex * pageSize) - pageSize + i] = data[i];
        }
    }

});

var AutoCompletePacienteData = [];
function GetAutoCompleteConsultas_Paciente_PacientesData(data) {
	AutoCompletePacienteData = [];
    for (var i = 0; i < data.length; i++) {
        AutoCompletePacienteData.push({
            id: data[i].Folio,
            text: data[i].Nombre_Completo
        });
    }
    return AutoCompletePacienteData;
}
//Grid GetAutocomplete



function getDropdown(elementKey) {
    var labelSelect = $("#Consultas_cmbLabelSelect").val();
    var dropDown = '<select id="' + elementKey + '" class="form-control"><option value="">' + labelSelect + '</option></select>';
    return dropDown;
}

function GetGridDatePicker() {
    return "<input type='text' class='fullWidth gridDatePicker xyz form-control' >";
}
function GetGridTimePicker() {
    return "<input type='text' class='fullWidth gridTimePicker form-control'  data-autoclose='true'>";
}
function GetGridTextArea() {
    return "<textarea rows='2'></textarea>";
}
function GetGridCheckBox() {
    return " <input type='checkbox' class='fullWidth'> ";
}
function GetFileUploader() {
    return "<input type='file' class='fullWidth'>";
}

function GetGridAutoComplete(data,field, id) {
    
    var dataMain = data == null ? "Select" : data;
    id ==  (id==null   || id==undefined)? "":id;
    
     return "<select class='AutoComplete fullWidth select2-dropDown " + field + " form-control' data-val='true'  ><option value='" + id +"'>" + dataMain + "</option></select>";
}

function ClearControls() {
    $("#ReferenceFolio").val("0");
    $('#CreateConsultas')[0].reset();
    ClearFormControls();
    $("#FolioId").val("0");
    $('#Paciente').empty();
    $("#Paciente").append('<option value=""></option>');
    $('#Paciente').val('0').trigger('change');
                Detalle_Resultados_ConsultasClearGridData();

}
function ClearAttachmentsDiv() {
    if ($("#divAttachment") != null) {
        $("#divAttachment").empty();
    }
}
function ClearFormControls() {
    $('#CreateConsultas').trigger('reset');
    $('#CreateConsultas').find(':input').each(function () {
        switch (this.type) {
            case 'password':
            case 'number':
            case 'select-multiple':
            case 'select-one':
            case 'select':
            case 'text':
            case 'textarea':
                $(this).val('');
				for (instance in CKEDITOR.instances) {
                    CKEDITOR.instances[instance].updateElement();
                    CKEDITOR.instances[instance].setData('');
                }
                break;
            case 'checkbox':
            case 'radio':
                this.checked = false;
        }
    });
}
function CheckValidation() {
    var $myForm = $('#CreateConsultas');
    if (!$myForm[0].checkValidity()) {
        $myForm.submit();
        return false;
    }
    if (Detalle_Resultados_ConsultascountRowsChecked > 0)
    {
        ShowMessagePendingRowDetalle_Resultados_Consultas();
        return false;
    }
	
    return true;
}


function ResetClaveLabel() {
    $("#lblFolio").text("0");
}
$(document).ready(function () {
    $("form#CreateConsultas").submit(function (e) {
        e.preventDefault();
        return false;
    });
	$("form#CreateConsultas").on('click', '#ConsultasCancelar', function () {
	  if (!isPartial) {
        ConsultasBackToGrid();
	  } else {
            window.close();
      }
    });
	$("form#CreateConsultas").on('click', '#ConsultasGuardar', function () {
		$('#ConsultasGuardar').attr('disabled', true);
		$('#ConsultasGuardar').unbind()
        if (EjecutarValidacionesAntesDeGuardar() && CheckValidation()) {
				if (!SendConsultasData(function () {
					EjecutarValidacionesDespuesDeGuardar();
					if (!isPartial)
						ConsultasBackToGrid();
					else {						
						if (!isMR)
							window.opener.RefreshCatalog('Consultas', nameAttribute);
						else {
							var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
							if(!control.hasClass('AutoComplete'))
							{
							if (control.attr("data-isfilter") == "true") {
									eval(GetReglaFilter(control,  $(window.opener.document.getElementById('ObjectId')).val()));								    
								}
								else 
								{
									eval('window.opener.Get' + nameMR + '_ConsultasItem()');
									var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
									control.html(eval('window.opener.Get' + nameMR + '_ConsultasDropDown().get(0)').innerHTML);  
								}								
							}
						}
						window.close();						
						}
				})) {
					$('#ConsultasGuardar').removeAttr('disabled');
					$('#ConsultasGuardar').bind()
				}
		}
		else {
			$('#ConsultasGuardar').removeAttr('disabled');
			$('#ConsultasGuardar').bind()
		}
    });
	$("form#CreateConsultas").on('click', '#ConsultasGuardarYNuevo', function () {	
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation()) {
				SendConsultasData(function () {
					ClearControls();
					ClearAttachmentsDiv();
					ResetClaveLabel();
	                getDetalle_Resultados_ConsultasData();

					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Consultas', nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_ConsultasItem()');                           
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);
                            control.html(eval('window.opener.Get' + nameMR + '_ConsultasDropDown().get(0)').innerHTML);   
					    }	
					}						
					EjecutarValidacionesDespuesDeGuardar();				
			setIsNew();
			EjecutarValidacionesAlComienzo();
				});
			}
		}		
    });
    $("form#CreateConsultas").on('click', '#ConsultasGuardarYCopia', function () {
		if (EjecutarValidacionesAntesDeGuardar()) {
			if (CheckValidation())
				SendConsultasData(function (currentId) {
					$("#FolioId").val("0");
	    $('#Paciente').empty();
    $("#Paciente").append('<option value=""></option>');
    $('#Paciente').val('0').trigger('change');
                Detalle_Resultados_ConsultasClearGridData();

					ResetClaveLabel();
					$("#ReferenceFolio").val(currentId);
	                getDetalle_Resultados_ConsultasData();

					EjecutarValidacionesDespuesDeGuardar();		
					if (isPartial)
					{
						 if (!isMR)
					        window.opener.RefreshCatalog('Consultas',nameAttribute);
					    else {
                            eval('window.opener.Get' + nameMR + '_ConsultasItem()');                          
                            var control = $(window.opener.document.getElementsByClassName(nameMR +"_" + nameAttribute)[0]);						
							control.html(eval('window.opener.Get' + nameMR + '_ConsultasDropDown().get(0)').innerHTML);                          
					    }	
					}						
			setIsNew();
				});
		}
    });
});

function setIsNew() {
    $('#hdnIsNew').val("True");
	$('#Operation').val("New");
	operation = "New";
}



var mainElementObject;
var childElementObject;
function DisplayElementAttributes(data) {
}

function getElementTable(elementNumber, table) {

    for (var j = 0; j < childElementObject.length; j++) {
        if (childElementObject[j].table == table) {
            return childElementObject[j].elements[elementNumber];
            break;
        }
    }
}

function setRequired(elementNumber, element, elementType, table) {
    //debugger;
    if (elementType == "1") {
        mainElementObject[elementNumber].IsRequired = (mainElementObject[elementNumber].IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!mainElementObject[elementNumber].IsVisible && mainElementObject[elementNumber].IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (mainElementObject[elementNumber].IsReadOnly && mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    } else {
        getElementTable(elementNumber, table).IsRequired = (getElementTable(elementNumber, table).IsRequired == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsRequired == true ? GetTraduction('Required') : GetTraduction('NotRequired')));
        if (!getElementTable(elementNumber, table).IsVisible && getElementTable(elementNumber, table).IsRequired) {
            setVisible(elementNumber, $(element).parent().parent().find('div.visibleAttribute').find('a'), elementType);
        }
        if (getElementTable(elementNumber, table).IsReadOnly && getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '') {
            setReadOnly(elementNumber, $(element).parent().parent().find('div.readOnlyAttribute').find('a'), elementType);
        }
    }
}
function setVisible(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && mainElementObject[elementNumber].IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        mainElementObject[elementNumber].IsVisible = (mainElementObject[elementNumber].IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && getElementTable(elementNumber, table).IsVisible) {
            showNotification(GetTraduction("messagedNoInVisible"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsVisible = (getElementTable(elementNumber, table).IsVisible == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsVisible == true ? "Images/Visible.png" : "Images/inVisible.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsVisible == true ? GetTraduction('Visible') : GetTraduction('InVisible')));
    }
}
function setReadOnly(elementNumber, element, elementType, table) {
    if (elementType == "1") {
        if (mainElementObject[elementNumber].IsRequired && mainElementObject[elementNumber].DefaultValue == '' && !mainElementObject[elementNumber].IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        mainElementObject[elementNumber].IsReadOnly = (mainElementObject[elementNumber].IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[elementNumber].IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (mainElementObject[elementNumber].IsReadOnly == true ?GetTraduction('Disabled') : GetTraduction('Enabled')));
    } else {
        if (getElementTable(elementNumber, table).IsRequired && getElementTable(elementNumber, table).DefaultValue == '' && !getElementTable(elementNumber, table).IsReadOnly) {
            showNotification(GetTraduction("messagedNoReadOnly"), "error");
            return;
        }
        getElementTable(elementNumber, table).IsReadOnly = (getElementTable(elementNumber, table).IsReadOnly == true ? false : true);
        $(element).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable(elementNumber, table).IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + "");
        $(element).attr('title', (getElementTable(elementNumber, table).IsReadOnly == true ? GetTraduction('Disabled') : GetTraduction('Enabled')));
    }
}
function setDefaultValue(elementNumber, element, elementType, table) {
    //debugger;
    $('#hdnAttributType').val('1');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('DefaultValue'));
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].DefaultValue);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).DefaultValue);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
}
function setHelpText(elementNumber, element, elementType, table) {
    $('#hdnAttributType').val('2');
    $('#hdnAttributNumber').val(elementNumber);
    $('#lblAttributeType').text(GetTraduction('HelpText'));
    if (elementType == "1") {
        $('#txtAttributeValue').val(mainElementObject[elementNumber].HelpText);
        $('#hdnElementType').val("1");
    } else {
        $('#txtAttributeValue').val(getElementTable(elementNumber, table).HelpText);
        $('#hdnElementType').val("2");
    }
    $('#dvAttributeValue').show();
    //$(element).children().attr("src", "" + (mainElementObject[elementNumber].HelpText == '' ? "Images/red-help.png" : "Images/green-help.png") + "");
}
function SaveValue(table) {
    debugger;
    if ($('#hdnElementType').val() == "1") {
        if ($('#hdnAttributType').val() == "1") {
            mainElementObject[$('#hdnAttributNumber').val()].DefaultValue = $('#txtAttributeValue').val();
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].DefaultValue));
        } else if ($('#hdnAttributType').val() == "2") {
            mainElementObject[$('#hdnAttributNumber').val()].HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (mainElementObject[$('#hdnAttributNumber').val()].HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (mainElementObject[$('#hdnAttributNumber').val()].HelpText));
        }
    } else {
        if ($('#hdnAttributType').val() == "1") {
            getElementTable($('#hdnAttributNumber').val(), table).DefaultValue = $('#txtAttributeValue').val();
            console.log(childElementObject[$('#hdnAttributNumber').val()].DefaultValue);
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue == '' ? "Images/Not-Default-Value.png" : "Images/default-value.png") + "");
            $('#hlDefaultValueHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).DefaultValue));
            console.log($('#hdnAttributNumber').val());
        } else if ($('#hdnAttributType').val() == "2") {
            getElementTable($('#hdnAttributNumber').val(), table).HelpText = $('#txtAttributeValue').val();
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).children().attr("src", "" + $('#hdnApplicationDirectory').val() + (getElementTable($('#hdnAttributNumber').val(), table).HelpText == '' ? "Images/red-help.jpg" : "Images/green-help.png") + "");
            $('#hlHelpTextHeader_' + $('#hdnAttributNumber').val()).attr('title', (getElementTable($('#hdnAttributNumber').val(), table).HelpText));
        }
    }
    $('#txtAttributeValue').val('');
    $('#dvAttributeValue').hide();
}
function returnAttributeHTML(element, table, number) {
    var mainElementAttributes = '<div class="col-ld-12" style="display:inline-flex;">';
    mainElementAttributes += '<div class="displayAttributes requiredAttribute"><a class="requiredClick" title="' + (element.IsRequired == true ? GetTraduction("Required") : GetTraduction("NotRequired")) + '" onclick="setRequired(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsRequired == true ? "Images/Required.png" : "Images/Not-Required.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes visibleAttribute"><a class="visibleClick" title="' + (element.IsVisible == true ? GetTraduction("Visible") : GetTraduction("InVisible")) + '" onclick="setVisible(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsVisible == true ? "Images/Visible.png" : "Images/InVisible.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes readOnlyAttribute"><a class="readOnlyClick" title="' + (element.IsReadOnly == true ?GetTraduction("Disabled") :GetTraduction("Enabled")) + '" onclick="setReadOnly(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.IsReadOnly == true ? "Images/Disabled.png" : "Images/Enabled.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes defaultValueAttribute"><a id="hlDefaultValueHeader_' + number.toString() + '" class="defaultValueClick" title="' + (element.DefaultValue) + '" onclick="setDefaultValue(' + number.toString() + ', this, 2,  "' + table + '")"><img src="' + $('#hdnApplicationDirectory').val() + (element.DefaultValue != '' && element.DefaultValue != null ? "Images/default-value.png" : "Images/Not-Default-Value.png") + '" alt="" /></a></div>';
    mainElementAttributes += '<div class="displayAttributes helpTextAttribute"><a id="hlHelpTextHeader_' + number.toString() + '" class="helpTextClick" title="' + (element.HelpText) + '" onclick="setHelpText(' + number.toString() + ', this, 2,  \'' + table + '\')"><img src="' + $('#hdnApplicationDirectory').val() + (element.HelpText != '' && element.HelpText != null ? "Images/green-help.png" : "Images/red-help.jpg") + '" alt="" /></a></div>';
    mainElementAttributes += '</div>';
    return mainElementAttributes;
}



var ConsultasisdisplayBusinessPropery = false;
ConsultasDisplayBusinessRuleButtons(ConsultasisdisplayBusinessPropery);
function ConsultasDisplayBusinessRule() {
    if (!ConsultasisdisplayBusinessPropery) {
        $('#CreateConsultas').find('.col-sm-8').each(function () {
			var div =$(this); 
			if ($(this).find('.input-group').length >0)
				div  =  $(this).find('.input-group').first().hasClass('date')? $(this): $(this).find('.input-group').first();	
            var mainElementAttributes = '<div class="col-sm-2">';
            var fieldId = div.data('field-id');
            var fieldName = div.data('field-name');
            var attribute = div.data('attribute');
            mainElementAttributes += '<div class="ConsultasdisplayBusinessPropery"><button onclick="ConsultasGetBusinessRule()" type="button" data-field-id="' + fieldId + '" data-field-name="' + fieldName + '" data-attribute="' + attribute + '" class="btn btn-info btn-lg btnPopupBusinessRules" data-toggle="modal" data-target="#ConsultasBusinessRule-form"><i class="fa fa-cogs fa-spin"></i></button></div>';
            mainElementAttributes += '</div>';
            $(this).after(mainElementAttributes);
        });
    } else {
        $('.ConsultasdisplayBusinessPropery').remove();
    }
    ConsultasDisplayBusinessRuleButtons(!ConsultasisdisplayBusinessPropery);
    ConsultasisdisplayBusinessPropery = (ConsultasisdisplayBusinessPropery ? false : true);
}
function ConsultasDisplayBusinessRuleButtons(flag) {
    var element = $('.displayRuleButton');
    if (flag) {
        element.show();
        element.prop('disabled', false);
    } else {
        element.hide();
        element.prop('disabled', true);
    }
}

