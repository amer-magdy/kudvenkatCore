function confirmDelete(uniqueId,IsTrue) {
    var DeleteSpan = 'deleteSpan_' + uniqueId;
    var ConfirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;
    if (IsTrue) {
        $('#' + DeleteSpan).hide();
        $('#' + ConfirmDeleteSpan).show();
    }
    else {
        $('#' + DeleteSpan).show();
        $('#' + ConfirmDeleteSpan).hide();
    }
}