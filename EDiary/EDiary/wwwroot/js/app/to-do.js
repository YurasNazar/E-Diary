var ToDoItemsList = ToDoItemsList || {};

ToDoItemsList.Mapping = {
    'ToDos': {
        create: function (options) {
            return new ToDoItemsList.ToDo(options.data);
        }
    }
};

ToDoItemsList.ToDo = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

ToDoItemsList.FilterMapping = {
    'ignore': ["Clear"]
};

ToDoItemsList.PagerMapping = {
    'ignore': ["Load", "Pages", "StartRecord", "EndRecord", "Init"]
};

ToDoItemsList.ToDoViewModel = function () {
    var self = this;

    self.Pager = new PagerViewModel();
    self.Filter = null;
    self.ToDos = ko.observableArray();
    self.Loading = ko.observable(false);
    self.ShowFilter = ko.observable(true);
    self.Statuses = ko.observableArray([]);
    self.SelectedFilters = ko.observableArray();
    self.TagsIsFilled = ko.observable(true);
    self.FilterErrors = null;


    self.Init = function () {
        debugger;
        ko.mapping.fromJS(ToDoItemsList.ToDos, ToDoItemsList.Mapping.ToDos, self.ToDos);
        self.Filter = new ToDoItemsList.FilterViewModel(ToDoItemsList.Filter, true);
        ko.mapping.fromJS(ToDoItemsList.Pager, {}, self.Pager);
        ko.mapping.fromJS(ToDoItemsList.Statuses, {}, self.Statuses);

        self.Pager.Load = self.Load;
    };

    self.Load = function () {
        var data = {
            filter: ko.mapping.toJS(self.Filter, ToDoItemsList.FilterMapping),
            pager: ko.mapping.toJS(self.Pager, ToDoItemsList.PagerMapping)
        };

        data.filter.Deadline = moment(data.filter.Deadline).format();

        $.ajax({
            url: ToDoItemsList.GetToDosUrl,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.ToDos, ToDoItemsList.Mapping.ToDos, self.ToDos);
                ko.mapping.fromJS(result.data.Pager, {}, self.Pager);
                scrollToTop();
            }
        });
    };

    self.FormatToLocalDateTime = function (date) {
        debugger;
        var localDate = moment.utc(date).local().format('YYYY-MM-DD HH:mm:ss');
        return localDate;
    };

    //self.Details = function (model) {
    //    const url = YounifiAdminOrdersList.OrderDetailsUrl + "/" + model.OrderId();
    //    setLocation(url);
    //};

    //self.OrderHistory = function (model) {
    //    const url = YounifiAdminOrdersList.OrderHistoryUrl + "/" + model.OrderId();
    //    setLocation(url);
    //};

    //self.OfferDetails = function (model) {
    //    const url = YounifiAdminOrdersList.OfferDetailsUrl.replace("{id}", model.OfferId());
    //    setLocation(url);
    //};

    self.ApplyFilter = function () {
        self.Pager.PageIndex(0);
        self.Load();
    };

    self.ClearFilter = function () {
        self.Pager.PageIndex(0);
        self.Filter.Clear();
        self.Load();
    };

    self.Init();
};

ToDoItemsList.FilterViewModel = function () {
    var self = this;

    self.StatusId = ko.observable(null);
    self.Subjects = ko.observable(null);
    self.Name = ko.observable(null);
    self.Deadline = ko.observable(null);

    self.Clear = function () {
        self.StatusId(null);
        self.Name(null);
        self.Subjects(null);
        self.Deadline(null);
    };
};

ToDoItemsList.Init = function () {
    const viewModel = new ToDoItemsList.ToDoViewModel();
    ko.applyBindings(viewModel, $(ToDoItemsList.ContainerId)[0]);
};