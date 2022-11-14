# CliresRDMS
This is a demo for the initial project I introduce to my team. My team intended to upgrade our old system from Asp.net MVC to Asp.net Core and Blazor Web assembly. I'm responsible for building the project structure, so I developed it with clean architecture, and new technologies and introduced it to my team
## User interfaces
HOME -UI
![Project structure](/Images/clires-web-ui.png "Project structure")
Project Page
![Project structure](/Images/project-page.png "Project structure")
Admin page
![Project structure](/Images/admin-page.png "Project structure")
## Technologies
- ASP.NET CORE 5.0
- Entity framework core
- Blazor WebAssembly
- Microsoft SQL Server 
## Code structure: Including 4 sub-projects:
- Application Core
- Infrastructure
- Web Api
- Clires Web

![Project structure](/Images/project-structure-main.png "Project structure")
### 1. Application Core
- ApiClient: WebApiExcuter class is an intermediary layer, connecting between the Client and API by HttpClient class
- Services: define services; they work with Client through interface classes 
- Repositories: define classes using for CRUD methods
  
![Project structure](/Images/application-core.png "Project structure")
### 2. Infrastructure
- Models: define model classes for the system.
- Services: define log handling, email, web file for system
- Entities: work with the database by using entity framework core to create .net objects
  - Clires_System DB: CliresSystemDBContext class uses static connection
  - Clires_Template: ProjectDBContext class uses dynamic connection; using for fixed tables in the different project databases

![Project structure](/Images/infrastructure.png "Project structure")
### 3. Web API
- Auth: includes the custom JWT token class
- Controller: define actions that handle requests from Client
- Extensions: includes middleware classes
- Filters: includes attribute classes
- Logs: a place to store Logs files from the system.
- Services: define a class using to register services in API

![Project structure](/Images/web-api.png "Project structure")

### * Authentication & Authorization at API side
- Using JWT for authentication is defined in JwtTokenManager class.
- JwtAuthorizeAttribute class is used to check user's authorization at controller when they login to the system successfully.
- Using Claim to store user identity, includes user information and their roles

![Project structure](/Images/authen-folders.png "Project structure")
![Project structure](/Images/authentication.png "Project structure")

### * Exception handling
- Replace Try…catch exception by middleware class:
- Using ExceptionMiddleware class to handle exception. 

![Project structure](/Images/exception-handling.png "Project structure")
### 4. Clires Web
- wwwroot: includes app setting, environmental app setting files and index.html webpage
- Components: includes the reusable parts of the application
- Pages: contains the routable components/pages that make up the application
- Shared: contains the following shared components and stylesheets
- Resources: stores language translations (Vietnamese and English)
- Services: contains services using for Client

![Project structure](/Images/clires-web.png "Project structure")
### * Authentication & Authorization at Client side
- JwtTokenAuthenticationState class reads User identity from token 
  
![Project structure](/Images/authen-client-side.png "Project structure")
- On each razor page, we add attribute and role to verify user 
  
![Project structure](/Images/role-client-side.png "Project structure")
### * Multiple Languages
- Using AKSoftware.Localization.MultiLanguages library
- Change language at LanguageSelector.razor component.
- Using languageContainer to get label of language

![Project structure](/Images/multiple-languages.png "Project structure")
## Entity Framework
- Working with entities by database first approach
- Using Scaffold-DbContext command to scaffold a DbContext and entity type classes for a database.
  
    <i>Scaffold-DbContext "Server=(local);Database=CLIRES_SYSTEM;User ID=sa;Password=xxxxx;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities/CliresSystem -Context CliresSystemDBContext –Force
    As the result, a context class and entity classes are generated : CliresSystemDBContext, TblAccount, TblGroup…</i>

![Project structure](/Images/ef-db.png "Project structure")



