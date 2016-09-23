using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace HairSalon
{
  public class Client
  {
    private int _id;
    private string _name;
    private int _stylist;

    public Client(string name, int stylist, int id = 0)
    {
      _name = name;
      _id = id;
      _stylist = stylist;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public int GetStylist()
    {
      return _stylist;
    }
    public static List<Client> GetAll()
    {
      List<Client> listClients = new List<Client> {};

      SqlConnection conn = DB.Connection();
      conn.Open();

      string query = "SELECT * from clients;";
      SqlCommand cmd = new SqlCommand(query,conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      int id = 0;
      string name = null;
      int stylist = 0;
      while ( rdr.Read() )
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        stylist = rdr.GetInt32(2);
        Client client = new Client(name, stylist, id);
        listClients.Add(client);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return listClients;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string nonQuery = "DELETE FROM clients;";
      SqlCommand cmd = new SqlCommand(nonQuery,conn);
      cmd.ExecuteNonQuery();

      if (conn != null)
      {
        conn.Close();
      }
    }
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string query = "INSERT INTO clients (description, stylist) OUTPUT INSERTED.id VALUES (@name, @stylist);";
      SqlCommand cmd = new SqlCommand (query, conn);
      cmd.Parameters.AddRange( new []
      {
        new SqlParameter( "@name", this._name ),
        new SqlParameter( "@stylist", this.GetStylist() )
      });
      SqlDataReader rdr = cmd.ExecuteReader();

      while ( rdr.Read() )
      {
        _id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public static Client Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string query="SELECT * FROM clients WHERE id = @id;";
      SqlCommand cmd = new SqlCommand (query, conn);
      SqlParameter idParameter = new SqlParameter("@id", id );
      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int gotId = 0;
      string gotName = null;
      int gotStylist = 0;
      while( rdr.Read() )
      {
        gotId = rdr.GetInt32(0);
        gotName = rdr.GetString(1);
        gotStylist = rdr.GetInt32(2);
      }
      Client client = new Client (gotName, gotStylist, gotId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return client;
    }
    public void Update(string name, int stylist)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string query = "UPDATE clients SET description=@name, stylist=@stylist OUTPUT INSERTED.description, INSERTED.stylist WHERE id = @id;";
      SqlCommand cmd = new SqlCommand(query,conn);
      cmd.Parameters.AddRange( new []
      {
        new SqlParameter( "@name", name ),
        new SqlParameter( "@stylist", stylist ),
        new SqlParameter( "@id", this.GetId() )
      });
      SqlDataReader rdr = cmd.ExecuteReader();
      while ( rdr.Read() )
      {
        this._name = rdr.GetString(0);
        this._stylist = rdr.GetInt32(1);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }
    public void Delete()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string query="DELETE FROM Clients WHERE id = @id;";
      SqlCommand cmd = new SqlCommand (query, conn);
      SqlParameter idParameter = new SqlParameter("id", this._id );
      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      if (conn != null)
      {
        conn.Close();
      }
   
    }
    //Overrides
   public override bool Equals(System.Object client)
   {
     if (!(client is Client))
     {
       return false;
     }
     else
     {
       Client newClient = (Client) client;
       bool nameEquality = ( newClient.GetName() == this.GetName() );
       Console.WriteLine(newClient.GetName());
       Console.WriteLine(this.GetName() );
       bool idEquality = ( newClient.GetId() == this.GetId() );
       Console.WriteLine(newClient.GetId() );
       Console.WriteLine(this.GetId() );
       bool stylistEquality = ( newClient.GetStylist() == this.GetStylist() );
       Console.WriteLine(newClient.GetStylist() );
       Console.WriteLine(this.GetStylist() );
       return ( idEquality && nameEquality && stylistEquality);
     }
   }
   public override int GetHashCode()
   {
     return this.GetName().GetHashCode();
   }
  }
}
