// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SpeakingItemsTriggers")]
    public class SpeakingItemsTrigger : IDataObject
    {
        public const string MODULE = "SpeakingItemsTriggers";
        public List<int> States;
        public List<int> TextIds;
        public int TriggersId;
    }
}