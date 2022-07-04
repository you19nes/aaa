﻿$(".custom-file-input").on("change", function () {
	var fileName = $(this).val().split("\\").pop();
	$(this).siblings(".custom-file-label").addClass("selected").html(fileName);
});



function DeleteItem(btn) {
	$(btn).closest('tr').remove();
}



function AddItem(btn) {

	var table = document.getElementById('ExpTable');
	var rows = table.getElementsByTagName('tr');

	var rowOuterHtml = rows[rows.length - 1].outerHTML;

	var lastrowIdx = document.getElementById('hdnLastIndex').value;

	var nextrowIdx = eval(lastrowIdx) + 1;

	document.getElementById('hdnLastIndex').value = nextrowIdx;

	rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
	rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
	rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);


	var newRow = table.insertRow();
	newRow.innerHTML = rowOuterHtml;



	var btnAddID = btn.id;
	var btnDeleteid = btnAddID.replaceAll('btnadd', 'btnremove');

	var delbtn = document.getElementById(btnDeleteid);
	delbtn.classList.add("visible");
	delbtn.classList.remove("invisible");


	var addbtn = document.getElementById(btnAddID);
	addbtn.classList.remove("visible");
	addbtn.classList.add("invisible");

	rebindvalidators();
}
function rebindvalidators() {
	var $form = $("#ApplicantForm")
	$form.unbind();
	$form.data("validator", null);
	$.validator.unobtrusive.parse($form);
	$form.validate($form.data("unobtrusiveValidation").options);
}