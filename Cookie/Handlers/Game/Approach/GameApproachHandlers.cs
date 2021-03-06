﻿using System.Threading;
using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Approach;
using Cookie.Protocol.Network.Messages.Game.Character.Choice;

namespace Cookie.Handlers.Game.Approach
{
    public class GameApproachHandlers
    {
        [MessageHandler(AuthenticationTicketAcceptedMessage.ProtocolId)]
        private void AuthenticationTicketAcceptedMessageHandler(DofusClient client,
            AuthenticationTicketAcceptedMessage message)
        {
            Thread.Sleep(300);
            client.Send(new CharactersListRequestMessage());
        }

        [MessageHandler(AccountLoggingKickedMessage.ProtocolId)]
        private void AccountLoggingKickedMessageHandler(DofusClient client, AccountLoggingKickedMessage message)
        {
            client.Logger.Log(
                $"Compte kick pour {message.Days} jours, {message.Hours} heures, {message.Minutes} minutes :'( ",
                LogMessageType.Public);
            client.Dispose();
        }

        [MessageHandler(HelloGameMessage.ProtocolId)]
        private void HelloGameMessageHandler(DofusClient client, HelloGameMessage message)
        {
            client.Logger.Log("Connecté au serveur de jeu.");
            var atm = new AuthenticationTicketMessage("fr", client.Account.Ticket);
            client.Send(atm);
        }

        [MessageHandler(AccountCapabilitiesMessage.ProtocolId)]
        private void AccountCapabilitiesMessageHandler(DofusClient client, AccountCapabilitiesMessage message)
        {
            //
        }

        [MessageHandler(ServerSettingsMessage.ProtocolId)]
        private void ServerSettingsMessageHandler(DofusClient client, ServerSettingsMessage message)
        {
            //
        }

        [MessageHandler(ServerOptionalFeaturesMessage.ProtocolId)]
        private void ServerOptionalFeaturesMessageHandler(DofusClient client, ServerOptionalFeaturesMessage message)
        {
            //
        }

        [MessageHandler(ServerSessionConstantsMessage.ProtocolId)]
        private void ServerSessionConstantsMessageHandler(DofusClient client, ServerSessionConstantsMessage message)
        {
            //
        }
    }
}