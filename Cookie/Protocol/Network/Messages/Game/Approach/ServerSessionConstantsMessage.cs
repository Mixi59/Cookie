﻿using System.Collections.Generic;
using Cookie.IO;
using Cookie.Protocol.Network.Types.Game.Approach;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    internal class ServerSessionConstantsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6434;

        public List<ServerSessionConstant> Variables;

        public ServerSessionConstantsMessage()
        {
        }

        public ServerSessionConstantsMessage(List<ServerSessionConstant> variables)
        {
            Variables = variables;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short) Variables.Count);
            for (var i = 0; i < Variables.Count; i++)
            {
                var objectToSend = Variables[i];
                writer.WriteShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            int length = reader.ReadUShort();
            Variables = new List<ServerSessionConstant>();
            for (var i = 0; i < length; i++)
            {
                var objectToAdd = new ServerSessionConstant(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Variables.Add(objectToAdd);
            }
        }
    }
}