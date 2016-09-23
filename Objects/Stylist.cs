using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace HairSalon
{
  public class Stylist
  {
    private int _id;
    private string _name;

    public Stylist(string name, int id = 0)
    {
      _name = name;
      _id = id;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> listStylists = new List<Stylist> {};

      SqlConnection conn = DB.Connection();
      conn.Open();

      string query = "SELECT * from stylists;";
      SqlCommand cmd = new SqlCommand(query,conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      int id = 0;
      string name = null;
      while ( rdr.Read() )
      {
        id = rdr.GetInt32(0);
        name = rdr.GetString(1);
        Stylist stylist = new Stylist(name, id);
        listStylists.Add(stylist);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return listStylists;
    }
    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string nonQuery = "DELETE FROM stylists;";
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

      string query = "INSERT INTO stylists (description) OUTPUT INSERTED.id VALUES (@name);";
      SqlCommand cmd = new SqlCommand (query, conn);
      SqlParameter nameParameter = new SqlParameter("@name", this.GetName() );
      cmd.Parameters.Add(nameParameter);
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
    public static Stylist Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string query="SELECT * FROM stylists WHERE id = @id;";
      SqlCommand cmd = new SqlCommand (query, conn);
      SqlParameter idParameter = new SqlParameter("@id", id );
      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      int gotId = 0;
      string gotName = null;
      while( rdr.Read() )
      {
        gotId = rdr.GetInt32(0);
        gotName = rdr.GetString(1);
      }
      Stylist stylist = new Stylist (gotName, gotId);

      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return stylist;
    }
    public void Update(string name)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string query = "UPDATE stylists SET description=@name OUTPUT INSERTED.description WHERE id = @id;";
      SqlCommand cmd = new SqlCommand(query,conn);
      cmd.Parameters.AddRange( new []
      {
        new SqlParameter( "@name", name ),
        new SqlParameter( "@id", this.GetId() )
      });
      SqlDataReader rdr = cmd.ExecuteReader();
      while ( rdr.Read() )
      {
        this._name = rdr.GetString(0);
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

      string query="DELETE FROM stylists WHERE id = @id;";
      SqlCommand cmd = new SqlCommand (query, conn);
      SqlParameter idParameter = new SqlParameter("@id", this._id );
      cmd.Parameters.Add(idParameter);
      SqlDataReader rdr = cmd.ExecuteReader();

      if (conn != null)
      {
        conn.Close();
      }

    }
    //Overrides
   public override bool Equals(System.Object stylist)
   {
     if (!(stylist is Stylist))
     {
       return false;
     }
     else
     {
       Stylist newStylist = (Stylist) stylist;
       bool nameEquality = ( newStylist.GetName() == this.GetName() );
       bool idEquality = ( newStylist.GetId() == this.GetId() );
       return ( idEquality && nameEquality);
     }
   }
   public override int GetHashCode()
   {
     return this.GetName().GetHashCode();
   }

  }
}
