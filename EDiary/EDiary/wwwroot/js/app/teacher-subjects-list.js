var TeacherSubjectListViewModel = TeacherSubjectListViewModel || {};

TeacherSubjectListViewModel.Mapping = {
    'Subject': {
        create: function (options) {
            return new TeacherSubjectListViewModel.Subject(options.data);
        }
    }
};

TeacherSubjectListViewModel.Subject = function (data) {
    var self = this;

    ko.mapping.fromJS(data, {}, self);
};

TeacherSubjectListViewModel.ViewModel = function () {
    var self = this;

    self.Subjects = ko.observableArray();
    self.CreateSubjectModel = null;

    self.Init = function () {
        self.CreateSubjectModel = new TeacherSubjectListViewModel.CreateSubjectViewModel();
        ko.mapping.fromJS(TeacherSubjectListViewModel.Subjects, TeacherSubjectListViewModel.Mapping.Subject, self.Subjects);
    };

    self.Load = function () {
        $.ajax({
            url: TeacherSubjectListViewModel.GetTheacherSubjectList,
            type: "POST",
            dataType: "json",
        }).done(function (result) {
            if (result && result.success) {
                ko.mapping.fromJS(result.data.Subjects, TeacherSubjectListViewModel.Mapping.Subject, self.Subjects);
            }
        });
    };

    self.CreateSubject = function () {
        var data = {
            subject: ko.mapping.toJS(self.CreateSubjectModel, {}),
        };

        $.ajax({
            url: TeacherSubjectListViewModel.CreateSubjectLink,
            type: "POST",
            dataType: "json",
            data: data,
        }).done(function (result) {
            if (result && result.success) {
                self.Load();                
            }
        });
    };

    self.GetSubjectContainerBackground = function (index) {
        return index() % 2 == 0 ? "bg-blue-gradient" : "";
    };

    self.OpenCreateSubjectModal = function () {
        var template = $($(TeacherSubjectListViewModel.BootBoxContainerId).html());
        ko.applyBindings(self, template.get(0));

        template.show();

        bootbox.confirm({
            title: "Create Subject",
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
                    self.CreateSubject();
                }
                else return true;
            }
        });
    };

    self.Init();
};

TeacherSubjectListViewModel.CreateSubjectViewModel = function () {
    var self = this;

    self.Name = ko.observable(null);
    self.Description = ko.observable(null);
    self.JoinCode = ko.observable(null)

    self.Clear = function () {
        self.Name(null);
        self.Description(null);
        self.JoinCode(null);
    };
};

TeacherSubjectListViewModel.Init = function () {
    const listViewModel = new TeacherSubjectListViewModel.ViewModel();
    ko.applyBindings(listViewModel, $(TeacherSubjectListViewModel.ContainerId)[0]);
};
