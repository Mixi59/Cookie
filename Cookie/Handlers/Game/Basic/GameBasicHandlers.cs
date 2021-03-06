﻿using Cookie.Core;
using Cookie.Datacenter;
using Cookie.Gamedata.D2o;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Game.Basic;
using Cookie.Utils.Enums;

namespace Cookie.Handlers.Game.Basic
{
    public class GameBasicHandlers
    {
        [MessageHandler(BasicLatencyStatsRequestMessage.ProtocolId)]
        private void BasicLatencyStatsRequestMessageHandler(DofusClient client, BasicLatencyStatsRequestMessage message)
        {
            var basicLatencyStatsMessage = new BasicLatencyStatsMessage(
                (ushort) client.Account.LatencyFrame.GetLatencyAvg(),
                (ushort) client.Account.LatencyFrame.GetSamplesCount(),
                (ushort) client.Account.LatencyFrame.GetSamplesMax());
            client.Send(basicLatencyStatsMessage);
        }

        [MessageHandler(BasicAckMessage.ProtocolId)]
        private void BasicAckMessageHandler(DofusClient client, BasicAckMessage message)
        {
            //
        }

        [MessageHandler(BasicTimeMessage.ProtocolId)]
        private void BasicTimeMessageHandler(DofusClient client, BasicTimeMessage message)
        {
            //
        }

        [MessageHandler(SequenceNumberRequestMessage.ProtocolId)]
        private void SequenceNumberRequestMessageHandler(DofusClient client, SequenceNumberRequestMessage message)
        {
            client.Account.LatencyFrame.Sequence++;
            var sequenceNumberMessage = new SequenceNumberMessage((ushort) client.Account.LatencyFrame.Sequence);
            client.Send(sequenceNumberMessage);
        }

        [MessageHandler(BasicNoOperationMessage.ProtocolId)]
        private void BasicNoOperationMessageHandler(DofusClient client, BasicNoOperationMessage message)
        {
            //
        }

        [MessageHandler(CurrentServerStatusUpdateMessage.ProtocolId)]
        private void CurrentServerStatusUpdateMessageHandler(DofusClient client,
            CurrentServerStatusUpdateMessage message)
        {
            client.Logger.Log("Server Status: " + (ServerStatusEnum) message.Status);
        }

        [MessageHandler(TextInformationMessage.ProtocolId)]
        private void TextInformationMessageHandler(DofusClient client, TextInformationMessage message)
        {
            var data = ObjectDataManager.Instance.Get<InfoMessage>(message.MsgType * 10000 + message.MsgId);
            var text = FastD2IReader.Instance.GetText(data.TextId);
            var parameters = message.Parameters.ToArray();
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                text = text.Replace("%" + (i + 1), parameter);
            }

            switch ((TextInformationTypeEnum) message.MsgType)
            {
                case TextInformationTypeEnum.TEXT_INFORMATION_ERROR:
                    client.Logger.Log(text, LogMessageType.Default);
                    client.Account.Character.Status = CharacterStatus.None;
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE:
                    client.Logger.Log(text, LogMessageType.Info);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_PVP:
                case TextInformationTypeEnum.TEXT_INFORMATION_FIGHT_LOG:
                    client.Logger.Log(text, LogMessageType.FightLog);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_POPUP:
                case TextInformationTypeEnum.TEXT_LIVING_OBJECT:
                case TextInformationTypeEnum.TEXT_ENTITY_TALK:
                    client.Logger.Log(text, LogMessageType.Default);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_FIGHT:
                    client.Logger.Log(text, LogMessageType.FightLog);
                    break;
                default:
                    client.Logger.Log((TextInformationTypeEnum) message.MsgType + " | ID = " + message.MsgId,
                        LogMessageType.Arena);
                    for (var i = 0; i < message.Parameters.Count; i++)
                    {
                        var t = message.Parameters[i];
                        client.Logger.Log("Parameter[" + i + "] " + t, LogMessageType.Arena);
                    }
                    break;
            }
        }
    }
}