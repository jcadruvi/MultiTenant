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

StoreViewModel.prototype.doCollapseStore = function () {
    this.$storeDetail.hide();
    this.$storeButton.val('+');
};

StoreViewModel.prototype.doCollapseTrait = function() {
    this.$traitDetail.hide();
    this.$traitButton.val('+');
    this.$traitPanel.removeClass('traitPanelExpanded');
    this.$traitPanel.addClass('traitPanelCollapsed');
};

StoreViewModel.prototype.doExpandStore = function() {
    this.$storeDetail.show();
    this.$storeButton.val('-');
};

StoreViewModel.prototype.doExpandTrait = function() {
    this.$traitDetail.show();
    this.$traitButton.val('-');
    this.$traitPanel.addClass('traitPanelExpanded');
    this.$traitPanel.removeClass('traitPanelCollapsed');
};
 
StoreViewModel.prototype.onCollapseAllClick = function() {
    this.doCollapseStore();
    this.doCollapseTrait();
};

StoreViewModel.prototype.onExpandAllClick = function() {
    this.doExpandStore();
    this.doExpandTrait();
};

StoreViewModel.prototype.onStoreClick = function() {
    if (this.$storeButton.val() === '+') {
        this.doExpandStore();
    } else {
        this.doCollapseStore();
    }
};

StoreViewModel.prototype.onTraitClick = function() {
    if (this.$traitButton.val() == '+') {
        this.doExpandTrait();
    } else {
        this.doCollapseTrait();
    }
};

StoreViewModel.prototype.setObservables = function() {
};