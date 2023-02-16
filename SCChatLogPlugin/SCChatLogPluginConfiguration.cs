using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCChatLogPlugin
{
    public class SCChatLogPluginConfiguration : IRocketPluginConfiguration
    {

        public string LoadMessage { get; set; }
        public string UnloadMessage { get; set; }
        
        public string DiscordWebhook { get; set; }
        public void LoadDefaults()
        {
            LoadMessage = $"\n##############################\n SC Chat Log Plugin has loaded.\n##############################\n";
            UnloadMessage = $"\n##############################\n SC Chat Log Plugin has unloaded.\n##############################\n";
            DiscordWebhook = "https://discord.com/api/webhooks/1075656014847823913/g5Ucx0WywDvnLOYmgJqkKiwNICquTQy1lXnn_8ozitIgya3_p5dYR_Twx2ND_M0phEjp";
        }
    }
}
