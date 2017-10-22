
/* SECTION BEGIN: For manipulating elements in Partial Views 
*/

function registerEvents() {
    var addEntryElems = document.querySelectorAll('#addEntryToTable');
    $(addEntryElems).each(function () {
        this.addEventListener("click", onAddItem, true);
    });

    $("table.dynamic-data-table").each(function () {
        this.addEventListener("click", onRemoveItem, true)
    });
}

//removes row from html table dynamically
function onRemoveItem(e) {
    if ($(e.target).is('button.close > span')) {
        var row = $(e.target).parentsUntil('table').filter('tr');
        row.remove();

        $(e.target).parents("table").first().focus();
    }
}

//adds row to html table dynamically
function onAddItem(e) {
    var levelOptions = '';
    
    for (let i = 0; i <= 5; i++) {
        levelOptions += '<option value="' + i + '">' + i + '</option>';
    }

    var importanceOptions = '';
    for (let i = 0; i <= 10; i++) {
        importanceOptions += '<option value="' + i + '">' + i + '</option>';
    }

    var newRowHtmlStr = '';
    if ($(e.target).parents("#jobSkills").length) {
        console.log('Job Skill');
        newRowHtmlStr +=
            '<tr class="dynamic-row"> \
                    <td><input class="input1" type="text" placeholder="Enter skill" required/></td> \
                    <td> \
                        <select class="input2" required> \
                            <option value="" disabled selected>Select skill level</option>' +
            levelOptions +
            '</select> \
                    </td> \
                    <td> \
                        <select class="input3" required> \
                            <option value="" disabled selected>Select skill importance</option>' +
            importanceOptions +
            '</select> \
                    </td> \
                    <td> \
                        <button type="button" class="close" aria-label="Close"> \
                            <span aria-hidden="true">&times;</span> \
                        </button> \
                    </td> \
                </tr>';
    }

    else if ($(e.target).parents("#jobEducation").length) {
        newRowHtmlStr +=
            '<tr class="dynamic-row"> \
                    <td><input class="input1" type="text" placeholder="Enter major" required/></td> \
                    <td> \
                        <select class="input2" required> \
                            <option value="" disabled selected>Select importance</option>' +
            importanceOptions +
            '</select> \
                    </td> \
                    <td> \
                        <button type="button" class="close" aria-label="Close"> \
                            <span aria-hidden="true">&times;</span> \
                        </button> \
                    </td> \
                </tr>';
    }
    var newRow = $.parseHTML(newRowHtmlStr);
    
    var tableElem = $(e.target).parentsUntil('div.form-group').filter('div').children('table.dynamic-data-table');
    tableElem.append(newRow);
    $(newRow).find("input").first().focus();
}

//change to switch cases based on arg e
function convertToFormData(e) {
    console.log('Convert to form data');

    //ready job skills inputs for submission
    $(e.target).find("#jobSkills table.dynamic-data-table").each(function () {

        var rowsToModify = $(this).find("tr.dynamic-row .input1").each(function (index) {
            $(this).attr("name", "JobSkills[" + index + "].SkillName");
        });

        rowsToModify = $(this).find("tr.dynamic-row .input2").each(function (index) {
            $(this).attr("name", "JobSkills[" + index + "].SelectedSkillLevel");
        });

        rowsToModify = $(this).find("tr.dynamic-row .input3").each(function (index) {
            $(this).attr("name", "JobSkills[" + index + "].SelectedImportance");
        });

    });

    //ready job education inputs for submission
    $(e.target).find("#jobEducation table.dynamic-data-table").each(function () {

        var rowsToModify = $(this).find("tr.dynamic-row .input1").each(function (index) {
            $(this).attr("name", "JobEducation[" + index + "].Major");
        });

        rowsToModify = $(this).find("tr.dynamic-row .input2").each(function (index) {
            $(this).attr("name", "JobEducation[" + index + "].SelectedImportance");
        });

    });
    
}

/* SECTION END: For manipulating elements in Partial Views 
*/
