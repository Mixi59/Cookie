//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.Protocol.Network.Types.Game.House
{
    using System.Collections.Generic;
    using Cookie.Protocol.Network.Messages;
    using Cookie.Protocol.Network.Types;
    using Cookie.IO;
    
    
    public class HouseInformationsForGuild : HouseInformations
    {
        
        public new const short ProtocolId = 170;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private int m_instanceId;
        
        public virtual int InstanceId
        {
            get
            {
                return m_instanceId;
            }
            set
            {
                m_instanceId = value;
            }
        }
        
        private bool m_secondHand;
        
        public virtual bool SecondHand
        {
            get
            {
                return m_secondHand;
            }
            set
            {
                m_secondHand = value;
            }
        }
        
        private string m_ownerName;
        
        public virtual string OwnerName
        {
            get
            {
                return m_ownerName;
            }
            set
            {
                m_ownerName = value;
            }
        }
        
        private short m_worldX;
        
        public virtual short WorldX
        {
            get
            {
                return m_worldX;
            }
            set
            {
                m_worldX = value;
            }
        }
        
        private short m_worldY;
        
        public virtual short WorldY
        {
            get
            {
                return m_worldY;
            }
            set
            {
                m_worldY = value;
            }
        }
        
        private int m_mapId;
        
        public virtual int MapId
        {
            get
            {
                return m_mapId;
            }
            set
            {
                m_mapId = value;
            }
        }
        
        private ushort m_subAreaId;
        
        public virtual ushort SubAreaId
        {
            get
            {
                return m_subAreaId;
            }
            set
            {
                m_subAreaId = value;
            }
        }

        private List<int> m_skillListIds;

        public virtual List<int> SkillListIds
        {
            get
            {
                return m_skillListIds;
            }
            set
            {
                m_skillListIds = value;
            }
        }

        private uint m_guildshareParams;
        
        public virtual uint GuildshareParams
        {
            get
            {
                return m_guildshareParams;
            }
            set
            {
                m_guildshareParams = value;
            }
        }
        
        public HouseInformationsForGuild(List<System.Int32> skillListIds, int instanceId, bool secondHand, string ownerName, short worldX, short worldY, int mapId, ushort subAreaId, uint guildshareParams)
        {
            m_skillListIds = skillListIds;
            m_instanceId = instanceId;
            m_secondHand = secondHand;
            m_ownerName = ownerName;
            m_worldX = worldX;
            m_worldY = worldY;
            m_mapId = mapId;
            m_subAreaId = subAreaId;
            m_guildshareParams = guildshareParams;
        }
        
        public HouseInformationsForGuild()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(m_instanceId);
            writer.WriteBoolean(m_secondHand);
            writer.WriteUTF(m_ownerName);
            writer.WriteShort(m_worldX);
            writer.WriteShort(m_worldY);
            writer.WriteInt(m_mapId);
            writer.WriteVarUhShort(m_subAreaId);
            writer.WriteShort(((short)(m_skillListIds.Count)));
            int skillListIdsIndex;
            for (skillListIdsIndex = 0; (skillListIdsIndex < m_skillListIds.Count); skillListIdsIndex = (skillListIdsIndex + 1))
            {
                writer.WriteInt(m_skillListIds[skillListIdsIndex]);
            }
            writer.WriteVarUhInt(m_guildshareParams);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            m_instanceId = reader.ReadInt();
            m_secondHand = reader.ReadBoolean();
            m_ownerName = reader.ReadUTF();
            m_worldX = reader.ReadShort();
            m_worldY = reader.ReadShort();
            m_mapId = reader.ReadInt();
            m_subAreaId = reader.ReadVarUhShort();
            int skillListIdsCount = reader.ReadUShort();
            int skillListIdsIndex;
            m_skillListIds = new System.Collections.Generic.List<int>();
            for (skillListIdsIndex = 0; (skillListIdsIndex < skillListIdsCount); skillListIdsIndex = (skillListIdsIndex + 1))
            {
                m_skillListIds.Add(reader.ReadInt());
            }   
            m_guildshareParams = reader.ReadVarUhInt();
        }
    }
}
