var DateTimeFormat = DateTimeFormat || {};
var scrollToTop = function () {
    $(window).scrollTop(0);
};

DateTimeFormat.DateFormat = {
    LongDate: "dd MMMM yyyy",
    Default: "MM/DD/yyyy",
    DayNumber: "DD",
    MonthNameShort: "MMM",
    DayOfWeek: "dddd"
};

ko.bindingHandlers.DatePicker = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        debugger;
        $(element).datepicker({
            todayHighlight: true,
            orientation: "bottom left",
            format: "mm/dd/yyyy",
        });
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        debugger;
        // This will be called once when the binding is first applied to an element,
        // and again whenever any observables/computeds that are accessed change
        // Update the DOM element based on the supplied values here.
    }
};