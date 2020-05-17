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
    'ignore': ["Clear", "OnlyNumber"]
};

ToDoItemsList.PagerMapping = {
    'ignore': ["Load", "Pages", "StartRecord", "EndRecord", "Init"]
};

ToDoItemsList.ToDoViewModel = function () {
    var self = this;

    //self.Pager = new PagerViewModel();
    self.Filter = null;
    self.ToDos = ko.observableArray();
    self.Loading = ko.observable(false);
    self.ShowFilter = ko.observable(true);
    self.Statuses = ko.observableArray([]);
    self.OrderReferences = ko.observableArray([]);
    self.SelectedFilters = ko.observableArray();
    self.TagsIsFilled = ko.observable(true);
    self.FilterErrors = null;


    self.Init = function () {
        ko.mapping.fromJS(ToDoItemsList.ToDos, ToDoItemsList.Mapping.ToDos, self.ToDos);

        //self.Filter = new YounifiAdminOrdersList.FilterViewModel(YounifiAdminOrdersList.Filter, false);
        //self.AppliedFilter = new YounifiAdminOrdersList.FilterViewModel(YounifiAdminOrdersList.Filter);
        //ko.mapping.fromJS(YounifiAdminOrdersList.Pager, {}, self.Pager);
        //self.DefaultFilter = new YounifiAdminOrdersList.FilterViewModel(YounifiAdminOrdersList.Filter, true);
        //ko.mapping.fromJS(YounifiAdminOrdersList.Statuses, {}, self.Statuses);
        //ko.mapping.fromJS(YounifiAdminOrdersList.Councils, {}, self.Councils);
        //ko.mapping.fromJS(YounifiAdminOrdersList.OrderReferences, {}, self.OrderReferences);

        //self.Pager.Load = self.Load;
    };

    //self.Load = function (fromApply) {
    //    var data = {
    //        filter: fromApply
    //            ? ko.mapping.toJS(self.Filter, YounifiAdminOrdersList.FilterMapping)
    //            : ko.mapping.toJS(self.AppliedFilter, YounifiAdminOrdersList.FilterMapping),
    //        pager: ko.mapping.toJS(self.Pager, YounifiAdminOrdersList.PagerMapping)
    //    };

    //    $.ajax({
    //        url: YounifiAdminOrdersList.GetOrdersUrl,
    //        type: "POST",
    //        dataType: "json",
    //        data: data,
    //        busy: self.Loading
    //    }).done(function (result) {
    //        if (result && result.success) {
    //            ko.mapping.fromJS(result.data.orders, YounifiAdminOrdersList.Mapping.Orders, self.Orders);
    //            ko.mapping.fromJS(result.data.pager, {}, self.Pager);

    //            history.replaceState({}, null, result.redirect);

    //            if (fromApply || !self.TagsIsFilled()) {
    //                self.FillFilterTags();
    //                self.AppliedFilter = new YounifiAdminOrdersList.FilterViewModel(self.Filter, false);
    //                self.TagsIsFilled(true);
    //                self.ShowFilter(self.SelectedFilters().length === 0);
    //            }

    //        } else if (result && result.AllErrors) {
    //            notify.fail(result.AllErrors, true);
    //        }
    //    });
    //};

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

//YounifiAdminOrdersList.FilterViewModel = function (filter, isDefault) {
//    var self = this;
//    self.StatusId = ko.observable(isDefault ? 0 : filter.StatusId);
//    self.PersonFirstName = ko.observable(isDefault ? null : filter.PersonFirstName);
//    self.PersonLastName = ko.observable(isDefault ? null : filter.PersonLastName);
//    self.CouncilName = ko.observable(isDefault ? null : filter.CouncilName);
//    self.Provider = ko.observable(isDefault ? null : filter.Provider);
//    self.Postcode = ko.observable(isDefault ? null : filter.Postcode);
//    self.StoreId = ko.observable(isDefault ? null : filter.CouncilId);
//    self.OrderNumber = ko.observable(isDefault ? null : filter.OrderNumber).extend({ max: YounifiAdminOrdersList.OrderNumberMaxValue });
//    self.SeeFromDate = ko.observable();
//    self.DateFrom = ko.observable(isDefault ? null : filter.DateFrom);
//    self.DateTo = ko.observable(isDefault ? null : filter.DateTo);
//    self.MinFromDate = ko.observable();
//    self.OrderReferenceKey = ko.observable(isDefault ? YounifiAdminOrdersList.OrderReferenceKeyDefaultValue : filter.OrderReferenceKey);
//    self.OrderReferenceValue = ko.observable(isDefault ? null : filter.OrderReferenceValue);
//    self.OrderReferenceName = ko.observable(YounifiAdminOrdersList.OrderReferenceNameDefaultValue);

//    self.OnlyNumber = function () {
//        if ((self.OrderReferenceKey() == 50 || self.OrderReferenceKey() == 40)) {
//            return keyPressIntNumbersOnly;
//        }
//    };

//    self.OrderReferenceKey.subscribe(function () {
//        self.OrderReferenceValue(null);
//    });

//    self.Clear = function () {
//        self.StatusId(null);
//        self.PersonFirstName(null);
//        self.PersonLastName(null);
//        self.CouncilName(null);
//        self.Provider(null);
//        self.Postcode(null);
//        self.DateFrom(null);
//        self.DateTo(null);
//        self.StoreId(null);
//        self.OrderReferenceKey(YounifiAdminOrdersList.OrderReferenceKeyDefaultValue);
//        self.OrderReferenceValue(null);
//        self.OrderReferenceName(YounifiAdminOrdersList.OrderReferenceNameDefaultValue);
//    };
//};

ToDoItemsList.Init = function () {
    const viewModel = new ToDoItemsList.ToDoViewModel();
    ko.applyBindings(viewModel, $(ToDoItemsList.ContainerId)[0]);
};