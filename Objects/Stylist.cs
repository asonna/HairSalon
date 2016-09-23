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
    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      string query = "INSERT INTO stylists (description) OUTPUT INSERTED.id VALUES (@name);";
      SqlCommand cmd = new SqlCommand (query, conn);
      SqlParameter nameParameter = new SqlParameter("name", this.GetName() );
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
