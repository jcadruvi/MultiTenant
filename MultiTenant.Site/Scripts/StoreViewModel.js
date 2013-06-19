function storeViewModel(settings) {
    var self = {};

    var $programButton = $('#programButton');
    var $programDetail = $('#programDetail');
    var $storeButton = $('#storeButton');
    var $storeDetail = $('#storeDetail');
    var $traitButton = $('#traitButton');
    var $traitDetail = $('#traitDetail');
    var $traitPanel = $('#traitPanel');
    var $traitValidation = $('#traitValidation');

    var deleteStoreUrl = null;
    var deleteTraitUrl = null;
    var getStoreUrl = null;
    var programFeature = null;

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
        $programDetail.hide();
        $programButton.val('+');
    };

    var doCollapseStore = function() {
        $storeDetail.hide();
        $storeButton.val('+');
    };

    var doCollapseTrait = function() {
        $traitDetail.hide();
        $traitButton.val('+');
        $traitPanel.removeClass('traitPanelExpanded');
        $traitPanel.addClass('traitPanelCollapsed');
    };

    var doExpandProgram = function() {
        $programDetail.show();
        $programButton.val('-');
    };

    var doExpandStore = function() {
        $storeDetail.show();
        $storeButton.val('-');
    };

    var doExpandTrait = function() {
        $traitDetail.show();
        $traitButton.val('-');
        $traitPanel.addClass('traitPanelExpanded');
        $traitPanel.removeClass('traitPanelCollapsed');
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

    self.onBeforeSubmit = function () {
        if (self.traitViewGridData.dataSource.data().length == 0) {
            $traitValidation.css('display', 'block');
            return false;
        } else {
            $traitValidation.css('display', 'none');
        }
        return $('form').validate().form();
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
        if ($programButton.val() === '+') {
            doExpandProgram();
        } else {
            doCollapseProgram();
        }
    };

    self.onStoreClick = function() {
        if ($storeButton.val() === '+') {
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
        if ($traitButton.val() == '+') {
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