
 Employees Manager
======



## 1. Description

Web Application for employee managers. Simple CRUD application, user can add new employee, edit and delete existing and filter employees by last name, nip and position.

Application built with Razor Pages and ASP.NET Core. As persistant store are used XML files.



## 2. Screenshots
![alt screenshot](https://github.com/kamilkolodziejski/EmployeesManager/blob/master/start_page.jpg "Start page")


## 3. How to use?

1. You need install .NET Core SDK min. 2.1
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
    
    
5. Application will start and will be available from those addresses, depends from protocol: http://localhost:5000 and https://localhost:5001 .




## 4. Configuration

#### By editing configuration files, you can change some application's settings



  * EmployeesManager.Web/Properties/lauchSettings.json
  
Here we are some runtime profiles. Until you run application from command line, you should be interested second profile - EmployeesManager.Web, where you can change application endpoints and environment.

  * EmployeesManager.Web/appsettings.json, EmployeesManager.Web/appsettings.Development.json
  
In depends which environment you have set, you should open corresponding file. In this file are settings about logging, allowed hosts and section about repository settings. Currently, they are XML files. Here you can set path to file for store employees data and you can choose whether the application will generate sample data.
