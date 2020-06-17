var Task = Task || {};

Task.Mapping = {
    'Notes': {
        create: function (options) {
            return new Task.Note(options.data);
        }
    }
};

Task.Mapping = {
    'Files': {
        create: function (options) {
            return new Task.File(options.data);
        }
    }
};

Task.Note = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

Task.File = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

Task.TaskViewModel = function () {
    var self = this;

    self.Notes = ko.observableArray();
    self.TaskNote = ko.observable();
    self.Files = ko.observableArray();
    self.TaskAssessment = ko.observable();
    self.AssessmentInputDisabled = ko.observable();
    self.MarkAsCompleteButtonVisible = ko.observable();
    self.EvaluateButtonVisible = ko.observable();

    self.Jopa = ko.observable(true);

    self.Init = function () {
        debugger;
        ko.mapping.fromJS(Task.TaskModel, {}, self);
        ko.mapping.fromJS(Task.TaskModel.TaskNotes, Task.Mapping.Notes, self.Notes);
        ko.mapping.fromJS(Task.TaskModel.TaskFiles, Task.Mapping.Files, self.Files);
        self.AssessmentInputDisabled(self.StatusId() == Constants.Numbers.TaskStatus.Assessed ? true : false);
        self.EvaluateButtonVisible(self.StatusId() == Constants.Numbers.TaskStatus.Completed ? true : false);
        self.MarkAsCompleteButtonVisible(self.StatusId() == Constants.Numbers.TaskStatus.Proposed ? true : false);
    };

    self.FormatMaxAssessment = function (assessment) {
        return assessment() + Constants.Strings.Points;
    };

    self.FormatCreatedOnDate = function (createdOn) {
        var localDate = moment.utc(createdOn()).local().format(DateTimeFormat.DateFormat.LongMonthDateFormat);
        return Constants.Strings.CreatedOn + localDate;
    };

    self.FormatNoteDate = function (noteDate) {
        var localNoteDate = moment.utc(noteDate()).local().format(DateTimeFormat.DateFormat.ShortDateTime);
        return localNoteDate;
    };

    self.FormatNoteDate = function (noteDate) {
        var localNoteDate = moment.utc(noteDate()).local().format(DateTimeFormat.DateFormat.ShortDateTime);
        return localNoteDate;
    };

    self.FileClick = function () {
        $(Task.FileUploaderId).trigger(Actions.Type.Click);
    };

    self.FilesSelect = function (element, event) {
        var files = event.target.files;
        for (var i = 0; i < files.length; i++)
        {
            self.Files.push(new FileModel(files[i].name, files[i].type));
        }
    };

    self.Reload = function () {
        window.location.href = "https://localhost:44360/Task/GetTask/" + self.TaskId();
    };

    self.Evaluate = function () {
        var data = {
            taskId: self.TaskId(),
            taskAssessment: self.TaskAssessment()
        };

        $.ajax({
            url: Task.Evaluate,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                self.Reload();
            }
        });
    };

    self.MarkAsComplete = function () {
        $("#file-upload-input").trigger("click");
    };

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

    self.PostNote = function () {
        var data = {
            taskId: self.TaskId(),
            note: self.TaskNote()
        };

        $.ajax({
            url: Task.CreateTaskNote,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                self.TaskNote("");
                self.GetTaskNotes();
            }
        });
    };

    self.Init();
};

Task.Init = function () {
    const viewModel = new Task.TaskViewModel();
    ko.applyBindings(viewModel, $(Task.ContainerId)[0]);
};