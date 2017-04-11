var app = angular.module('DocuApp', ['ngRoute', 'LocalStorageModule', 'hljs']);

app.config(function ($routeProvider) {

    $routeProvider.when("/endpoints", {
        controller: "EndpointController",
        templateUrl: "Documentation/Views/endpoints.html"
    });

    $routeProvider.when("/overview", {
        controller: "OverviewController",
        templateUrl: "Documentation/Views/overview.html"
    });

    $routeProvider.when("/authentication", {
        controller: "EndpointController",
        templateUrl: "Documentation/Views/authentication.html"
    });

    $routeProvider.when("/orion-his-endpoints", {
        controller: "Orion-His-Endpoints-Controller",
        templateUrl: "Documentation/Views/orion-his-endpoints.html"
    });

    $routeProvider.when("/hr-endpoints", {
        controller: "HR-Endpoints-Controller",
        templateUrl: "Documentation/Views/hr-endpoints.html"
    });

    $routeProvider.when("/patients", {
        controller: "",
        templateUrl: "Documentation/Views/patient-demographics.html"
    });

    $routeProvider.when("/patientallergies", {
        controller: "",
        templateUrl: "Documentation/Views/patient-allergies.html"
    });

    $routeProvider.when("/patientmedications", {
        controller: "",
        templateUrl: "Documentation/Views/patient-medications.html"
    });

    $routeProvider.when("/patientdiagnosis", {
        controller: "",
        templateUrl: "Documentation/Views/patient-diagnosis.html"
    });

    $routeProvider.when("/patientprevhosps", {
        controller: "",
        templateUrl: "Documentation/Views/patient-prevhosps.html"
    });

    $routeProvider.when("/patientprevsurgeries", {
        controller: "",
        templateUrl: "Documentation/Views/patient-prevsurgeries.html"
    });

    $routeProvider.when("/employees", {
        controller: "",
        templateUrl: "Documentation/Views/employee-info.html"
    });

    $routeProvider.when("/employmentdetails", {
        controller: "",
        templateUrl: "Documentation/Views/employee-employmentdetails.html"
    });

    $routeProvider.when("/employeeprivileges", {
        controller: "",
        templateUrl: "Documentation/Views/employee-privileges.html"
    });

    $routeProvider.when("/employeecareerhistory", {
        controller: "",
        templateUrl: "Documentation/Views/employee-careerhistory.html"
    });

    $routeProvider.when("/employeeeducation", {
        controller: "",
        templateUrl: "Documentation/Views/employee-education.html"
    });

    $routeProvider.otherwise({ redirectTo: "/overview" });
})

app.controller('HR-Endpoints-Controller', function ($scope) {

    $scope.items = [
		{
		    method: 'GET',
		    url: '#/employees',
		    endpoint: '/getEmployees',
		    description: 'Returns the basic information of employees.'
		},
		{
		    method: 'GET',
		    url: '#/employmentdetails',
		    endpoint: '/getEmploymentDetails',
		    description: 'Returns the details of employment of a employees. (ex: hiring date, job grade, employee status, etc.)'
		},
        {
            method: 'GET',
            url: '#/employeeprivileges',
            endpoint: '/getEmployeePrivileges',
            description: 'Returns the specific privileges of employees. (ex: admitting privilege, etc.)'
        },
        {
            method: 'GET',
            url: '#/employeeeducation',
            endpoint: '/getEmployeeEducation',
            description: 'Returns the educational background of employees.'
        },
        {
            method: 'GET',
            url: '#/employeecareerhistory',
            endpoint: '/getEmployeeCareerHistory',
            description: 'Returns the career history of employees.)'
        }
    ];
})

app.controller('Orion-His-Endpoints-Controller', function ($scope) {

    $scope.items = [
		{
		    method: 'Get',
            url:'#/patients',
		    endpoint: '/getPatients',
		    description: 'Returns patient demographics.'
		},
		{
		    method: 'Get',
            url: '#/patientallergies',
		    endpoint: '/getPatientAllergies',
		    description: 'Returns active allergies of patients.'
		},
        {
            method: 'Get',
            url: '#/patientmedications',
            endpoint: '/getPatientMedications',
            description: 'Returns a list of medications given to patients.'
        },
        {
            method: 'Get',
            url:'#/patientdiagnosis',
            endpoint: '/getPatientDiagnosis',
            description: 'Returns a list of patient diagnosis.'
        },
        {
            method: 'Get',
            url: '#/patientprevhosps',
            endpoint: '/getPatientPreviousHospitalizations',
            description: 'Returns a record of previous hospitalizations of patients.'
        },
        {
            method: 'Get',
            url: '#/patientprevsurgeries',
            endpoint: '/getPatientPreviousSurgeries',
            description: 'Returns the record of patients previous surgeries.'
        }
    ];
})

app.filter('searchFor', function () {

    // All filters must return a function. The first parameter
    // is the data that is to be filtered, and the second is an
    // argument that may be passed with a colon (searchFor:searchString)

    return function (arr, searchString) {

        if (!searchString) {
            return arr;
        }

        var result = [];

        searchString = searchString.toLowerCase();

        // Using the forEach helper method to loop through the array
        angular.forEach(arr, function (item) {

            if (item.endpoint.toLowerCase().indexOf(searchString) !== -1) {
                result.push(item);
            }

        });

        return result;
    };

});
