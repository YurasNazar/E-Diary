var DateTimeFormat = DateTimeFormat || {};
var Constants = Constants || {};
var Actions = Actions || {};

var scrollToTop = function () {
    $(window).scrollTop(0);
};

DateTimeFormat.DateFormat = {
    LongDate: "dd MMMM yyyy",
    Default: "MM/DD/yyyy",
    DayNumber: "DD",
    MonthNameShort: "MMM",
    DayOfWeek: "dddd",
    LongMonthDateFormat: "DD MMMM YYYY HH:mm",
    ShortDateTime: "DD MMM HH:mm"
};

Constants.Strings = {
    Points: " Points",
    CreatedOn: "CreatedOn: ",
    TaskStatus: {
        Completed: "Completed"
    }
};

Constants.Numbers = {
    TaskStatus: {
        Proposed: 0,
        Completed: 1,
        Assessed: 2
    }
};

Actions.Type = {
    Click: "click",
};

var FileModel = function (name, type) {
    this.Name = name;
    this.Type = type;
};

ko.bindingHandlers.DatePicker = {
    init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        $(element).datepicker({
            todayHighlight: true,
            orientation: "bottom left",
            format: "mm/dd/yyyy",
        });
    },
    update: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
        // This will be called once when the binding is first applied to an element,
        // and again whenever any observables/computeds that are accessed change
        // Update the DOM element based on the supplied values here.
    }
};