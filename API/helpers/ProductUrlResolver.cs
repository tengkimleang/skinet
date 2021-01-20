using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private readonly IConfiguration _iconfigure;
        public ProductUrlResolver(IConfiguration iconfigure)
        {
            _iconfigure = iconfigure;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)){
                return _iconfigure["ApiUrl"]+source.PictureUrl;
            }
            return null;
        }
    }
}