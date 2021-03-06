//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.Protocol.Network.Messages.Game.Context.Fight
{
    using System.Collections.Generic;
    using Cookie.Protocol.Network.Messages;
    using Cookie.Protocol.Network.Types;
    using Cookie.IO;
    
    
    public class GameFightOptionStateUpdateMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5927;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private short m_fightId;
        
        public virtual short FightId
        {
            get
            {
                return m_fightId;
            }
            set
            {
                m_fightId = value;
            }
        }
        
        private byte m_teamId;
        
        public virtual byte TeamId
        {
            get
            {
                return m_teamId;
            }
            set
            {
                m_teamId = value;
            }
        }
        
        private byte m_option;
        
        public virtual byte Option
        {
            get
            {
                return m_option;
            }
            set
            {
                m_option = value;
            }
        }
        
        private bool m_state;
        
        public virtual bool State
        {
            get
            {
                return m_state;
            }
            set
            {
                m_state = value;
            }
        }
        
        public GameFightOptionStateUpdateMessage(short fightId, byte teamId, byte option, bool state)
        {
            m_fightId = fightId;
            m_teamId = teamId;
            m_option = option;
            m_state = state;
        }
        
        public GameFightOptionStateUpdateMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(m_fightId);
            writer.WriteByte(m_teamId);
            writer.WriteByte(m_option);
            writer.WriteBoolean(m_state);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_fightId = reader.ReadShort();
            m_teamId = reader.ReadByte();
            m_option = reader.ReadByte();
            m_state = reader.ReadBoolean();
        }
    }
}
