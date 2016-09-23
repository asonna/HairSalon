using System;
using System.Collections.Generic;
using Xunit;
using System.Data;
using System.Data.SqlClient;
using HairSalon;

namespace Tests
{
  public class Client_Test : IDisposable
  {
    public Client_Test()
    {
      string dataSource = "Data Source=(localdb)\\mssqllocaldb"; // Data Source identifies the server.
      string databaseName = "hair_salon_test"; // Initial Catalog is the database name
      //Integrated Security sets the security of the database access to the Windows user that is currently logged in.
      DBConfiguration.ConnectionString = ""+dataSource+";Initial Catalog="+databaseName+";Integrated Security=SSPI;";
    }
    [Fact]
    public void Client_DoConstructorAndGettersWork()
    {
      //Act
      Client newClient = new Client ("Sara", 1);
      //Arrange
      Assert.Equal( "Sara", newClient.GetName() );
      Assert.Equal( 0, newClient.GetId() );
      Assert.Equal( 1, newClient.GetStylist() );
    }
    [Fact]
    public void GetAll_ReturnsAllRowFromPage()
    {
      //Act
      int rows = Stylist.GetAll().Count;
      //Arrange
      Assert.Equal(0,rows);
    }
    [Fact]
    public void Save_SaveInstanceToDatabase()
    {
      //Arrange
      Client newClient = new Client ("Jerry", 1);
      //Act
      newClient.Save();
      //Assert
      List<Client> saved = Client.GetAll();
      List<Client> created = new List<Client> {newClient};
      Assert.Equal(created,saved);
    }
    // [Fact]
    // public void Find_CandFindAndReturnARow()
    // {
    //   //Arrange
    //   Stylist stylist = new Stylist ("Susan");
    //   stylist.Save();
    //   Stylist stylist2 = new Stylist ("Dan");
    //   stylist2.Save();
    //   // Act
    //   Stylist foundStylist  = Stylist.Find( stylist.GetId() );
    //   //Assert
    //   Assert.Equal(stylist,foundStylist);
    // }
    // [Fact]
    // public void Update_WillUpdateARowWithANewName()
    // {
    //   //Arrange
    //   string anne = "Anne";
    //   string steve = "Steve";
    //   Stylist stylist = new Stylist(anne);
    //   stylist.Save();
    //   //Act
    //   stylist.Update(steve);
    //   //Assert
    //   Assert.Equal( steve, stylist.GetName() );
    // }
    // public void Delete_WillDeleteARow()
    // {
    //   //Arrange
    //   Stylist stylist = new Stylist ("Dan");
    //   stylist.Save();
    //   Stylist stylist2 = new Stylist ("Julie");
    //   stylist2.Save();
    //   // Act
    //   stylist.Delete(); // Dan was fired.
    //   //Assert
    //   Assert.Equal(1, Stylist.GetAll().Count );
    // }
    public void Dispose()
    {
      Client.DeleteAll();
    }
  }
}
