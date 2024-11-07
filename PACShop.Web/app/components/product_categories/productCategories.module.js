/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('pacshop.product_categories', ['pacshop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];


    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('product_categories', {
            url: "/product_categories",
            //parent: 'base',
            templateUrl: "/app/components/product_categories/productCategoryListView.html",
                controller: "productCategoryListController"
            //})
            //.state('product_add', {
            //    url: "/product_add",
            //    //parent: 'base',
            //    templateUrl: "/app/components/products/productAddView.html",
            //    controller: "productAddController"
            });


    }
})();