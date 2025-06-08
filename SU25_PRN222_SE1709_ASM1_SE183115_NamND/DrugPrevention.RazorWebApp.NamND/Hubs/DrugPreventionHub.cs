using DrugPrevention.Repositories.NamND.Models;
using DrugPrevention.Services.NamND;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace DrugPrevention.RazorWebApp.NamND.Hubs
{
    public class DrugPreventionHub : Hub
    {
        private readonly ISurveyQuestionsNamNDService _surveyQuestionsNamNDService;

        public DrugPreventionHub(ISurveyQuestionsNamNDService surveyQuestionsNamNDService)
        {
            _surveyQuestionsNamNDService = surveyQuestionsNamNDService;
        }

        //#region Hub for SurveyQuestion - SignalR

        public async Task HubDelete_SurveyQuestion(string surveyQuestionsNamNDId)
        {
            //// Send primary key to all clients connecting with SignalRHub (Invokes a method On the Connection from clients)
            await Clients.All.SendAsync("Receiver_DeleteSurveyQuestionsNamND", surveyQuestionsNamNDId);

            //// Call Domain Application to Delete
            await _surveyQuestionsNamNDService.DeleteAsync(int.Parse(surveyQuestionsNamNDId));
        }

        public async Task HubCreate_SurveyQuestion(string surveyQuestionsNamNDJsonString)
        {
            //// Parses json string to object
            var item = JsonConvert.DeserializeObject<SurveyQuestionsNamND>(surveyQuestionsNamNDJsonString);

            //// Send this object to all clients connecting with SignalRHub
            await Clients.All.SendAsync("Receiver_CreateSurveyQuestionsNamND", item);

            //// Inserts it to DB via Domain Application
            await _surveyQuestionsNamNDService.CreateAsync(item);
        }

        public async Task HubUpdate_SurveyQuestion(string surveyQuestionsNamNDJsonString)
        {
            //// Parses json string to object
            var item = JsonConvert.DeserializeObject<SurveyQuestionsNamND>(surveyQuestionsNamNDJsonString);

            //// Send this object to all clients connecting with SignalRHub
            await Clients.All.SendAsync("Receiver_UpdateSurveyQuestionsNamND", item);

            //// Updates it to DB via Domain Application
            await _surveyQuestionsNamNDService.UpdateAsync(item);
        }
    }
}
