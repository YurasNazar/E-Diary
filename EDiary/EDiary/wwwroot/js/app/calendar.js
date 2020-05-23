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
};

CalendarDayItemsList.CalendarDayItemsListViewModel = function () {
    var self = this;

    self.CalendarDayItems = ko.observableArray();
    self.CalendarDay = ko.observable();

    self.Init = function () {
        self.CalendarDay(moment().format(DateTimeFormat.DateFormat.Default));
    };

    self.Load = function () {
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
                ko.mapping.fromJS(result.data.CalendarDayItems, CalendarDayItemsList.Mapping.DayItem, self.CalendarDayItems);
                scrollToTop();
            }
        });
    };

    self.CalendarDay.subscribe(() => {
        self.Load();
    });

    self.Init();
};

CalendarDayItemsList.Init = function () {
    const viewModel = new CalendarDayItemsList.CalendarDayItemsListViewModel();
    ko.applyBindings(viewModel, $(CalendarDayItemsList.ContainerId)[0]);
};
