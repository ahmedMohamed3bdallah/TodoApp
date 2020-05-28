# TodoApp
Todo App using .net core 3.1 &amp; angular 9
-using angular material
- sql server
authentication by using JWT 
# steps to use
a- BackEnd 
    1- clone from repository
    2- open solution ToDO.sln
    3- modify connectionString 'DefaultConnection' in webAPI project in appsettings.json
    4- open Package manager Console
    5- set Default Project 'DAL'
    6- type in PMC update-database
    7- set WebAPI as startup project
    8- run the swagger UI will appear 
    9- use '/api/Admin/Register' from admin group in Swagger UI to make a new user
b- FrontEnd 
    1- open folder ClientApp in vs code 
    2- write in terminal npm install
    3- after finish write ng s --o 
    4- use the user you entered before to login 

