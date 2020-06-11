using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;

class ProductService
{
    private readonly DataContext _context;

public ProductService(DataContext context)
{
_context = context;
}

public ProductDO Insert(ProductDO product)
{
_context.Set<ProductDO>() .Add(product);
_context.SaveChanges();
return
product;
}
}
