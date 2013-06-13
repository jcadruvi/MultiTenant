function StoreViewModel() {
    this.$storeButton = $('#storeButton');
    this.$storeDetail = $('#storeDetail');
    this.$traitAddButton = $('#traitAddButton');
    this.$traitAddPanel = $('#traitAddPanel');
    this.$traitAddGridData = null;
    this.$traitViewPanel = $('#traitViewPanel');
    this.$traitViewGridData = null;
}

StoreViewModel.prototype.onStoreClick = function() {
    if (this.$storeButton.val() === '+') {
        this.$storeDetail.show();
        this.$storeButton.val('-');
        this.$traitAddPanel.css('height', '400px');
        this.$traitViewPanel.css('height', '400px');
        this.$traitAddGridData.refresh();
        this.$traitViewGridData.refresh();
        this.$traitAddButton.css('margin-top', '200px');
    } else {
        this.$storeDetail.hide();
        this.$storeButton.val('+');
        this.$traitAddPanel.css('height', '500px');
        this.$traitViewPanel.css('height', '500px');
        this.$traitAddGridData.refresh();
        this.$traitViewGridData.refresh();
        this.$traitAddButton.css('margin-top', '250px');
    }
};

StoreViewModel.prototype.setObservables = function() {

};