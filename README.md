This project contains a WebApi which enables users to create and list products.
A diagram file has been added in a form of a PDF to show how this API could fit in an event-driven architecture as a Micro-Service. File name is "Event-Driven Archtectural Diagram.pdf"
You will need an instance of SQL server to test application.
When running the solution, please add the user secret config as follows:

{
  "Jwt": {
    "Key": "vCevAVOu1ETl3S6ws3E4Lm8cdnqREN8f",
    "Audience": "https://localhost:7067",
    "Issuer": "https://localhost:7067"
  },
  "ConnectionStrings": {
    "ProductConnectionString": "use your connection string here"
  }
}

This is because we normally put secrets like this in the Azure Kevault and not the config files.

## For the Running the integration tests, you will need to add a user secret file with content like this

{
  "TestUserName": "username here",
  "TestUserPassword": "password",
  "ConnectionStrings": {
    "ProductTestConnectionString": "server=<your_server>;Initial Catalog=<testdb_name>;User ID=<db_username>;Password=<db_user_password>;Persist Security Info=True;MultipleActiveResultSets=True;TrustServerCertificate=True" //"connection string with your test database name"
  }
}
