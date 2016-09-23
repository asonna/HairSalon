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

  }
}
