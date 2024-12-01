using Quartz;

namespace Auto_API_Run
{
    public class ApiJob: IJob
    {
        private readonly ApiService _apiService;

        public ApiJob(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            await _apiService.CallApis();
        }
    }
}
