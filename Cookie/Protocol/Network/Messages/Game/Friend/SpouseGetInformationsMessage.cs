﻿using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Game.Friend
{
    public class SpouseGetInformationsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6355;

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            //
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            //
        }
    }
}