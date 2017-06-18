//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.Protocol.Network.Types.Game.Context.Fight
{
    using System.Collections.Generic;
    using Cookie.Protocol.Network.Messages;
    using Cookie.Protocol.Network.Types;
    using Cookie.IO;
    
    
    public class GameFightSpellCooldown : NetworkType
    {
        
        public const short ProtocolId = 205;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private int m_spellId;
        
        public virtual int SpellId
        {
            get
            {
                return m_spellId;
            }
            set
            {
                m_spellId = value;
            }
        }
        
        private byte m_cooldown;
        
        public virtual byte Cooldown
        {
            get
            {
                return m_cooldown;
            }
            set
            {
                m_cooldown = value;
            }
        }
        
        public GameFightSpellCooldown(int spellId, byte cooldown)
        {
            m_spellId = spellId;
            m_cooldown = cooldown;
        }
        
        public GameFightSpellCooldown()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(m_spellId);
            writer.WriteByte(m_cooldown);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_spellId = reader.ReadInt();
            m_cooldown = reader.ReadByte();
        }
    }
}