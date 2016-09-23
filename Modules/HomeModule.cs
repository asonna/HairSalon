using Nancy;
using System;
using System.Collections.Generic;

namespace HairSalon
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>
      {
        List<Stylist> stylists = Stylist.GetAll();
        return View["index.cshtml", stylists];
      };
      Post["/add_stylist"] = _ => {
        Stylist newStylist = new Stylist (Request.Form["stylist"]);
        newStylist.Save();

        List<Stylist> stylists = Stylist.GetAll();
        return View["index.cshtml", stylists];
      };
      Get["/delete_all_stylists_and_clients"] = _ =>
      {
        Stylist.DeleteAll();
        Client.DeleteAll();

        List<Stylist> stylists = Stylist.GetAll();
        return View["index.cshtml", stylists];
      };
      Get["/stylist/{id}"] = parameters =>
      {
        Stylist currentStylist = Stylist.Find(parameters.id);
        List<Client> clients = currentStylist.FindClients();

        Dictionary<string,object> model = new Dictionary<string,object> {};
        model.Add("stylist", currentStylist);
        model.Add("clients", clients);
        return View["client_list_by_stylist", model];
      };
      Post["/add_client"] = _ => {
        Client newClient = new Client (Request.Form["new_client"],Request.Form["stylist_id"]);
        newClient.Save();


        Stylist currentStylist = Stylist.Find(Request.Form["stylist_id"]);
        List<Client> clients = currentStylist.FindClients();

        Dictionary<string,object> model = new Dictionary<string,object> {};
        model.Add("stylist", currentStylist);
        model.Add("clients", clients);
        return View["client_list_by_stylist", model];
      };
    }
  }
}
