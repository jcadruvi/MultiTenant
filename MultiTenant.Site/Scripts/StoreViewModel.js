function StoreViewModel() {
    this.$storeButton = $('#storeButton');
    this.$storeDetail = $('#storeDetail');
    this.$traitAddButton = $('#traitAddButton');
    this.$traitAddPanel = $('#traitAddPanel');
    this.$traitButton = $('#traitButton');
    this.$traitDetail = $('#traitDetail');
    this.$traitPanel = $('#traitPanel')
    this.$traitViewPanel = $('#traitViewPanel');
    
    this.traitAddGridData = null;
    this.traitViewGridData = null;
}

StoreViewModel.prototype.onCollapseAllClick = function() {

};

StoreViewModel.prototype.onExpandAllClick = function() {

};

StoreViewModel.prototype.onStoreClick = function() {
    if (this.$storeButton.val() === '+') {
        this.$storeDetail.show();
        this.$storeButton.val('-');
    } else {
        this.$storeDetail.hide();
        this.$storeButton.val('+'); 
    }
};

StoreViewModel.prototype.onTraitClick = function() {
    if (this.$traitButton.val() == '+') {
        this.$traitDetail.show();
        this.$traitButton.val('-');
        this.$traitPanel.addClass('traitPanelExpanded');
        this.$traitPanel.removeClass('traitPanelCollapsed');
    } else {
        this.$traitDetail.hide();
        this.$traitButton.val('+');
        this.$traitPanel.removeClass('traitPanelExpanded');
        this.$traitPanel.addClass('traitPanelCollapsed');
    }
};

StoreViewModel.prototype.setObservables = function() {
};