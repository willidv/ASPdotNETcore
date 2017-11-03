using System.Collections.Generic;
using rapi;
using MusicApi;

namespace JsonData {
    public class Group {
        public Group() {
            Members = new List<Artist>();
        }
        public int Id;
        public string GroupName;
        public List<Artist> Members;
    }
}