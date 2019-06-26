using Exercise.DAL.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise.DAL.HealthChecks
{
    public class RepositoryHealthCheck : IHealthCheck
    {
        private readonly IExerciseRepository _exerciseRepository;

        public RepositoryHealthCheck(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isRepositoryHealthy = false;

            try
            {
                isRepositoryHealthy = await _exerciseRepository.CheckHealth();
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(ex.Message);
            }

            var checkStatus = isRepositoryHealthy
                ? HealthCheckResult.Healthy()
                : HealthCheckResult.Unhealthy();

            return checkStatus;
        }
    }
}
