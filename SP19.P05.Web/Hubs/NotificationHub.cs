using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SP19.P05.Web.Features.Authorization;

namespace SP19.P05.Web.Hubs
{
    [Authorize(Roles = UserRoles.Customer)]
    public class NotificationHub : Hub
    {
    }
}
