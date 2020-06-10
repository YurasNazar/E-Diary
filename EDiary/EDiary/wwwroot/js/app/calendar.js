var CalendarDayItemsList = CalendarDayItemsList || {};

CalendarDayItemsList.Mapping = {
    'DayItem': {
        create: function (options) {
            return new CalendarDayItemsList.DayItem(options.data);
        }
    }
};

CalendarDayItemsList.DayItem = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);

    var date = self.Date();
    var dayNumber = moment(date).format(DateTimeFormat.DateFormat.DayNumber);
    var monthNameShort = moment(date).format(DateTimeFormat.DateFormat.MonthNameShort);
    var dayOfWeek = moment(date).format(DateTimeFormat.DateFormat.DayOfWeek);

    self.DayNumber = ko.observable(dayNumber);
    self.MonthNameShort = ko.observable(monthNameShort);
    self.DayOfWeek = ko.observable(dayOfWeek);
};

CalendarDayItemsList.CalendarDayItemsListViewModel = function () {
    var self = this;

    self.CalendarDayItems = ko.observableArray();
    self.FormattedCalendarDay = ko.observable();
    self.CalendarDay = ko.observable();
    self.Loading = ko.observable(false);

    self.Init = function () {
        self.CalendarDay(moment().format(DateTimeFormat.DateFormat.Default));
    };

    self.Load = function () {
        self.Loading(true);
        var data = {
            calendarDay: moment(self.CalendarDay()).format()
        };

        $.ajax({
            url: CalendarDayItemsList.GetCalendarDayItemsUrl,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.CalendarEvents, CalendarDayItemsList.Mapping.DayItem, self.CalendarDayItems);
                scrollToTop();
                self.Loading(false);
            }
        });
    };

    self.CalendarDay.subscribe(() => {
        self.FormattedCalendarDay(moment(self.CalendarDay()).format("LL"));
        self.Load();
    });

    self.Init();
};

CalendarDayItemsList.Init = function () {
    const viewModel = new CalendarDayItemsList.CalendarDayItemsListViewModel();
    ko.applyBindings(viewModel, $(CalendarDayItemsList.ContainerId)[0]);
};
