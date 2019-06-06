using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessEntities
{
    public class CategoryEntity
    {
        public CategoryEntity()
        {

        }
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool EnableORDisable { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}
