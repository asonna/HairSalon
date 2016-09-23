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
    public void Stylist_DoConstructorAndGettersWork()
    {
      //Act
      Stylist newStyle = new Stylist ("Sara");
      //Arrange
      Assert.Equal( "Sara", newStyle.GetName() );
      Assert.Equal( 0, newStyle.GetId() );
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
      Stylist newStylist = new Stylist ("Jenny");
      //Act
      newStylist.Save();
      //Assert
      List<Stylist> saved = Stylist.GetAll();
      List<Stylist> created = new List<Stylist> {newStylist};
      Assert.Equal(saved, created);
    }
    [Fact]
    public void Find_CandFindAndReturnARow()
    {
      //Arrange
      Stylist stylist = new Stylist ("Susan");
      stylist.Save();
      Stylist stylist2 = new Stylist ("Dan");
      stylist2.Save();
      // Act
      Stylist foundStylist  = Stylist.Find( stylist.GetId() );
      //Assert
      Assert.Equal(stylist,foundStylist);
    }
    [Fact]
    public void Update_WillUpdateARowWithANewName()
    {
      //Arrange
      string anne = "Anne";
      string steve = "Steve";
      Stylist stylist = new Stylist(anne);
      stylist.Save();
      //Act
      stylist.Update(steve);
      //Assert
      Assert.Equal( steve, stylist.GetName() );
    }
    public void Delete_WillDeleteARow()
    {
      //Arrange
      Stylist stylist = new Stylist ("Dan");
      stylist.Save();
      Stylist stylist2 = new Stylist ("Julie");
      stylist2.Save();
      // Act
      stylist.Delete(); // Dan was fired.
      //Assert
      Assert.Equal(1, Stylist.GetAll().Count );
    }
    public void FindClients()
    {
      //Arrange
      Stylist stylist = new Stylist ("Sara's Sister");
      stylist.Save();
      Stylist stylist2 = new Stylist ("Mrs. Nordy");
      stylist2.Save();
      Client client = new Client ("Dan", 1);
      client.Save();
      Client client1 = new Client ("George", 1);
      client1.Save();
      Client client2 = new Client ("Coolio", 2);
      client2.Save();
      List<Client> created = new List<Client> {client, client1};
      //Act
      List<Client> saved = stylist2.FindClients();
      //Assert
      Assert.Equal(created, saved);
    }
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
  }
}
