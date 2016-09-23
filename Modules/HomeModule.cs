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
      ///////////////////////////////////////////////////
      ////RESTFUL ROOTS FOR Stylist                  ////
      //////////////////////////////////////////////////
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
      Get["/edit/{id}"] = parameters =>
      {
        Stylist editStylist = Stylist.Find(parameters.id);
        return View["change_and_delete_stylist.cshtml", editStylist];
      };
      Patch["/edit/{id}"] = parameters => {
        Stylist updateStylist = Stylist.Find(parameters.id);
        updateStylist.Update(Request.Form["new_stylist_name"]);
        return View["success.cshtml"];
      };
      Delete["/edit/{id}"] = parameters =>
      {
        Stylist removedStylist = Stylist.Find(parameters.id);
        removedStylist.Delete();
        return View["success.cshtml"];
      };
      ////////////////////////////////////////////////////////////
      /////  RESTFUL ROUTS FOR CLIENTS                  //////////
      ///////////////////////////////////////////////////////////
      Get["/clients/{id}"] = parameters =>
      {
        Stylist currentStylist = Stylist.Find(parameters.id);
        List<Client> clients = currentStylist.FindClients();

        Dictionary<string,object> model = new Dictionary<string,object> {};
        model.Add("stylist", currentStylist);
        model.Add("clients", clients);
        return View["client_list_by_stylist.cshtml", model];
      };
      Post["/clients/add_client"] = _ =>
      {
        Client newClient = new Client (Request.Form["new_client"],Request.Form["stylist_id"]);
        newClient.Save();

        Stylist currentStylist = Stylist.Find(Request.Form["stylist_id"]);
        List<Client> clients = currentStylist.FindClients();

        Dictionary<string,object> model = new Dictionary<string,object> {};
        model.Add("stylist", currentStylist);
        model.Add("clients", clients);
        return View["client_list_by_stylist.cshtml", model];
      };
      Get["/clients/edit/{id}"] = parameters =>
      {
        Client client = Client.Find(parameters.id);
        return View["change_and_delete_client.cshtml", client];
      };
      Patch["/clients/edit/{id}"] = parameters => {
        Client client = Client.Find(parameters.id);
        client.Update(Request.Form["new_client_name"],Request.Form["stylist_id"]);
        return View["success.cshtml"];
      };
      Delete["/clients/edit/{id}"] = parameters =>
      {
        Client client = Client.Find(parameters.id);
        client.Delete();
        return View["success.cshtml"];
      };






    }
  }
}
