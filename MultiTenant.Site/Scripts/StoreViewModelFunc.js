function StoreViewModelFunc(settings) {
    var self = {};
    var deleteStoreUrl = null;
    var deleteTraitUrl = null;
    var getStoreUrl = null;
    var programFeature = null;

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
        deleteStoreUrl = settings.deleteStoreUrl;
        deleteTraitUrl = settings.deleteTraitUrl;
        getStoreUrl = settings.getStoreUrl;
        programFeature = settings.programFeature;
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

    var getSelectedId = function(gridData) {
        var dataItem;
        if (!gridData) {
            return null;
        }
        dataItem = gridData.dataItem(gridData.select());
        if (!dataItem) {
            return null;
        }
        return dataItem.Id;
    };

    self.onCollapseAllClick = function() {
        doCollapseStore();
        doCollapseTrait();
        if (programFeature) {
            doCollapseProgram();
        }
    };

    self.onDeleteClick = function() {
        var id = getSelectedId(self.storeGridData);
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
            url: deleteStoreUrl + '?id=' + id
        });
    };

    self.onDeleteTraitClick = function () {
        var id = getSelectedId(self.traitViewGridData);

        $.ajax({
            success: function () {
                self.traitViewGridData.dataSource.read();
            },
            type: 'DELETE',
            url: deleteTraitUrl + '?id=' + id
        });
    };

    self.onExpandAllClick = function() {
        doExpandStore();
        doExpandTrait();
        if (programFeature) {
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

        postData.ID = getSelectedId(self.storeGridData);
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
            url: getStoreUrl
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

    return self;
}