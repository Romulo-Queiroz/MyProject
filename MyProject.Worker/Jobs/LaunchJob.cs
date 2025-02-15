using Microsoft.EntityFrameworkCore;
using MyProject.Infrastructure.Services;
using MyProject.Persistence;

namespace MyProject.Worker.Jobs
{
    public class LaunchJob
    {
        private readonly SpaceXService _spaceXService;
        private readonly ApplicationDbContext _dbContext;

        public LaunchJob(SpaceXService spaceXService, ApplicationDbContext dbContext)
        {
            _spaceXService = spaceXService;
            _dbContext = dbContext;
        }

        public async Task FetchAndSaveLaunches()
        {
            var launches = await _spaceXService.GetLaunchesAsync();

            foreach (var launch in launches)
            {
                if (!await _dbContext.Launches.AnyAsync(l => l.Id == launch.Id))
                {
                    _dbContext.Launches.Add(launch);
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
