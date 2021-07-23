using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Tmuzik.Api.SignalR
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }
        public async Task SendOfferMessage(object obj)
        {
            _logger.LogInformation($"SendOfferMessage: {JsonSerializer.Serialize(obj)}");
            await Clients.Others.SendAsync("ReceiveOfferMessage", obj);
        }

        public async Task SendAnswerMessage(object obj)
        {
            _logger.LogInformation($"SendAnswerMessage: {JsonSerializer.Serialize(obj)}");
            await Clients.Others.SendAsync("ReceiveAnswerMessage", obj);
        }

        public async Task SendCandidateMessage(object obj)
        {
            _logger.LogInformation($"SendCandidateMessage: {JsonSerializer.Serialize(obj)}");
            await Clients.Others.SendAsync("ReceivedCandidateMessage", obj);
        }
    }
}