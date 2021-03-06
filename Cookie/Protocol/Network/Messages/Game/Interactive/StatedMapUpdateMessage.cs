//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.Protocol.Network.Messages.Game.Interactive
{
    using Cookie.Protocol.Network.Types.Game.Interactive;
    using System.Collections.Generic;
    using Cookie.Protocol.Network.Messages;
    using Cookie.Protocol.Network.Types;
    using Cookie.IO;
    
    
    public class StatedMapUpdateMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5716;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<StatedElement> m_statedElements;
        
        public virtual List<StatedElement> StatedElements
        {
            get
            {
                return m_statedElements;
            }
            set
            {
                m_statedElements = value;
            }
        }
        
        public StatedMapUpdateMessage(List<StatedElement> statedElements)
        {
            m_statedElements = statedElements;
        }
        
        public StatedMapUpdateMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_statedElements.Count)));
            int statedElementsIndex;
            for (statedElementsIndex = 0; (statedElementsIndex < m_statedElements.Count); statedElementsIndex = (statedElementsIndex + 1))
            {
                StatedElement objectToSend = m_statedElements[statedElementsIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            int statedElementsCount = reader.ReadUShort();
            int statedElementsIndex;
            m_statedElements = new System.Collections.Generic.List<StatedElement>();
            for (statedElementsIndex = 0; (statedElementsIndex < statedElementsCount); statedElementsIndex = (statedElementsIndex + 1))
            {
                StatedElement objectToAdd = new StatedElement();
                objectToAdd.Deserialize(reader);
                m_statedElements.Add(objectToAdd);
            }
        }
    }
}
