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

        self.Pager.Load = self.Load;
    };

    self.Load = function (fromApply) {
        var data = {
            filter: ko.mapping.toJS(self.Filter, ToDoItemsList.FilterMapping),
            pager: ko.mapping.toJS(self.Pager, ToDoItemsList.PagerMapping)
        };

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

    //self.ChangeFilter = function () {
    //    self.SelectedFilters([]);
    //    self.ShowFilter(true);
    //};

    //self.ApplyFilter = function () {
    //    self.Pager.PageIndex(0);
    //    self.Load(true);
    //};

    //self.ClearFilter = function () {
    //    self.Pager.PageIndex(0);
    //    self.Filter.Clear();
    //    self.AppliedFilter = new YounifiAdminOrdersList.FilterViewModel(YounifiAdminOrdersList.Filter, true);
    //    self.Load();
    //};

    //self.FillFilterTags = function () {
    //    var excludedTags = ["minfromdate", "orderreferencekey", "orderreferencename", "clear"];
    //    $.each(self.Filter,
    //        function (child) {
    //            if ($.inArray(child.toLowerCase(), excludedTags) === -1) {
    //                const obj = self.Filter[child];
    //                if (ko.isObservable(obj) && (obj() || obj() === 0)) {
    //                    const item = self.FormaTagOutput(child, obj);
    //                    self.TagsFilter.CreateTag(item, obj() === self.DefaultFilter[child]());
    //                }
    //            }
    //        });
    //    self.ShowFilter(self.SelectedFilters().length === 0);
    //};

    //self.FormaTagOutput = function (name, value) {
    //    var currentValue = value();

    //    switch (name.toLowerCase()) {
    //        case "statusid":
    //            currentValue = $.grep(self.Statuses(), function (item) {
    //                return item.Key() === currentValue;
    //            })[0].Value();
    //            break;

    //        case "storeid":
    //            currentValue = $.grep(self.Councils(), function (item) {
    //                return item.Key() === currentValue;
    //            })[0].Value();
    //            break;

    //        case "datefrom":
    //            currentValue = "From: " + currentValue;
    //            break;

    //        case "dateto":
    //            currentValue = "To: " + currentValue;
    //            break;

    //        case "provider":
    //            currentValue = "Provider: " + currentValue;
    //            break;

    //        case "postcode":
    //            currentValue = "Postcode: " + currentValue;
    //            break;

    //        case "orderreferencevalue":
    //            currentValue = self.Filter.OrderReferenceName() + " : " + currentValue;
    //            break;
    //    }

    //    const filterItem = { filterName: name, value: currentValue };
    //    self.SelectedFilters().push(filterItem);

    //    return currentValue;
    //};

    //self.UpdateFilter = function (item) {
    //    for (let index = 0; index < self.SelectedFilters().length; index++) {
    //        const filter = self.SelectedFilters()[index];
    //        if (filter.value == item) {
    //            self.SetToDefaultFilterItem(filter.filterName);
    //            self.SelectedFilters.remove(filter);
    //            break;
    //        }
    //    }
    //    self.Pager.PageIndex(0);
    //    self.TagsIsFilled(false);
    //    self.Load(true);
    //};

    //self.SetToDefaultFilterItem = function (itemName) {
    //    const obj = self.Filter[itemName];
    //    obj(self.DefaultFilter[itemName]());
    //};

    //self.TagsFilter = new Tagit({
    //    IsTagHide: self.ShowFilter,
    //    ChangeTagFunction: self.ChangeFilter,
    //    OnRemoveTagFunc: self.UpdateFilter
    //});

    self.Init();
};

ToDoItemsList.FilterViewModel = function (filter, isDefault) {
    var self = this;

    self.StatusId = ko.observable(isDefault ? 0 : filter.StatusId);
    self.Description = ko.observable(isDefault ? null : filter.PersonFirstName);
    self.Deadline = ko.observable(isDefault ? null : filter.DateFrom);

    self.Clear = function () {
        self.StatusId(null);
        self.Description(null);
        self.Deadline(null);
    };
};

ToDoItemsList.Init = function () {
    const viewModel = new ToDoItemsList.ToDoViewModel();
    ko.applyBindings(viewModel, $(ToDoItemsList.ContainerId)[0]);
};