# Transact.HR Project Setup

Once cloned, the easiest way to set up a quick local Sqlite DB is to run the following commands in VS Package Manager Console.
Make sure you have the Transact.HR.DataAccess project selected.

```
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate
Update-Database
```

After this, run the API and then call the /Test/PopulateDb endpoint in order to populate the DB with some test information.

That's it! You're all set to test everything out.
