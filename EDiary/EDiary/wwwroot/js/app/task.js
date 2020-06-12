var Task = Task || {};

Task.Mapping = {
    'Notes': {
        create: function (options) {
            return new Task.Note(options.data);
        }
    }
};

Task.Note = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

Task.TaskViewModel = function () {
    var self = this;

    self.Notes = ko.observableArray();

    self.Init = function () {
        ko.mapping.fromJS(Task.TaskModel, {}, self);
        ko.mapping.fromJS(Task.TaskModel.TaskNotes, Task.Mapping.Notes, self.Notes);
    };

    self.FormatMaxAssessment = function (assessment) {
        return assessment() + ' Points';
    }

    self.FormatCreatedOnDate = function (createdOn) {
        var localDate = moment.utc(createdOn()).local().format(DateTimeFormat.DateFormat.LongMonthDateFormat);
        return "Created On: " + localDate;
    }

    self.GetTaskNotes = function () {
        var data = {
            taskId: self.TaskId()
        };

        $.ajax({
            url: Task.GetTaskNotesUrl,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.TaskNotes, Task.Mapping.Notes, self.Notes);
            }
        });
    };

    self.Init();
};

Task.Init = function () {
    const viewModel = new Task.TaskViewModel();
    ko.applyBindings(viewModel, $(Task.ContainerId)[0]);
};