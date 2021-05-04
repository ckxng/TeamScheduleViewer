using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TeamScheduleViewer.Models;

namespace TeamScheduleViewer.Service
{
    public class PlanLookupService : IPlanLookupService
    {
        private readonly ILogger<PlanLookupService> _logger;
        private readonly String _AppID;
        private readonly String _Secret;
        private readonly String _ServicesEndpoint;
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _ServiceTypeID;

        public IPlan[] PlansInServiceType()
        {
            List<IPlan> plans = new List<IPlan>();

            string error = null;

            try
            {
                Task<string> restask = _client.GetStringAsync(_ServicesEndpoint + "/service_types/" + _ServiceTypeID + "/plans");
                restask.Wait();
                string res = restask.Result;

                dynamic data = JsonConvert.DeserializeObject(res);

                for (int i = 0; i < data.data.Count; i++)
                {
                    try
                    {
                        string planID = data.data[i].id;
                        Plan plan = new Plan(DateTime.Parse((string)data.data[i].attributes.sort_date));

                        try
                        {
                            restask = _client.GetStringAsync(_ServicesEndpoint + "/service_types/" + _ServiceTypeID + "/plans/" + planID + "/team_members");
                            restask.Wait();
                            res = restask.Result;

                            dynamic membersdata = JsonConvert.DeserializeObject(res);

                            for (int j = 0; j < membersdata.data.Count; j++)
                            {
                                try
                                {
                                    plan.TeamMembers.Add(new TeamMember(
                                        (string)membersdata.data[j].attributes.name,
                                        (string)membersdata.data[j].attributes.team_position_name));
                                }
                                catch (Exception e)
                                {
                                    _logger.LogError("Member Parsing Failure: " + e.Message);
                                    error = "Invalid data was recieved from the API";
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            _logger.LogError("Person API Failure: " + e.Message);
                            error = "Unable to retrieve data from the API";
                        }

                        plans.Add(plan);
                    }
                    catch (Exception e)
                    {
                        _logger.LogError("Plan Parsing Failure: " + e.Message);
                        error = "Invalid data was recieved from the API";
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Plan API Failure: " + e.Message);
                error = "Unable to retrieve data from the API";
            }

            if(error != null)
            {
                throw new Exception(error);
            }

            return plans.ToArray();
        }

        public PlanLookupService(IConfiguration config, ILogger<PlanLookupService> logger)
        {
            _AppID = Environment.GetEnvironmentVariable("PCO_ApplicationID") ?? config.GetValue<string>("PCO_ApplicationID");
            _Secret = Environment.GetEnvironmentVariable("PCO_Secret") ?? config.GetValue<string>("PCO_Secret");
            _ServicesEndpoint = Environment.GetEnvironmentVariable("PCO_ServicesEndpoint") ?? config.GetValue<string>("PCO_ServicesEndpoint");
            _ServiceTypeID = Environment.GetEnvironmentVariable("PCO_ServiceTypeID") ?? config.GetValue<string>("PCO_ServiceTypeID");

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(_AppID + ":" + _Secret)));

            _logger = logger;
        }
    }
}