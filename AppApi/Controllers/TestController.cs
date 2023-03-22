using HFJobs.Interfaces;
using HFJobs.Jobs;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IFireAndForgetExecutor<FireAndForgetDraft> _fireAndForgetExecutor;
    private readonly IDelayedExecutor<DelayedDraft> _delayedExecutor;

    public TestController(IFireAndForgetExecutor<FireAndForgetDraft> fireAndForgetExecutor,
        IDelayedExecutor<DelayedDraft> delayedExecutor)
    {
        _fireAndForgetExecutor = fireAndForgetExecutor;
        _delayedExecutor = delayedExecutor;
    }

    [HttpGet("[action]")]
    public IActionResult FireAndForgetJob(CancellationToken ct)
    {
        _fireAndForgetExecutor.Enqueue(ct);
        return Ok();
    }

    [HttpGet("[action]")]
    public IActionResult DelayedJob(CancellationToken ct)
    {
        _delayedExecutor.RunAsync(ct);
        return Ok();
    }
}