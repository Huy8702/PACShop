(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'Hoạt động';
            else
                return 'Ngưng hoạt động';
        }
    });
})(angular.module('pacshop.common'));