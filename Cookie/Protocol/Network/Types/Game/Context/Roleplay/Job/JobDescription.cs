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

namespace Cookie.Protocol.Network.Types.Game.Context.Roleplay.Job
{
    using Cookie.IO;
    using Cookie.Protocol.Network.Types.Game.Interactive.Skill;
    using System.Collections.Generic;


    public class JobDescription : NetworkType
    {
        
        public const short ProtocolId = 101;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<SkillActionDescription> m_skills;
        
        public virtual List<SkillActionDescription> Skills
        {
            get
            {
                return m_skills;
            }
            set
            {
                m_skills = value;
            }
        }
        
        private byte m_jobId;
        
        public virtual byte JobId
        {
            get
            {
                return m_jobId;
            }
            set
            {
                m_jobId = value;
            }
        }
        
        public JobDescription(List<SkillActionDescription> skills, byte jobId)
        {
            m_skills = skills;
            m_jobId = jobId;
        }
        
        public JobDescription()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(m_jobId);
            writer.WriteShort((short) m_skills.Count);
            for (var i = 0; i < m_skills.Count; i++)
            {
                writer.WriteShort((m_skills[i].TypeID));
                m_skills[i].Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_skills = new List<SkillActionDescription>();
            var loc4 = 0;
            m_jobId = reader.ReadByte();
            var loc2 = reader.ReadUShort();
            for (var i = 0; i < loc2; i++)
            {
                loc4 = reader.ReadUShort();
                var loc5 = ProtocolTypeManager.GetInstance<SkillActionDescription>((short) loc4);
                loc5.Deserialize(reader);
                m_skills.Add(loc5);
            }
        }
    }
}
