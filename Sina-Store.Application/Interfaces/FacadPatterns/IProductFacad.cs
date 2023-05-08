using Sina_Store.Application.Services.Products.Commands.AddNewCategory;
using Sina_Store.Application.Services.Products.Commands.AddNewProduct;
using Sina_Store.Application.Services.Products.Queries.GetAllCategories;
using Sina_Store.Application.Services.Products.Queries.GetCategories;
using Sina_Store.Application.Services.Products.Queries.GetProductDetailForAdmin;
using Sina_Store.Application.Services.Products.Queries.GetProductDetailForSite;
using Sina_Store.Application.Services.Products.Queries.GetProductForAdmin;
using Sina_Store.Application.Services.Products.Queries.GetProductForSite;

namespace Sina_Store.Application.Interfaces.FacadPatterns
{


    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        /// <summary>
        /// دریافت لیست محصولات
        /// </summary>
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}

