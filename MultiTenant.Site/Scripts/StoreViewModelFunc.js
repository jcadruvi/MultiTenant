function StoreViewModel(settings) {
    var self = this;
    
    self.$programButton = $('#programButton');
    self.$programDetail = $('#programDetail');
    self.$storeButton = $('#storeButton');
    self.$storeDetail = $('#storeDetail');
    self.$traitAddButton = $('#traitAddButton');
    self.$traitAddPanel = $('#traitAddPanel');
    self.$traitButton = $('#traitButton');
    self.$traitDetail = $('#traitDetail');
    self.$traitPanel = $('#traitPanel');
    self.$traitViewPanel = $('#traitViewPanel');

    self.city = null;
    self.id = null;
    self.name = null;
    self.number = null;
    self.state = null;
    self.storeGridData = null;
    self.traitAddGridData = null;
    self.traitViewGridData = null;

    if (settings) {
        self.deleteStoreUrl = settings.deleteStoreUrl;
        self.getStoreUrl = settings.getStoreUrl;
        self.programFeature = settings.programFeature;
    }

    var doCollapseProgram = function() {
        self.$programDetail.hide();
        self.$programButton.val('+');
    };

    var doCollapseStore = function() {
        self.$storeDetail.hide();
        self.$storeButton.val('+');
    };

    var doCollapseTrait = function() {
        self.$traitDetail.hide();
        self.$traitButton.val('+');
        self.$traitPanel.removeClass('traitPanelExpanded');
        self.$traitPanel.addClass('traitPanelCollapsed');
    };

    var doExpandProgram = function() {
        self.$programDetail.show();
        self.$programButton.val('-');
    };

    var doExpandStore = function() {
        self.$storeDetail.show();
        self.$storeButton.val('-');
    };

    var doExpandTrait = function() {
        self.$traitDetail.show();
        self.$traitButton.val('-');
        self.$traitPanel.addClass('traitPanelExpanded');
        self.$traitPanel.removeClass('traitPanelCollapsed');
    };

    var getSelectedStoreId = function() {
        var dataItem;
        if (!self.storeGridData) {
            return null;
        }
        dataItem = self.storeGridData.dataItem(self.storeGridData.select());
        if (!dataItem) {
            return null;
        }
        return dataItem.Id;
    };

    self.onCollapseAllClick = function() {
        doCollapseStore();
        doCollapseTrait();
        if (self.programFeature) {
            doCollapseProgram();
        }
    };

    self.onDeleteClick = function() {
        var id = getSelectedStoreId();
        $.ajax({
            success: function () {
                self.storeGridData.dataSource.read();
                self.city(null);
                self.id(null);
                self.name(null);
                self.number(null);
                self.state(null);
                self.traitViewGridData.dataSource.data([]);
            },
            type: 'DELETE',
            url: self.deleteStoreUrl + '?id=' + id
        });
    };

    self.onExpandAllClick = function() {
        doExpandStore();
        doExpandTrait();
        if (self.programFeature) {
            doExpandProgram();
        }
    };

    self.onProgramClick = function() {
        if (self.$programButton.val() === '+') {
            doExpandProgram();
        } else {
            doCollapseProgram();
        }
    };

    self.onStoreClick = function() {
        if (self.$storeButton.val() === '+') {
            doExpandStore();
        } else {
            doCollapseStore();
        }
    };

    self.onStoreSuccess = function() {
        self.storeGridData.dataSource.read();
    };

    self.onStoreGridChanged = function() {
        var postData = {};

        postData.ID = getSelectedStoreId();
        $.ajax({
            data: postData,
            dataType: 'json',
            success: function (result) {
                self.city(result.City);
                self.id(result.Id);
                self.name(result.Name);
                self.number(result.Number);
                self.state(result.State);
            },
            type: 'GET',
            url: self.getStoreUrl
        });
    };

    self.onTraitClick = function() {
        if (self.$traitButton.val() == '+') {
            doExpandTrait();
        } else {
            doCollapseTrait();
        }
    };

    self.setObservables = function() {
        self.city = ko.observable();
        self.id = ko.observable();
        self.name = ko.observable();
        self.number = ko.observable();
        self.state = ko.observable();
    };
}