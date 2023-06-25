using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Commons;
using TodoApp.Models;

namespace TodoApp.Services;

public class ToDoService
{
    public HttpClient httpClient { get; set; }
    public ToDoService()
    {
        httpClient = new HttpClient();
    }


    public async Task<List<ToDo>> GetToDo()
    {
        // Je récupère la liste des todo depuis l'api.
        
        var temp = await httpClient.GetAsync($"{Constants.API_LINK}/taches");
       // Je vérifie si tout s'est bien passé.
        if (temp.IsSuccessStatusCode)
        {
            // Je récupère le retour de l'api sous format json, sachant que l'api retourne une liste de ToDo
            var data = await temp.Content.ReadFromJsonAsync<List<ToDo>>();
            // Je retourne la donnée que j'ai récupéré.
            return data;
        }
        return null;
    }

    public async Task<bool> AddToDo(ToDo toDo)
    {
        var jsonData = JsonConvert.SerializeObject(toDo);
        StringContent data = new StringContent(jsonData,Encoding.UTF8, "application/json");
        var rep = await httpClient.PostAsync($"{Constants.API_LINK}/taches/", data);
        var message = await rep.Content.ReadAsStringAsync();
        return rep.IsSuccessStatusCode;     
    }
}
