using System;
using System.Collections.Generic;
using Xunit;
using System.Data;
using System.Data.SqlClient;
using HairSalon;

namespace Tests
{
  public class Stylist_Tests : IDisposable
  {
    public Stylist_Tests()
    {
      string dataSource = "Data Source=(localdb)\\mssqllocaldb"; // Data Source identifies the server.
      string databaseName = "hair_salon_test"; // Initial Catalog is the database name
      //Integrated Security sets the security of the database access to the Windows user that is currently logged in.
      DBConfiguration.ConnectionString = ""+dataSource+";Initial Catalog="+databaseName+";Integrated Security=SSPI;";
    }
    [Fact]
    public void Stylist_DoConstructorAndGettersWork_1()
    {
      //Act
      Stylist newStyle = new Stylist ("Sara");
      //Arrange
      Assert.Equal( "Sara", newStyle.GetName() );
      Assert.Equal( 0, newStyle.GetId() );
    }
    public void GetAll_GetAllReturnsAllRowFromTage_2()
    {
      //Act
      int rows = Stylist.GetAll().Count;
      //Arrange
      Assert.Equal(0,rows);
    }

    public void Dispose()
    {
      // Item.DeleteAll();
    }
  }
}
