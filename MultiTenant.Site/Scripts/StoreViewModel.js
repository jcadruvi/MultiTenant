function StoreViewModel() {
    this.$storeButton = $('#storeButton');
    this.$storeDetail = $('#storeDetail');
}

StoreViewModel.prototype.onStoreClick = function() {
    if (this.$storeButton.val() === '+') {
        this.$storeDetail.show();
        this.$storeButton.val('-');
    } else {
        this.$storeDetail.hide();
        this.$storeButton.val('+');
    }
};

StoreViewModel.prototype.setObservables = function() {

};