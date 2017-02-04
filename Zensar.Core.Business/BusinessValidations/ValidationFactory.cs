using System;
using Zensar.Core.Business.Interface;
using Zensar.Core.DBEntities;

namespace Zensar.Core.Business.BusinessValidations
{
   public static class ValidationFactory
    {
       public static IValidator GetValidator<T>(T entity) where T : class
       {
           var type = typeof (T).Name;

           switch (type)
           {
               case "Blog":
                   return new BlogValidator {blog = entity as Blog};

               default: return null;
           }
       }
    }

   public class BlogValidator : IValidator
   {
       public Blog blog;

       public bool Validate()
       {
           throw new NotImplementedException();
       }
   }
    
}
