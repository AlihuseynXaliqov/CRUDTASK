﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<BlogsCategories> BlogsCategories { get; set; }

    }
}
