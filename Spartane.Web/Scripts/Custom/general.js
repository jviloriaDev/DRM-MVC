
$('.modal').on('hidden.bs.modal', function (e) {

    if ($('.modal').hasClass('in')) {
        $('body').addClass('modal-open');
    }
    if (!$('.modal').is(':visible')) {
        $('body').removeClass('modal-open');
    }

});

$(function () {
	
	//$('#datetimepicker1 > input').mask("00-00-0000", { clearIfNotMatch: true });
    // display focus in and out as per validation
    $('.inputclientrequired').blur(function () {
        if ($(this).val() == '') {
            $(this).parent().closest('.form-group').addclass('has-error');
        } else {
            $(this).parent().closest('.form-group').removeclass('has-error');
        }
    });
});

function setDynamicRenderElement() {
    // display focus in and out as per validation
    $('.inputClientRequired').blur(function () {
        if ($(this).val() == '') {
            $(this).addClass('has-error');
        } else {
            $(this).removeClass('showRequired');
        }
    });
}

function setInputEntityAttributes(inpuElementArray, selectorType, elementType) {
    for (var i = 0; i < inpuElementArray.length; i++) {
        var element = $('' + selectorType + inpuElementArray[i].inputId);
        if (element != undefined) {
            //if (element.val() != undefined) {
                if (!inpuElementArray[i].IsVisible) {
                    if (elementType == 0) {
                        $('' + selectorType + inpuElementArray[i].inputId + 'Header').hide()
                        element.parent().hide();
                    } else {
                        element.parent().closest('.form-group').hide();
                    }
                }
                  if (inpuElementArray[i].IsRequired) {
					 if (element.length >1)
					 {
						for (var j = 0; j< element.length; j++)
						{
							SetRequiredToControl(element[j].id);
						}
					 }
					 else{
                     SetRequiredToControl(element);
					 }
                }
                else {
                    SetNotRequiredToControl(element);
                }
                if (element.val() != undefined) {
                    if (inpuElementArray[i].DefaultValue != '') {
                        switch (inpuElementArray[i].inputType.toString().toLowerCase()) {
                            case 'text':
                                if (element.val() == '' ) {
                                    element.val(inpuElementArray[i].DefaultValue);
                                }
                                break;
                            case 'select':
                                if ($("" + selectorType + inpuElementArray[i].inputId + " option[value='" + inpuElementArray[i].DefaultValue + "']").length > 0) {
                                    element.val(inpuElementArray[i].DefaultValue);
                                }
                                break;
                            case 'file':
                                break;
                            case 'checkbox':
                                //element.attr('checked', true);
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (inpuElementArray[i].HelpText != '') {
                    element.attr('title', inpuElementArray[i].HelpText);
                }
                if (inpuElementArray[i].IsReadOnly) {
                    element.attr('disabled', true);
                }
            }
        //}
    }
}

function htmlEncode(html) {
    return document.createElement('a').appendChild(
        document.createTextNode(html)).parentNode.innerHTML;
};

function htmlDecode(value) {
    return $('<div/>').html(value).text();
}

function closeOpenAllNodes(jsTree) {
    jsTree.jstree('open_all');
    jsTree.jstree('close_all');
}

String.format = function () {
    var s = arguments[0];
    for (var i = 0; i < arguments.length - 1; i++) {
        var reg = new RegExp("\\{" + i + "\\}", "gm");
        s = s.replace(reg, arguments[i + 1]);
    }

    return s;
}


String.prototype.endsWith = function (suffix) {
    return (this.substr(this.length - suffix.length) === suffix);
}

String.prototype.startsWith = function (prefix) {
    return (this.substr(0, prefix.length) === prefix);
}

function showMessageRequired(item) {
    //$('#controlsRequerid').show();
    var error = ShowMessageRequired(item.parent().attr("data-field-name"));
	
	 if (item.parent()[0].tagName == "TD")
	{
		var campo =$(item.closest('table').find('th').eq(item.parent().index()).get(0)).attr("aria-label").trim();
		 error = ShowMessageRequired(campo);
	}
	if (item.parent().hasClass('date') || item.hasClass('inputMoney'))
	{
		var error = ShowMessageRequired(item.parent().parent().attr("data-field-name"));
	}
    if ($('#textRequired').text().indexOf(error) < 0)
        $('#textRequired').append(error + " <br>");

}


function checkClientValidate(formSelector) {
    $('#textRequired').empty();
    var elementValid = true;
    $('.' + formSelector + ' .inputClientRequired').each(function () {
        if (this.nodeName.toString().toLowerCase() == 'select') {
            if ($(this).val() == '') {
                $(this).parent().closest('.form-group').addClass('has-error');
                 showMessageRequired($(this));
                elementValid = false;
            } else {
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }
        else if (this.nodeName.toString().toLowerCase() == 'textarea' && $(this).data('type') == 'ckEditor') {          
            if (CKEDITOR.instances[this.name].getData() == '') {
                $(this).parent().closest('.form-group').addClass('has-error');
                showMessageRequired($(this));
                elementValid = false;
            } else {
                $("textarea#" + this.name).val(htmlEncode(CKEDITOR.instances[this.name].getData()));
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }
		else  if (this.nodeName.toString().toLowerCase() == 'input' && $(this).prop("type") == 'file') {  
			if ($(this).val() == '' || $(this).val() ==null) {		
				var hndFile = '#hdnAttached' + this.name.replace('File', '');
				var hndFileRemoved = '#hdnRemove' + this.name.replace('File', '');
				if ($(hndFile).val()== undefined || $(hndFile).val()=='' || $(hndFileRemoved).val()=='1')
				{
					$(this).parent().closest('.form-group').addClass('has-error');
					showMessageRequired($(this));
					elementValid = false;
				}
				else{
					   $(this).parent().closest('.form-group').removeClass('has-error');
				}
			}
			else{
					   $(this).parent().closest('.form-group').removeClass('has-error');
			}
		}		

        else {
            if ($(this).val() == '' || $(this).val() ==null) {
                $(this).parent().closest('.form-group').addClass('has-error');
               showMessageRequired($(this));
                elementValid = false;
            } else {
                //$(this).removeClass('showRequired');
                $(this).parent().closest('.form-group').removeClass('has-error');
            }
        }
    });
    if (elementValid === true)
        $('#controlsRequerid').hide();
    else
        $('#controlsRequerid').show();

	 $('html,body').animate({
        scrollTop: $('#viewmodeledit').offset().top
    }, '4000');
    return elementValid;
}
function dynamicFieldValidation(formSelector) {
    var elementValid = true;
    $('.' + formSelector + ' .inputClientRequired').each(function () {
		if($(this).css('display') != 'none')
		{
			if (this.nodeName.toString().toLowerCase() == 'select') {
				if ($(this).val() == '' || $(this).val() == $(this).next().val()) {
					$(this).addClass('showRequired');
					$(this).focus();
					elementValid = false;
				} else {
					$(this).removeClass('showRequired');
				}
			} else {
				if ($(this).val() == '') {
					$(this).addClass('showRequired');
					$(this).focus();
					elementValid = false;
				} else {
					$(this).removeClass('showRequired');
				}
			}
		}
    });

    setDynamicRenderElement();
    return elementValid;
}

$('body').on('keydown', '.inputNumber', function (e) {
    // Allow: backspace, delete, tab, escape, enter and .
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        // Allow: Ctrl+A, Command+A
        (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
        // Allow: home, end, left, right, down, up
        (e.keyCode >= 35 && e.keyCode <= 40)) {
        // let it happen, don't do anything
        return;
    }
    // Ensure that it is a number and stop the keypress
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});

function ajaxindicatorstart(text) {
    if (jQuery('body').find('#resultLoading').attr('id') != 'resultLoading') {
        jQuery('body').append('<div id="resultLoading" class="pace pace-active"><div class="bg"><div class="loading-spinner"><div class="sk-spinner sk-spinner-chasing-dots"><div class="sk-dot1"></div><div class="sk-dot2"></div></div></div></div></div>');
    }
    jQuery('#resultLoading').css({
        'width': '100%',
        'height': '100%',
        'position': 'fixed',
        'z-index': '10000000',
        'top': '0',
        'left': '0',
        'right': '0',
        'bottom': '0',
        'margin': 'auto',
        'padding-top': '100'
    });
    jQuery('#resultLoading .bg').css({
        'background': 'rgba(0, 0, 0, .7) none repeat scroll 0 0',
        'width': '100%',
        'height': '100%',
        'position': 'absolute',
        'top': '0',
        'padding-top': '100'
    });
    jQuery('#resultLoading .bg').height('100%');
    jQuery('#resultLoading').fadeIn(300);
    jQuery('body').css('cursor', 'wait');
}

function ajaxindicatorstop() {
    jQuery('#resultLoading .bg').height('100%');
    jQuery('#resultLoading').fadeOut(300);
    jQuery('body').css('cursor', 'default');
}

//LOADING
//jQuery(document).ajaxStart(function () {
//    ajaxindicatorstart('loading data.. please wait..');
//}).ajaxStop(function () {
//    //hide ajax indicator
//    ajaxindicatorstop();
//});


function ReplaceFLD(text, rowIndex, nameOfTable) {
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLD\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
		valueOfVar = '';
        nameOfVar = nameOfTable + matches[1] + rowIndex;
		if($('#' + nameOfVar).is('input:checkbox'))
		{
			valueOfVar = $('#' + nameOfVar).is(':checked');
		}
		if($('#' + nameOfVar).is('input:text') || $('#' + nameOfVar).is('input:password') || $('#' + nameOfVar).is('textarea'))
		{			
			valueOfVar = $('#' + nameOfVar).val();
		}
		if($('#' + nameOfVar).is('select'))
		{			
			valueOfVar = $('#' + nameOfVar).val();
		}
		if($('#' + nameOfVar).is('input:text') && $('#' + nameOfVar).parent().id == 'datetimepicker1' )
		{
			valueOfVar = $('#' + nameOfVar).datepicker({ dateFormat: 'dd-mm-yy' }).val();
		}
		if($.trim(valueOfVar) == '' || valueOfVar == undefined)
		{
			valueOfVar = null;
		}
		if ($('#' + nameOfVar)[0] != null) {
		     if ($($('#' + nameOfVar)[0]).hasClass('inputMoney')) {
		        valueOfVar = valueOfVar.replace(',', '');
		    }
		}
        text = text.replace(matches[0], valueOfVar);
		text = text.replace("\'null\'", '');
		text = text.replace("\'null\'", "\'\'");
		  if (text.indexOf("(,") > 0) {
           text=  text.replace('(,', '(');
        }
        matches = regExp.exec(text);
    }
    return text;
}

function ReplaceFLDP(text, rowIndex, nameOfTable) {
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLDP\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = $('#' + nameOfVar).val();
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function ReplaceFLDD(text, rowIndex, nameOfTable) {
    if (rowIndex == undefined || rowIndex == null)
        rowIndex = '';
    if (nameOfTable == undefined || nameOfTable == null)
        nameOfTable = '';
    var regExp = /FLDD\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = nameOfTable + matches[1] + rowIndex;
        valueOfVar = $.trim($('#' + nameOfVar).text());
        if($('#' + nameOfVar).is('select'))
		{			
			 valueOfVar = $('#' + nameOfVar + ' option:selected' ).text();
		}
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

//For HTML field
function ReplaceFLDH(text) {
    var regExp = /FLDH\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    var nameOfVar;
    var valueOfVar;
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = CKEDITOR.instances[nameOfVar].getData();
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function ReplaceGLOBAL(text) {
    var nameOfVar;
    var valueOfVar;
    var regExp = /GLOBAL\[([^\]]+)\]/;
    var matches = regExp.exec(text);
    while (matches != null) {
        nameOfVar = matches[1];
        valueOfVar = GetSessionValue(nameOfVar);
        text = text.replace(matches[0], valueOfVar);
        matches = regExp.exec(text);
    }
    return text;
}

function EvaluaQuery(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);
    var res = '';
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQuery",
        type: 'POST',
        cache: false,
        dataType: "json",
        async: false,
        data: data,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    //return res;
    return TryParseInt(res, res);
}


function DecodifyText(text, rowIndex, nameOfTable) {
    text = ReplaceFLD(text, rowIndex, nameOfTable);
    text = ReplaceFLDD(text, rowIndex, nameOfTable);
    text = ReplaceGLOBAL(text);
    return text;
}


function GetSessionValue(name) {
    var res = '';
    $.ajax({
        url: url_content + "Frontal/General/GetSessionVar?name=" + name,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error buscando variable", "error");
        }
    });
    return res;
}

function CreateSessionVar(name, value) {
	value = ReplaceFLD(value);
    value = ReplaceFLDD(value);
    value = ReplaceFLDH(value);
	
    $.ajax({
        url: url_content + "Frontal/General/AddSessionVar?name=" + name + "&val=" + value,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            return result;
        },
        error: function (result) {
            showNotification("Error creando variable", "error");
        }
    });
}

//TextBox(Texto, Fecha, Hora)
function ShowHideTextbox(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableTextbox(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueTextbox(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).val(result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).val(val);
    }
}

//DropDown
function ShowHideDropdown(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableDropdown(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueDropdown(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).val(result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).val(val);
    }
}
//HTML Editor
function ShowHideHTMLEditor(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableHTMLEditor(idField, trueOrFalse) {
    CKEDITOR.instances['JobDescription'].config.readOnly = !trueOrFalse;
}
function DefaultValueHTMLEditor(idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            CKEDITOR.instances[idField].insertText(result);
        });
    }
    else {
        CKEDITOR.instances[idField].insertText(val);
    }
}
//CheckBox
function ShowHideCheckbox(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableCheckbox(idForm, idField, trueOrFalse) {
    $("form#" + idForm + " #" + idField).prop('disabled', trueOrFalse);
}
function DefaultValueCheckbox(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).prop('checked', result);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).prop('checked', val);
    }
}
//AutoComplete
function ShowHideAutocomplete(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableAutocomplete(idForm, idField, trueOrFalse) {
    $("form#" + idForm + " #" + idField).prop('disabled', !trueOrFalse);
}
function DefaultValueAutocomplete(idForm, idField, valId, text/*Aqui deberia ir la query*/, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).append($('<option>', {
                value: valId,
                text: result
            }));
            $("form#" + idForm + " #" + idField).val(valId).trigger("change");
        });
    }
    else {
        $("form#" + idForm + " #" + idField).append($('<option>', {
            value: valId,
            text: text
        }));
        $("form#" + idForm + " #" + idField).val(valId).trigger("change");
    }
}
//RadioButton
function ShowHideRadiobutton(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableRadiobutton(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField).prop('disabled', disabledOrEmpty);
}
function DefaultValueRadiobutton(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            $("form#" + idForm + " #" + idField).filter('[value="' + result + '"]').attr('checked', true);
        });
    }
    else {
        $("form#" + idForm + " #" + idField).filter('[value="' + val + '"]').attr('checked', true);
    }
}

//FileUpload
function ShowHideFileupload(idForm, idField, blockOrNone) {
    $("form#" + idForm + " #div" + idField).css('display', blockOrNone);
}
function EnableDisableFileupload(idForm, idField, disabledOrEmpty) {
    $("form#" + idForm + " #" + idField + "File").prop('disabled', disabledOrEmpty);
}
function DefaultValueFileupload(idForm, idField, val, isQuery) {
    if (isQuery == true) {
        EvaluaQuery(val, function (result) {
            getFileNameById(result, function (name) {
                $("form#" + idForm + " #DefaultName" + idField).text('Default: ' + name);
            });
            $("form#" + idForm + " #Default" + idField).val(result);
        });
    }
    else {
        getFileNameById(val, function (name) {
            $("form#" + idForm + " #DefaultName" + idField).text('Default: ' + name);
        });
        $("form#" + idForm + " #Default" + idField).val(val);
    }
}

function getFileNameById(id, callbak) {
    $.ajax({
        url: url_content + "Frontal/General/GetFileNameById?id=" + id,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            return callbak(result);
        },
        error: function (result) {
            showNotification("Error buscando file", "error");
        }
    });
}

//GRID RULES

//Show/Hide es el mismo metodo para cualquier columna
function ShowHideGridColumn(idForm, idField, blockOrNone) {
    $("#" + idForm + " ." + idField + 'Header').css('display', blockOrNone);
}

//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridTextbox(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridCheckbox(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridDropdown(idForm, idField, disabledOrEmpty) {
    $("#" + idForm + " ." + idField).prop('disabled', disabledOrEmpty);
}
//TextBox Grid(Texto, Fecha, Hora)
function EnableDisableGridAutomcomplete(idForm, idField, trueOrFalse) {
    $("#" + idForm + " ." + idField).prop('disabled', !trueOrFalse);
}

function SetRequiredToControl(element) {
    element = jQuery.type(element) == "string" ? $('#' + element) : element;
	
    var aterisk = "<i class='fa fa-asterisk fa-asterisk-req' aria-hidden='true'></i>";
	if ($(element.selector + "File").is('input:file'))
	    element = $(element.selector + "File");
	
    element.addClass('inputClientRequired');
    if (element.parent().prev().children('i').length == 0 && element.parent().is("div"))
        element.parent().prev().append(aterisk);

    if ((element.parent().hasClass('date') || element.hasClass('inputMoney')) && !element.parent().is("td"))
        element.parent().parent().prev().append(aterisk);
    
    if (element.parent().is("td") && element.parent().children('.fa-asterisk').length == 0) {
        element.parent().append(aterisk);
        element.parent().parent().removeClass('nowrap');
      //  element.parent().parent().addClass('nowrap');
    }

}

function SetNotRequiredToControl(element) {
    element = jQuery.type(element) == "string" ? $('#' + element) : element;

	if ($(element.selector + "File").is('input:file'))
		element = $(element.selector + "File");
	
	if (element.parent().hasClass('date') || element.hasClass('inputMoney'))
        element.parent().parent().prev().children('.fa-asterisk').remove();
	
    element.removeClass('inputClientRequired');
    element.parent().prev().children('.fa-asterisk').remove();
    element.parent().children('.fa-asterisk').remove();
}


function SendEmail(to, subject, body) {
    to = ReplaceGLOBAL(to);
    subject = ReplaceFLD(subject);
    subject = ReplaceFLDD(subject);
    body = ReplaceFLD(body);
    body = ReplaceFLDD(body);
    body = ReplaceFLDH(body);

    var data = {
        to: to,
        subject: subject,
        body: body
    };
    $.ajax({
        //   url: '/Frontal/Empleados/PostJobHistory?empleadoId=' + employeeId + "&referenceId=" + $("#ReferenceClave").val(),
        url: url_content + "Frontal/General/SendEmail",
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        async: true,
        success: function (result) {

        },
        error: function (result) {
            showNotification("Error enviando correo", "error");
        },
        cache: false,
        contentType: 'application/json; charset=utf-8',
        processData: false
    });
}

function SendEmailQuery(subject, to, body, rowIndex, nameOfTable) {
   
   subject = ReplaceFLD(subject, rowIndex, nameOfTable);
    subject = ReplaceFLDD(subject, rowIndex, nameOfTable);
    body = ReplaceFLD(body, rowIndex, nameOfTable);
    body = ReplaceFLDD(body, rowIndex, nameOfTable);
    body = ReplaceFLDH(body);
	body = ReplaceGLOBAL(body);
	
    var data = {
        to: to,
        subject: subject,
        body: body
    };
    $.ajax({
        //   url: '/Frontal/Empleados/PostJobHistory?empleadoId=' + employeeId + "&referenceId=" + $("#ReferenceClave").val(),
        url: url_content + "Frontal/General/SendEmail",
        type: 'POST',
        data: JSON.stringify(data),
        dataType: 'json',
        async: true,
        success: function (result) {

        },
        error: function (result) {
            showNotification("Error enviando correo", "error");
        },
        cache: false,
        contentType: 'application/json; charset=utf-8',
        processData: false
    });
}

var ElementToAdd = null;
function fillMRFromQuery(nameOfTable, query) {
    var res = '';
    query = ReplaceFLD(query, '', '');
    query = ReplaceFLDD(query, '', '');
    query = ReplaceGLOBAL(query);
    var data = {
        query: query
    }

    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryTable",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
            var jsonObj = $.parseJSON(result);
            var table = nameOfTable + 'Table';
            var data = eval(table);
            data.fnClearTable();
            $.each(jsonObj, function (index, element) {
                ElementToAdd = element;
                var objReturn = null;
                jQuery.globalEval(nameOfTable + 'AddInsertRow(true)');
                ElementToAdd=null;
                jQuery.globalEval(nameOfTable + 'EditRow(' + index + ', null, false)');
                jQuery.globalEval(nameOfTable + 'InsertRow(' + index + ')');
            });
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}


function EvaluaQueryDictionary(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);
    var res = '';
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryDictionary",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}


function EvaluaQueryEnumerable(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);
    var res = '';
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryEnumerable",
        type: 'POST',
        dataType: "json",
        cache: false,
        async: false,
        data: data,
        success: function (result) {
            res = result;
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}
function ReplaceQuery(query, rowIndex, nameOfTable) {
    query = ReplaceFLD(query, rowIndex, nameOfTable);
    query = ReplaceFLDD(query, rowIndex, nameOfTable);
    query = ReplaceFLDP(query, rowIndex, nameOfTable);
    query = ReplaceGLOBAL(query);

    return query;
    //return TryParseInt(res, res);
}


function sortSelect(selElem) {
	
	var valor =selElem.val();
    var my_options = $(selElem.selector + "  option");

    my_options.sort(function (a, b) {
        if (a.text > b.text) return 1;
        if (a.text < b.text) return -1;
        return 0
    })
    selElem.empty().append(my_options);
	selElem.val(valor);
}



function TryParseInt(str, defaultValue) {
    var retValue = defaultValue;
    if (str !== null) {
			if (str.length > 0) {
				if (!isNaN(str)) {
					if (retValue.indexOf('.') >= 0)
						retValue = parseFloat(str);
					else
						retValue = parseInt(str);
				}
			}
	}
    if (retValue=="null")
	{
		retValue="";
	}
    return retValue;
}

function GetListOfColumns(query)
{
    var data = {
        query: query
    }
    $.ajax({
        url: url_content + "Frontal/General/ExecuteQueryTable",
        type: 'POST',
        cache: false,
        dataType: "json",
        async: false,
        data: data,
        success: function (result) {
            var jsonObj = $.parseJSON(result);
            res = jsonObj['Root']['Data'];
        },
        error: function (result) {
            showNotification("Error ejecutando query", "error");
        }
    });
    return res;
}

function RemoveRequiredElementsIntoTab(divName) {
    var selects = $('#tab' + divName).find('select');
    var inputs = $('#tab' + divName).find('input');
    var textareas = $('#tab' + divName).find('textarea');
    selects.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
    inputs.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
    textareas.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired');
            $(this).addClass('inputClientRequired-hide');
        }
    });
}

function AddRequiredElementsIntoTab(divName) {
    var selects = $('#tab' + divName).find('select');
    var inputs = $('#tab' + divName).find('input');
    var textareas = $('#tab' + divName).find('textarea');
    selects.each(function () {
        if ($(this).hasClass('inputClientRequired-hide')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
    inputs.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
    textareas.each(function () {
        if ($(this).hasClass('inputClientRequired')) {
            $(this).removeClass('inputClientRequired-hide');
            $(this).addClass('inputClientRequired');
        }
    });
}

function GetValueByControlType(control, nameOfTable,rowIndex )
{
	var valueOfVar='';
	if(control.is('input:checkbox'))
	{
		valueOfVar = control.is(':checked');
	}
	if(control.is('input:text') || control.is('textarea'))
	{			
		valueOfVar = control.val();
	}
	if(control.is('select'))
	{			
		valueOfVar = control.val();
		
	}
	if(control.is('input:text') && control.parent().id == 'datetimepicker1' )
	{
		valueOfVar = control.datepicker({ dateFormat: 'dd-mm-yy' }).val();
	}
    if(control.is('td') )
	{
        var controlName = control[0].id.replace(nameOfTable, '').replace(rowIndex, '');
        rowIndex = rowIndex.replace('_', '');
        nameOfTable = nameOfTable.slice(0, -1) + 'Table';
        var data = eval(nameOfTable);
        valueOfVar = data.fnGetData(rowIndex)[controlName];
	}
	else if ($(control.selector + "File").is('input:file'))
	{
		valueOfVar =$(control.selector + "File").val();
	}

    if (control[0]!= undefined && $(control[0]).hasClass('inputMoney')) {
        valueOfVar = valueOfVar.replace(',', '');

    }
	var originalName = control.selector.replace('#','');
	var name = 'hdnAttached' + originalName;
	control = $('#' + name);
	if(control.is('input:hidden'))
	{			
		valueOfVar = control.val();
		if(valueOfVar == '' || valueOfVar == null)
		{
			control = $('#' + originalName + 'File');
			valueOfVar = control.val();
		}
	}
	//hdnAttachedContrato_Firmado
	
	return  valueOfVar= valueOfVar ==null? null: valueOfVar.toString();
}

function SetDefectValue(control, val) {
    var c = nameOfTable + control + rowIndex;
    if ($('#' + c).is('input:checkbox')) {
        $('#' + c).prop('checked', val == 'true');
    }
    else {
        $('#' + c).val(val);
    }
}

function GetFile(id) {
    var res = {
        id: 0,
        name: '',
        url: ''
    };
    $.ajax({
        url: url_content + "Frontal/General/GetSpartanFile?id=" + id,
        type: 'GET',
        cache: false,
        dataType: "json",
        async: false,
        success: function (result) {
            var description = result.Description;
            var id = result.File_Id;
            var url = url_content + 'Frontal/Client_Registration/GetFile?id=' + id;
            res.id = id;
            res.name = description;
            res.url = url;
        },
        error: function (result) {
            showNotification("Error obteniendo File", "error");
        }
    });
    return res;
}

function AsignarValor(nameOfControl, val) {
        var control = jQuery.type(nameOfControl) == "string" ? $('#' + nameOfControl) : nameOfControl;
    nameOfControl = jQuery.type(nameOfControl) == "string" ? nameOfControl : control.selector;

    var controlFile = $(nameOfControl + "File")
    if (controlFile.length) {
        var file = GetFile(val)
        if ($('#' + nameOfControl).length) {
            $('#' + nameOfControl).val(587);
        }
        else {
            controlFile.parent().append('<input type="hidden" id="' + nameOfControl + '" name="' + nameOfControl + '" value="' + file.id + '" />')
        }
        controlFile.parent().append('<a href="' + file.url + '">' + file.name + '</a>');
    }
    else {
        if (control.is('input:checkbox')) {
            control.prop('checked', val == "true").trigger('change');
        }
          if (control.is('input:text') || control.is('textarea')) {
            control.val(val);
        }
        if (control.is('select') && !control.hasClass('AutoComplete')) {
            control.val(val).trigger('change');
        }
        if (control.hasClass('AutoComplete')) {
            control.select2('open');
			$('.select2-search__field').val(val).trigger('keyup');	
			control.select2('close');  			
             var data = eval('AutoComplete' + control.selector.replace(nameOfTable, '').replace(rowIndex, '').replace('#', '') + 'Data');			 
             control.select2({ data: data });
			 $.each( data, function( key, value ) {
				if (value.text == val) 
					control.val(value.id).trigger('change');
			});			     
        }
    }
}



function EvaluaOperatorIn(parameter1, parameter2)
{
    debugger;
    var arr = parameter2.split(',');
    var result = false;
    for (var i = 0; i < arr.length; i++)
    {
        if (TryParseInt(parameter1, parameter1) === TryParseInt(arr[i],arr[i]) )
        {
            result = true;
            break;
        }
    }
    return result;
}


function formatAmmount(Ammount)
{
	return Ammount != null && Ammount!= undefined? Ammount.toString().replace('$','').replace(',',''):0;
}


//This will sort your array
function SortByName(a, b){
  var aName = a.name.toLowerCase();
  var bName = b.name.toLowerCase(); 
  return ((aName < bName) ? -1 : ((aName > bName) ? 1 : 0));
}


function DisabledControl(Control, disabled)
{
	var controlFile = Control.selector + "File";
    if ($(controlFile).length>0) {
		Control = controlFile;
    }
	
    if ($(this).data('type') == 'ckEditor') 
        {
		CKEDITOR.instances['TEXTAREA_NAME'].setReadOnly(disabled);	
		return;
	}
	disabled ? $(Control).prop("disabled",  "disabled"): $(Control).removeAttr("disabled");			
}



function filterCombo(control, dictionary) {
    var isMultiseleccion = false;
   
    if ($("#ddl" + control.selector.replace("#", "") + "Mult") != 'undefined' && $("#ddl" + control.selector.replace("#", "") + "Mult").is('select')) {
        control = $("#ddl" + control.selector.replace("#", "") + "Mult");
        isMultiseleccion = true;
    }
    var valor = $(control).val();
    $(control).empty();
    if (!$(control).hasClass('AutoComplete')) {
        $(control).append($("<option selected />").val("").text(""));
        $.each(dictionary, function (index, value) {
            $(control).append($("<option />").val(value.Clave).text(value.Description));
        });
        $(control).val(valor);
    }
    else {
        var selectData = []; selectData.push({ id: "", text: "" });
        $.each(dictionary, function (index, value) {
            selectData.push({ id: value.Clave, text: value.Description });
        });
        $(control).select2({ data: selectData })
        $(control).val(valor).trigger('change');
    }
    if (isMultiseleccion) {
        $(control).trigger('chosen:updated');
    }
}


function addItemsToSelect(control, items) {
   control.empty();
    $(control).append($('<option />', { value: '', text: '' }));
    $.each(items, function (i, item) {
        $(control).append($('<option>', {
            value: item.Value,
            text: item.Text
        }));
    });
}

function addNew(nameMR, catalog, nameAttr) {
    return "<div class='abm-icons' style='display:inline-block; padding-left:10px;'>" +
                   "<a id='Estado_New' onclick='GetCatalogPopup(\"" + catalog + "\",  \"" + nameAttr + "\", true,  \"" + nameMR + "\");' href='#'><i class='glyphicon glyphicon-plus'></i></a>" +
                 "</div>";
}

function isInt(n) {
    return +n === n && !(n % 1);
}

function getUUID() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });
}

function getObjectFromLocalStorage(name, id) {
    var object = {};
    function iterateGet(obj) {
        for (var property in obj) {
            if (obj.hasOwnProperty(property)) {
                if (typeof obj[property] == "object") {
                    iterateGet(obj[property]);
                }
                    //GUID
                else if (property == "GUIDID" && obj[property] == id) {
                    object = obj;
                }
            }
        }
    }

    var obj = JSON.parse(localStorage.getItem(name));
    iterateGet(obj);

    return object;
}

function updateLocalStorage(name, id, propertyName, data) {
    function iterateUpdate(obj) {
        for (var property in obj) {
            if (obj.hasOwnProperty(property)) {
                if (typeof obj[property] == "object") {
                    iterateUpdate(obj[property]);
                }
                    //GUID
                else if (property == "GUIDID" && obj[property] == id) {
                    if (propertyName == "__self") {

                        Object.assign(obj, data);
                    }
                    else
                        obj[propertyName] = JSON.parse(JSON.stringify(data));
                }
            }
        }
    }

    var obj = JSON.parse(localStorage.getItem(name));
    iterateUpdate(obj);
    localStorage.setItem(name, JSON.stringify(obj));
}

function getAllUrlParams(url) {

    // get query string from url (optional) or window
    var queryString = url ? url.split('?')[1] : window.location.search.slice(1);

    // we'll store the parameters here
    var obj = {};

    // if query string exists
    if (queryString) {

        // stuff after # is not part of query string, so get rid of it
        queryString = queryString.split('#')[0];

        // split our query string into its component parts
        var arr = queryString.split('&');

        for (var i = 0; i < arr.length; i++) {
            // separate the keys and the values
            var a = arr[i].split('=');

            // in case params look like: list[]=thing1&list[]=thing2
            var paramNum = undefined;
            var paramName = a[0].replace(/\[\d*\]/, function (v) {
                paramNum = v.slice(1, -1);
                return '';
            });

            // set parameter value (use 'true' if empty)
            var paramValue = typeof (a[1]) === 'undefined' ? true : a[1];

            // (optional) keep case consistent
            paramName = paramName.toLowerCase();
            paramValue = paramValue.toLowerCase();

            // if parameter name already exists
            if (obj[paramName]) {
                // convert value to array (if still string)
                if (typeof obj[paramName] === 'string') {
                    obj[paramName] = [obj[paramName]];
                }
                // if no array index number specified...
                if (typeof paramNum === 'undefined') {
                    // put the value on the end of the array
                    obj[paramName].push(paramValue);
                }
                // if array index number specified...
                else {
                    // put the value at that index number
                    obj[paramName][paramNum] = paramValue;
                }
            }
            // if param name doesn't exist yet, set it
            else {
                obj[paramName] = paramValue;
            }
        }
    }

    return obj;
}

function deleteFromLocalStorage(name, id) {
    var obj = JSON.parse(localStorage.getItem(name));
    var deletedObj = {};
    function iterateDelete(obj, id) {
        for (var property in obj) {
            if (obj !== null) {
                if (obj.hasOwnProperty(property)) {
                    if (typeof obj[property] == "object") {
                        //GUID
                        if (obj[property] && obj[property].GUIDID == id) {
                            deletedObj = obj[property];
                            const index = obj.indexOf(obj[property]);
                            if (index !== -1) {
                                obj.splice(index, 1);
                            }
                        }
                        else {
                            iterateDelete(obj[property], id);
                        }
                    }
                }
            }
        }
    }
    iterateDelete(obj, id);

    localStorage.setItem(name, JSON.stringify(obj, (key, value) => {
        if (value !== null)
            return value
    }));
    return deletedObj;
}

function PostTemporaryFile(id, nodes, catalog) {
	var fileData = new FormData();
	if (nodes != null) {
		$.each(nodes.files, function (i, file) {
			fileData.append('file-' + i, file);
		});
	}
	
	$.ajax({
		//url: url_content + "~/Frontal/"+catalog+"/PostFiles?path=" + id,
		url: url_content + "/Frontal/General/PostFiles?path=" + id,
		data: fileData,
		cache: false,
		contentType: false,
		processData: false,
		method: 'POST',
		type: 'POST',
		async: false,
		success: function (data) {
		}
	});
}
$('#datetimepicker1 > input').inputmask("99-99-9999", { "placeholder": "dd-mm-yyyy" });
//fjmore funcion solo decimales
function isDecimalKey(txt, evt) {

    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode == 46) {
        //Check if the text already contains the . character
        if (txt.value.indexOf('.') === -1) {
            return true;
        } else {
            return false;
        }
    } else {
        if (charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;
    }
    return true;
}




//funcion solo numeros
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function TableUpdateRowIndex(tableName) {

    var table = eval(tableName  + "Table");

    for (var i = 0; i < table.fnGetNodes().length; i++) {
        var tr = table.fnGetNodes(i);
        $(tr).removeAttr("class");
        $(tr).addClass(tableName + "_" + i + " odd");
        var tdAction = tr.childNodes[0];

        $(tdAction.childNodes[0]).removeAttr("onclick");
        $(tdAction.childNodes[0]).attr("onclick", "if(dynamicFieldValidation('" + tableName  + "_" + i + "')){ "+ tableName + "InsertRow(" + i + "); }");


        $(tdAction.childNodes[1]).removeAttr("onclick");
        $(tdAction.childNodes[1]).attr("onclick", tableName + "CancelRow(" + i + ")")

        for (var j = 1 ; j < tr.childNodes.length; j++) {
            var td = tr.childNodes[j];

            td.id = td.id.replace(td.id.substring(td.id.lastIndexOf("_") + 1), i);
            var control = td.childNodes[0];

            if (control.nodeName == "#text")
                control = control.nextElementSibling;

            var id = control.id;
            control.id = id.replace(id.substring(id.lastIndexOf("_") + 1), i);
        }
    }
}
