function storeViewModelApple(settings) {
    var self = storeViewModelFunc(settings);

    var $programDropDowns = $('.programDropDown');
    var $programValidation = $('#programValidation');
    var $sureyDropDowns = $('.surveyDropDown');

    var baseOnBeforeSubmit = self.onBeforeSubmit;

    self.onBeforeSubmit = function () {
        var i, programFound = false;
        for (i = 0; i < $programDropDowns.length; i++) {
            if ($($programDropDowns[i]).data('kendoComboBox').value()) {
                programFound = true;
            }
        }
        if (programFound) {
            $programValidation.css('display', 'none');
        } else {
            $programValidation.css('display', 'block');
            return false;
        }
        $programValidation.css('display', 'none');
        return baseOnBeforeSubmit();
    }

    return self;
}