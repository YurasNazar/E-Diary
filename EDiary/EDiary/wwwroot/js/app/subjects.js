var SubjectsManageViewModel = SubjectsManageViewModel || {};

SubjectsManageViewModel.Mapping = {
    'Subject': {
        create: function (options) {
            return new SubjectsManageViewModel.Subject(options.data);
        }
    }
};

SubjectsManageViewModel.Mapping = {
    'Post': {
        create: function (options) {
            return new SubjectsManageViewModel.Post(options.data);
        }
    }
};

SubjectsManageViewModel.Mapping = {
    'People': {
        create: function (options) {
            return new SubjectsManageViewModel.People(options.data);
        }
    }
};

SubjectsManageViewModel.Mapping = {
    'Teacher': {
        create: function (options) {
            return new SubjectsManageViewModel.Teacher(options.data);
        }
    }
};

SubjectsManageViewModel.Subject = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

SubjectsManageViewModel.Post = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

SubjectsManageViewModel.People = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

SubjectsManageViewModel.Teacher = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

SubjectsManageViewModel.ViewModel = function () {
    var self = this;

    self.PostDescription = ko.observable(null);
    self.SubjectHeader = ko.observable(0);
    self.Subjects = ko.observableArray();
    self.SubjectPosts = ko.observableArray();
    self.SubjectPeople = ko.observableArray();
    self.SubjectTeachers = ko.observableArray();
    self.SelectedSubjectId = ko.observable();
    self.JoinSubjectModel = null;
    self.CreateTaskModel = null;

    self.Init = function () {
        self.JoinSubjectModel = new SubjectsManageViewModel.JoinSubjectViewModel();
        self.CreateTaskModel = new SubjectsManageViewModel.CreateTaskViewModel();
        ko.mapping.fromJS(SubjectsManageViewModel.SubjectList, SubjectsManageViewModel.Mapping.Subject, self.Subjects);
        ko.mapping.fromJS(SubjectsManageViewModel.InitSubjectId, {}, self.SelectedSubjectId);
    };

    self.GetSubjectInfo = function () {
        var data = {
            subjectId: self.SelectedSubjectId()
        };

        $.ajax({
            url: SubjectsManageViewModel.GetSubjectInfo,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.SubjectPosts, SubjectsManageViewModel.Mapping.Post, self.SubjectPosts);
                ko.mapping.fromJS(result.data.SubjectPeople, SubjectsManageViewModel.Mapping.People, self.SubjectPeople);
                ko.mapping.fromJS(result.data.SubjectTeachers, SubjectsManageViewModel.Mapping.Teacher, self.SubjectTeachers);
                scrollToTop();
            }
        });
    };

    self.NewPost = function () {
        var data = {
            description: self.PostDescription(),
            subjectId: self.SelectedSubjectId(),
        };

        $.ajax({
            url: SubjectsManageViewModel.CreatePost,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                self.GetSubjectInfo();
                self.PostDescription(null);
            }
        });
    };

    self.Reload = function () {
        window.location.href = "https://localhost:44360/Subjects/Index/" + self.SelectedSubjectId();
    };

    self.FormatDateCreated = function (dateCreated) {
        return moment(dateCreated).format("DD MMMM");
    };

    self.ChangeSubjectHeaderToCourse = function () {
        self.SubjectHeader(0);
    };

    self.ChangeSubjectHeaderToPeople = function () {
        self.SubjectHeader(1);
    };
    
    self.JoinSubject = function () {
        var data = {
            joinCode: self.JoinSubjectModel.JoinCode(),
        };

        $.ajax({
            url: SubjectsManageViewModel.JoinSubject,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                debugger;
                self.SelectedSubjectId(result.data.subjectId);
                self.Reload();
            }
        });
    };

    self.CreateTask = function () {
        var data = {
            task: ko.mapping.toJS(self.CreateTaskModel, {})
        };

        data.task.Deadline = moment(data.task.Deadline).format();
        data.task.SubjectId = self.SelectedSubjectId();

        $.ajax({
            url: SubjectsManageViewModel.CreateSubjectTask,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                self.CreateTaskModel.Clear();
            }
        });
    };

    self.OpenJoinSubjectModal = function () {
        var template = $($(SubjectsManageViewModel.JoinSubjectId).html());
        ko.applyBindings(self, template.get(0));

        template.show();

        bootbox.confirm({
            title: "Join Subject",
            message: template,
            buttons: {
                confirm: {
                    label: 'Join'
                },
                cancel: {
                    label: 'Cancel',
                }
            },
            callback: function (result) {
                if (result) {
                    self.JoinSubject();
                }
                else return true;
            }
        });
    };

    self.OpenCreateTaskModal = function () {
        var template = $($(SubjectsManageViewModel.CreateTaskId).html());
        ko.applyBindings(self, template.get(0));

        var deadline = template.find(SubjectsManageViewModel.TaskDeadlineId);
        Functions.ApplyDatePicker(deadline);

        template.show();

        bootbox.confirm({
            title: "Create task for subject",
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
                    self.CreateTask();
                }
                else return true;
            }
        });
    };

    self.ChangeSubject = function (subject) {
        self.SelectedSubjectId(subject.Id());
    };

    self.SubjectItemBackground = ko.computed(function () {
        return self.SelectedSubjectId();
    });

    self.SelectedSubjectId.subscribe(function (value) {
        if (value) {
            self.GetSubjectInfo();
        }
        else if (self.Subjects().length) {
            var firstSubjectId = self.Subjects()[0].Id();
            self.SelectedSubjectId(firstSubjectId);
        }
    });

    self.Init();
};

SubjectsManageViewModel.JoinSubjectViewModel = function () {
    var self = this;

    self.JoinCode = ko.observable(null)

    self.Clear = function () {
        self.JoinCode(null);
    };
};

SubjectsManageViewModel.CreateTaskViewModel = function () {
    var self = this;

    self.Name = ko.observable(null);
    self.Description = ko.observable(null);
    self.MaxAssessment = ko.observable(null);
    self.SubjectId = ko.observable(null);
    self.Deadline = ko.observable(null);

    self.Clear = function () {
        self.Name(null);
        self.Description(null);
        self.MaxAssessment(null);
        self.SubjectId(null);
        self.Deadline(null);
    };
};

SubjectsManageViewModel.Init = function () {
    const viewModel = new SubjectsManageViewModel.ViewModel();
    ko.applyBindings(viewModel, $(SubjectsManageViewModel.ContainerId)[0]);
};
