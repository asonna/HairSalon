using System;
using System.Collections.Generic;
using Xunit;
using System.Data;
using System.Data.SqlClient;
using HairSalon;

namespace Tests
{
  public class Client_Tests : IDisposable
  {
    public Client_Tests()
    {
      string dataSource = "Data Source=(localdb)\\mssqllocaldb"; // Data Source identifies the server.
      string databaseName = "hair_salon_test"; // Initial Catalog is the database name
      //Integrated Security sets the security of the database access to the Windows user that is currently logged in.
      DBConfiguration.ConnectionString = ""+dataSource+";Initial Catalog="+databaseName+";Integrated Security=SSPI;";
    }


    public void Dispose()
    {
      // Item.DeleteAll();
    }
  }
}
