using Rocket.Core.Plugins;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Rocket.Core.Logging.Logger;

namespace SCChatLogPlugin
{
    public class SCChatLogPlugin : RocketPlugin<SCChatLogPluginConfiguration>
    {
        protected override void Load()
        {
            Logger.Log(Configuration.Instance.LoadMessage);
            ChatManager.onChatted += OnPlayerChat;
        }

        public static void sendDiscordWebhook(string url, string json)
        {
            var request = WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Method = "POST";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                streamWriter.Write(json);
            request.GetResponse();
        }

        private void OnPlayerChat(SteamPlayer player, EChatMode mode, ref Color chatted, ref bool isRich, string text, ref bool isVisible)
        {
            var uPlayer = UnturnedPlayer.FromSteamPlayer(player);
            var webhook = Configuration.Instance.DiscordWebhook;
            var name = uPlayer.DisplayName;
            var profile = uPlayer.SteamProfile.AvatarIcon;

            sendDiscordWebhook(webhook, ($"{{ \"embeds\": [{{\"description\": \"{text}\", \"color\": null, \"author\": {{\"name\": \"{name}\", \"icon_url\": \"{profile}\"}}}}], \"attachments\": []}}"));
        }
        protected override void Unload()
        {
            Logger.Log(Configuration.Instance.UnloadMessage);
        }
    }
}
