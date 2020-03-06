using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class CategoryRepository : RepositoryGeneric<Category>, IRepositoryGeneric<Category>
    {
        public CategoryRepository(MovieDbContext context) : base(context)
        {
        }
    }
}
