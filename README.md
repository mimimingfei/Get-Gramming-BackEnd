# Backend for Get Gramming

## About Get Gramming
Get Gramming is a web platform where users can share restaurants perfect for Instagram-worthy moments.

## User Stories
- Users can register and create their own profile.
- Users can login to their account.
- Users can view all the restaurants in the HomePage/FeedPage to explore places
- Users can search restaurants by city in the HomePage/FeedPage
- Users can sort restaurants according the cuisines that they
- Only logged in users can add a new restaurant.
- Users can view their restaurant post history under their profile and delete and patch their own restaurant post.
- Users can logout of their profile.
- Users who wish not to make an account can still access the list of instagrammable restaurants without creating their profile. Non registered users cannot post a new restaurant.

## Tools and Technology
- The backend APIs are programmed in c# programming language
- The database is created using postgresql and hosted on Elephant SQL
- Entity Framework Core is used to communicate with database
- Bcrypt library is used for password hash
- JWT Bearer is used for Web Auth Token Genration
- The uploaded images by the users are stored in google firebase

## Set-Up
- Install Visual Studio with the ASP.NET and web development workload.
- From the File menu, select Clone a Repository.
- Enter the git repository URL: https://github.com/mimimingfei/Get-Gramming-BackEnd.git
- Build solution
- Run `dotnet run` command to start the server
  
- If using your own database:
    - Go to appsettings.json file and change the connection string to your database string
    - Got to package-manager console and run `Update-Database` to seed the data to your database
- If facing issue in updating the database:
    - Run `Remove-Migration` command untill all migration files are removed
    - Run `Add-Migration <Migration name>` command followed by `Update-Database`

The link to FrontEnd repository for GetGramming web application: https://github.com/cdesale/Get-Gramming-FE.git

