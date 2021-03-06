//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Cookie.Network;

namespace Cookie.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Cookie.IO;
    using Cookie.Protocol.Network.Types.Game.Context.Fight;
    using System.Collections.Generic;


    public class MapRunningFightDetailsMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5751;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<GameFightFighterLightInformations> m_attackers;
        
        public virtual List<GameFightFighterLightInformations> Attackers
        {
            get
            {
                return m_attackers;
            }
            set
            {
                m_attackers = value;
            }
        }
        
        private List<GameFightFighterLightInformations> m_defenders;
        
        public virtual List<GameFightFighterLightInformations> Defenders
        {
            get
            {
                return m_defenders;
            }
            set
            {
                m_defenders = value;
            }
        }
        
        private int m_fightId;
        
        public virtual int FightId
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
        
        public MapRunningFightDetailsMessage(List<GameFightFighterLightInformations> attackers, List<GameFightFighterLightInformations> defenders, int fightId)
        {
            m_attackers = attackers;
            m_defenders = defenders;
            m_fightId = fightId;
        }
        
        public MapRunningFightDetailsMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_attackers.Count)));
            int attackersIndex;
            for (attackersIndex = 0; (attackersIndex < m_attackers.Count); attackersIndex = (attackersIndex + 1))
            {
                GameFightFighterLightInformations objectToSend = m_attackers[attackersIndex];
                writer.WriteUShort(((ushort)(objectToSend.TypeID)));
                objectToSend.Serialize(writer);
            }
            writer.WriteShort(((short)(m_defenders.Count)));
            int defendersIndex;
            for (defendersIndex = 0; (defendersIndex < m_defenders.Count); defendersIndex = (defendersIndex + 1))
            {
                GameFightFighterLightInformations objectToSend = m_defenders[defendersIndex];
                writer.WriteUShort(((ushort)(objectToSend.TypeID)));
                objectToSend.Serialize(writer);
            }
            writer.WriteInt(m_fightId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            int attackersCount = reader.ReadUShort();
            int attackersIndex;
            m_attackers = new System.Collections.Generic.List<GameFightFighterLightInformations>();
            for (attackersIndex = 0; (attackersIndex < attackersCount); attackersIndex = (attackersIndex + 1))
            {
                GameFightFighterLightInformations objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>((short)reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                m_attackers.Add(objectToAdd);
            }
            int defendersCount = reader.ReadUShort();
            int defendersIndex;
            m_defenders = new System.Collections.Generic.List<GameFightFighterLightInformations>();
            for (defendersIndex = 0; (defendersIndex < defendersCount); defendersIndex = (defendersIndex + 1))
            {
                GameFightFighterLightInformations objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>((short)reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                m_defenders.Add(objectToAdd);
            }
            m_fightId = reader.ReadInt();
        }
    }
}
