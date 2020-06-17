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
    self.CreateAppointmentModel = null;

    self.Init = function () {
        self.CreateAppointmentModel = new CalendarDayItemsList.CreateAppointmentViewModel();
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

    self.CreateAppointment = function () {
        debugger;
        var data = {
            appointment: ko.mapping.toJS(self.CreateAppointmentModel, {}),
        };

        data.appointment.AppointmentDate = moment(data.appointment.AppointmentDate).format()

        $.ajax({
            url: CalendarDayItemsList.CreateAppointmentUrl,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                self.Load();
            }
        });
    };


    self.OpenCreateAppointmentModal = function () {
        var template = $($(CalendarDayItemsList.BootBoxContainerId).html());
        ko.applyBindings(self, template.get(0));

        var appointmentDate = template.find(CalendarDayItemsList.AppointmentDateId);
        var appointmentDateFrom = template.find(CalendarDayItemsList.AppointmentDateFromId);
        var appointmentDateTo = template.find(CalendarDayItemsList.AppointmentDateToId);

        debugger;
        Functions.ApplyDatePicker(appointmentDate);
        Functions.ApplyTimePicker(appointmentDateFrom);
        Functions.ApplyTimePicker(appointmentDateTo);

        template.show();

        bootbox.confirm({
            title: "Create Appointment",
            message: template,
            buttons: {
                confirm: {
                    label: 'Create'
                },
                cancel: {
                    label: 'Cancel',
                }
            },
            callback: function (result) {
                if (result) {
                    self.CreateAppointment();
                }
                else return true;
            }
        });
    };

    self.CalendarDay.subscribe(() => {
        self.FormattedCalendarDay(moment(self.CalendarDay()).format("LL"));
        self.Load();
    });

    self.Init();
};

CalendarDayItemsList.CreateAppointmentViewModel = function () {
    var self = this;

    self.Theme = ko.observable(null);
    self.Description = ko.observable(null);
    self.SubjectName = ko.observable(null);
    self.Location = ko.observable(null);
    self.AppointmentDate = ko.observable(null);
    self.AppointmentDateFrom = ko.observable(null);
    self.AppointmentDateTo = ko.observable(null);

    self.Clear = function () {
        self.Theme(null);
        self.Description(null);
        self.SubjectName(null);
        self.Location(null);
        self.AppointmentDate(null);
        self.AppointmentDateFrom(null);
        self.AppointmentDateTo(null);
    };
};

CalendarDayItemsList.Init = function () {
    const viewModel = new CalendarDayItemsList.CalendarDayItemsListViewModel();
    ko.applyBindings(viewModel, $(CalendarDayItemsList.ContainerId)[0]);
};
