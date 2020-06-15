$(document).ready(function () {
    var inpuElementArray = [
        { "inputId": "Key_Business_Rule_Creation", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "User", "inputType": "select", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Creation_Date", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "Creation_Hour", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "Last_Updated_Date", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "Last_Updated_Hour", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Time_that_took", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Name", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "DocumentationFile", "inputType": "file", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Status", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Complexity", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementArray, "#", 1);
});

function setSpartan_BR_Conditions_DetailValidation() {
    var inpuElementChildArray = [
        { "inputId": "XXX", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "Default", "HelpText": "" }
        , { "inputId": "First_Operator_Type", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "Condition_Operator", "inputType": "select", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "First_Operator_Value", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "Second_Operator_Type", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "Second_Operator_Value", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "Condition", "inputType": "select", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementChildArray, ".", 0);
    setDynamicRenderElement();
}

function setSpartan_BR_Actions_True_DetailValidation() {
    var inpuElementChildArray = [
        { "inputId": "XXX", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "Default", "HelpText": "" }
        ,{ "inputId": "Action_Classification", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Action", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Action_Result", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_1", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_2", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_3", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_4", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_5", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementChildArray, ".", 0);
    setDynamicRenderElement();
}

function setSpartan_BR_Actions_False_DetailValidation() {
    var inpuElementChildArray = [
        { "inputId": "XXX", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "Default", "HelpText": "" }
        ,{ "inputId": "Action_Classification", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Action", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Action_Result", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_1", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_2", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_3", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_4", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        //, { "inputId": "Parameter_5", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementChildArray, ".", 0);
    setDynamicRenderElement();
}

function setSpartan_BR_Operation_DetailValidation() {
    var inpuElementChildArray = [
        { "inputId": "XXX", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "Default", "HelpText": "" }
        ,{ "inputId": "Operation", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementChildArray, ".", 0);
    setDynamicRenderElement();
}

function setSpartan_BR_Process_Event_DetailValidation() {
    var inpuElementChildArray = [
        { "inputId": "XXX", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "Default", "HelpText": "" }
        ,{ "inputId": "Process_Event", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementChildArray, ".", 0);
    setDynamicRenderElement();
}

function setSpartan_BR_Peer_ReviewValidation() {
    var inpuElementChildArray = [
        { "inputId": "XXX", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "Default", "HelpText": "" }
        ,{ "inputId": "User_that_reviewed", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Acceptance_Criteria", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "It_worked", "inputType": "checkbox", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": null, "HelpText": "" }
        ,{ "inputId": "Rejection_reason", "inputType": "select", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Comments", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "EvidenceFile", "inputType": "file", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementChildArray, ".", 0);
    setDynamicRenderElement();
}

function setSpartan_BR_TestingValidation() {
    var inpuElementChildArray = [
        { "inputId": "XXX", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "Default", "HelpText": "" }
        ,{ "inputId": "User_that_reviewed", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "Acceptance_Critera", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        ,{ "inputId": "It_worked", "inputType": "checkbox", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": null, "HelpText": "" }
        , { "inputId": "Rejection_Reason", "inputType": "select", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "Comments", "inputType": "text", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }
        , { "inputId": "EvidenceFile", "inputType": "file", "IsRequired": false, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementChildArray, ".", 0);
    setDynamicRenderElement();
}

function setSpartan_BR_Scope_DetailValidation() {
    var inpuElementChildArray = [
        { "inputId": "XXX", "inputType": "text", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "Default", "HelpText": "" }
        ,{ "inputId": "Scope", "inputType": "select", "IsRequired": true, "IsVisible": true, "IsReadOnly": false, "DefaultValue": "", "HelpText": "" }

    ];
    setInputEntityAttributes(inpuElementChildArray, ".", 0);
    setDynamicRenderElement();
}


