
 Employees Manager
======



## 1. Description

Web Application for employee managers. Simple CRUD application, user can add new employee, edit and delete existing employees and filter employees by last name, nip and position.

Application built with Razor Pages and ASP.NET Core. As persistant store are used XML files.



## 2. Screenshots
![alt screenshot](https://github.com/kamilkolodziejski/EmployeesManager/blob/master/start_page.jpg "Start page")


## 3. How to use?

1. To run the application is required installed .NET Core SDK at least version 2.1
2. Download/clone this repository, e.g. below command:
    ```bash
    git clone git@github.com:kamilkolodziejski/EmployeesManager.git
    ```
3. Go to src/ directory and run script 

    ```bash
    ./run.sh
    ```                     
    
4. Or go to terminal, change directory to EmployeesManager.Web/ and enter below commands:

    ```
    dotnet build
    
    dotnet run
    ```
    
    
5. Application will start and will be available from addresses defined in file lauchSettings.json, in this example: http://localhost:5000, https://localhost:5001




## 4. Configuration


  * EmployeesManager.Web/Properties/lauchSettings.json
  
In property ASPNETCORE_ENVIRONMENT is defined environment using to configure application behaviors e.g. is be use DevelopmentExceptionPage or custom Middleware Exception Handler.

  * EmployeesManager.Web/appsettings.json, EmployeesManager.Web/appsettings.Development.json
  
In depends which environment you have set, you should open corresponding file. In this file are settings about logging, allowed hosts and section about repository settings. Currently, they are XML files. Here you can set path to file stored employees data and choose whether the application will generate sample data.
