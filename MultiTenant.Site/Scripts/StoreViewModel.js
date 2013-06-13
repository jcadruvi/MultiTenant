function StoreViewModel(settings) {
    this.$programButton = $('#programButton');
    this.$programDetail = $('#programDetail');
    this.$storeButton = $('#storeButton');
    this.$storeDetail = $('#storeDetail');
    this.$traitAddButton = $('#traitAddButton');
    this.$traitAddPanel = $('#traitAddPanel');
    this.$traitButton = $('#traitButton');
    this.$traitDetail = $('#traitDetail');
    this.$traitPanel = $('#traitPanel');
    this.$traitViewPanel = $('#traitViewPanel');

    this.traitAddGridData = null;
    this.traitViewGridData = null;
    
    if (settings) {
        this.programFeature = settings.programFeature;
    }
}

StoreViewModel.prototype.doCollapseProgram = function () {
    this.$programDetail.hide();
    this.$programButton.val('+');
};

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

StoreViewModel.prototype.doExpandProgram = function () {
    this.$programDetail.show();
    this.$programButton.val('-');
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
    if (this.programFeature) {
        this.doCollapseProgram();
    }
};

StoreViewModel.prototype.onExpandAllClick = function() {
    this.doExpandStore();
    this.doExpandTrait();
    if (this.programFeature) {
        this.doExpandProgram();
    }
};

StoreViewModel.prototype.onProgramClick = function () {
    if (this.$programButton.val() === '+') {
        this.doExpandProgram();
    } else {
        this.doCollapseProgram();
    }
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