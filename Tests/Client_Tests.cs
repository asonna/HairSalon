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
    [Fact]
    public void Find_CandFindAndReturnARow()
    {
      //Arrange
      Client client = new Client("Bill", 1);
      client.Save();
      Client client2 = new Client("George", 2);
      client2.Save();
      // Act
      Client foundClient = Client.Find( client.GetId() );
      //Assert
      Assert.Equal(client, foundClient);
    }
    [Fact]
    public void Update_WillUpdateARowWithANewName()
    {
      //Arrange
      string anne = "Anne";
      int anne_stylist = 1;
      string steve = "Steve";
      int steve_stylist = 2;
      Client client = new Client(anne, anne_stylist);
      client.Save();
      //Act
      client.Update(steve, steve_stylist );
      //Assert
      Assert.Equal( steve, client.GetName() );
      Assert.Equal( steve_stylist, client.GetStylist() );
    }
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
