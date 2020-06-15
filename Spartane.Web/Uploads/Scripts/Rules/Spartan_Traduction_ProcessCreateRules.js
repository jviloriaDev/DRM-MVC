var operation = $('#Operation').val();
var nameOfTable = '';
var rowIndex = '';
$(document).ready(function () {


        $('#Object_Type').change(function () {
            if ($(this).val() == 5) {
				
                fillMRFromQuery("Spartan_Traduction_Detail","  SELECT ISNULL(IdTraductionDetail,0) as IdTraductionDetail,9 as Concept,FormatId As IdConcept , Format_Name as Original_Text, isnull(Translated_Text, '') As Translated_Text  " +
                                 " FROM Spartan_Format spf " +
                                 " left join Spartan_Traduction_Detail tra on (spf.FormatId = tra.IdConcept)"+
                                 "left join Spartan_Traduction_Process pro on (pro.Spartan_Traduction_Process = pro.IdTraduction)"+
                                  " where (pro.LanguageT = FLD[LanguageT] OR pro.LanguageT  IS NULL) AND (Object_Type = 5 or Object_Type is null) ");
                SetNotRequiredToControl($('#ObjectT'));
            }
            else if ($(this).val() == 6) {
               fillMRFromQuery("Spartan_Traduction_Detail", "SELECT ISNULL(IdTraductionDetail,0)  as IdTraductionDetail, 10 as Concept,ReportId As IdConcept , Report_Name as Original_Text, isnull(Translated_Text, '') As Translated_Text" +
								" FROM Spartan_Report spf " +
                                " left join Spartan_Traduction_Detail tra on (spf.ReportId = tra.IdConcept)"+
                                  "left join Spartan_Traduction_Process pro on (tra.Spartan_Traduction_Process = pro.IdTraduction)"+
                                 " where (pro.LanguageT = FLD[LanguageT] OR pro.LanguageT  IS NULL)  AND (Object_Type = 6 or Object_Type is null) ");
                SetNotRequiredToControl($('#ObjectT'));
            }

        });
    
    
    //NEWBUSINESSRULE_NONE//



});
function EjecutarValidacionesAlComienzo() {


    if ($('#Object_Type').val() == 5 || $('#Object_Type').val() == 6) {
		  if ($('#Object_Type').val() == 5) {
				debugger
               fillMRFromQuery("Spartan_Traduction_Detail"," SELECT distinct ISNULL(IdTraductionDetail,0)  as IdTraductionDetail, 9 as Concept,FormatId As IdConcept , Format_Name as Original_Text, isnull(Translated_Text, '') As Translated_Text " + 
															 " FROM Spartan_Format spf   " + 
															" inner join Spartan_Traduction_Detail tra on (spf.FormatId = tra.IdConcept) " + 
															" inner join Spartan_Traduction_Process pro on (tra.Spartan_Traduction_Process = pro.IdTraduction)  " + 
															" where  (Object_Type = 5 AND pro.LanguageT = FLD[LanguageT])  " + 
															" union  " + 
															" SELECT 0 AS IdTraductionDetail, 9 as Concept, FormatId As IdConcept, Format_Name as Original_Text, '' AS Translated_Text " + 
															" FROM Spartan_Format spf " + 
															" where FormatId not in (select IdConcept from  Spartan_Traduction_Detail   tra  inner join Spartan_Traduction_Process pro on (tra.Spartan_Traduction_Process = pro.IdTraduction)  where Object_Type = 5 and LanguageT = FLD[LanguageT])");
								 
								 
								  
                
            }
            else if ($('#Object_Type').val() == 6) {
				debugger
                fillMRFromQuery("Spartan_Traduction_Detail", "SELECT distinct ISNULL(IdTraductionDetail,0)  as IdTraductionDetail, 10 as Concept,ReportId As IdConcept , Report_Name as Original_Text, isnull(Translated_Text, '') As Translated_Text " + 
															 " FROM Spartan_Report spf   " + 
															" inner join Spartan_Traduction_Detail tra on (spf.ReportId = tra.IdConcept) " + 
															" inner join Spartan_Traduction_Process pro on (tra.Spartan_Traduction_Process = pro.IdTraduction)  " + 
															" where  (Object_Type = 6 AND pro.LanguageT = FLD[LanguageT])  " + 
															" union  " + 
															" SELECT 0 AS IdTraductionDetail, 10 as Concept, ReportId As IdConcept, Report_Name as Original_Text, '' AS Translated_Text " + 
															" FROM Spartan_Report spf " + 
															" where ReportId not in (select IdConcept from  Spartan_Traduction_Detail   tra  inner join Spartan_Traduction_Process pro on (tra.Spartan_Traduction_Process = pro.IdTraduction)  where Object_Type = 6 and LanguageT = FLD[LanguageT])");
              
            }
        SetNotRequiredToControl($('#ObjectT'));
      
    }
	
   
   for (var i = 0; i < Spartan_Traduction_Process_DataTable.fnGetData().length; i++) {
        $('.Spartan_Traduction_Process_Data_' + i + ' > td > a.edit-MR').click();
        $('#Spartan_Traduction_Process_Data_Concept_' + i).prop('disabled', 'disabled');
        $('#Spartan_Traduction_Process_Data_Name_of_Control_' + i).prop('disabled', 'disabled');
        $('#Spartan_Traduction_Process_Data_Original_Text_' + i).prop('disabled', 'disabled');

    }

    $('#Spartan_Traduction_Process_DataGrid thead > tr > th:eq(0)').css('display', 'none');
    $('#Spartan_Traduction_Process_DataGrid tbody tr > td:first-child').css('display', 'none');
    for (var i = 0; i < Spartan_Traduction_DetailTable.fnGetData().length; i++) {
        $('.Spartan_Traduction_Detail_' + i + ' > td > a.edit-MR').click();
        $('#Spartan_Traduction_Detail_Concept_' + i).prop('disabled', 'disabled');
        $('#Spartan_Traduction_Detail_IdConcept_' + i).prop('disabled', 'disabled');
        $('#Spartan_Traduction_Detail_Original_Text_' + i).prop('disabled', 'disabled');
    }

    $('#Spartan_Traduction_DetailGrid thead > tr > th:eq(0)').css('display', 'none');
    $('#Spartan_Traduction_DetailGrid tbody tr > td:first-child').css('display', 'none');
    for (var i = 0; i < Spartan_Traduction_Process_WorkflowTable.fnGetData().length; i++) {
        $('.Spartan_Traduction_Process_Workflow_' + i + ' > td > a.edit-MR').click();
        $('#Spartan_Traduction_Process_Workflow_Concept_' + i).prop('disabled', 'disabled');
        $('#Spartan_Traduction_Process_Workflow_ID_of_Step_' + i).prop('disabled', 'disabled');
        $('#Spartan_Traduction_Process_Workflow_Original_Text_' + i).prop('disabled', 'disabled');

    }
	

   $('#Spartan_Traduction_Process_WorkflowGrid thead > tr > th:eq(0)').css('display', 'none');
   $('#Spartan_Traduction_Process_WorkflowGrid tbody tr > td:first-child').css('display', 'none');
  $('#LanguageT').prop('disabled', 'disabled');
    $('#Object_Type').prop('disabled', 'disabled');
    $('#ObjectT').prop('disabled', 'disabled');


    


//NEWBUSINESSRULE_SCREENOPENING//

}
function EjecutarValidacionesAntesDeGuardar(){
    var result = true;
   
//NEWBUSINESSRULE_BEFORESAVING//

    return result;
}
function EjecutarValidacionesDespuesDeGuardar(){
//NEWBUSINESSRULE_AFTERSAVING//

}

function EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_Traduction_Detail//
    return result;
}
function EjecutarValidacionesDespuesDeGuardarMRSpartan_Traduction_Detail(nameOfTable, rowIndex){
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_Traduction_Detail//
}
function EjecutarValidacionesAlEliminarMRSpartan_Traduction_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_DELETEMR_Spartan_Traduction_Detail//
    return result;
}
function EjecutarValidacionesNewRowMRSpartan_Traduction_Detail(nameOfTable, rowIndex){
    var result = true;
    //NEWBUSINESSRULE_NEWROWMR_Spartan_Traduction_Detail//
    return result;
}
function EjecutarValidacionesEditRowMRSpartan_Traduction_Detail(nameOfTable, rowIndexFormed)
{ return true; }

function EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Process_Data(nameOfTable, rowIndexFormed)
{ return true; }
function EjecutarValidacionesDespuesDeGuardarMRSpartan_Traduction_Process_Data(nameOfTable, rowIndexFormed)
{ return true; }
function EjecutarValidacionesAlEliminarMRSpartan_Traduction_Process_Data(nameOfTable, rowIndexFormed)
{ return true; }
function EjecutarValidacionesNewRowMRSpartan_Traduction_Process_Data(nameOfTable, rowIndexFormed)
{ return true; }
function EjecutarValidacionesEditRowMRSpartan_Traduction_Process_Data(nameOfTable, rowIndexFormed)
{ return true; }


function EjecutarValidacionesAntesDeGuardarMRSpartan_Traduction_Process_Workflow(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_BEFORESAVINGMR_Spartan_Traduction_Workflow// 
    return true;
} 

function EjecutarValidacionesDespuesDeGuardarMRSpartan_Traduction_Process_Workflow(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_AFTERSAVINGMR_Spartan_Traduction_Workflow// 
    return true;
} 

function EjecutarValidacionesAlEliminarMRSpartan_Traduction_Process_Workflow(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_DELETEMR_Spartan_Traduction_Workflow// 
    return true;
} 

function EjecutarValidacionesNewRowMRSpartan_Traduction_Process_Workflow(nameOfTable, rowIndex) {
    //NEWBUSINESSRULE_NEWMR_Spartan_Traduction_Workflow// 
    return true;
} 

function EjecutarValidacionesEditRowMRSpartan_Traduction_Process_Workflow(nameOfTable, rowIndex){ 
    //NEWBUSINESSRULE_EDITMR_Spartan_Traduction_Workflow// 
    return true;
} 
