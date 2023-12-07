using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDB
{
    internal class Group
    {
        public string Name { get; set; }

        public List<Person> People { get; set; } = new List<Person>();

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public static Group? Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<Group>(json);
        }
    }
}
