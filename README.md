# Pet
* an dotnet core project 

Running a project

* Create appsettings.json file on the Pet directory and put the following code

{
  "ConnectionStrings": {
    "DefaultConnection": "server=yourhost;port=yourport;database=databasename;user=yourusername;password=yourpassword"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*"
}

After that 

Run the Dotnet command

* dotnet restore

and run the node command

*npm update