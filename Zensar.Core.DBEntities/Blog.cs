using System.Collections.Generic;

namespace Zensar.Core.DBEntities
{
    public class Blog
    {

        public int ID { get; set; }
        /// <summary>
        /// Name - The Blog Name (required)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// SubTitle - The Blog Sub Title (not required)
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// ShortName - The Blog sub domain/subdirectory http://shortname.domain.tld or http://www.domain.tld/shortname (required)
        /// </summary>
        public string ShortName { get; set; }

        public List<Post> Posts { get; set; }

    }
}