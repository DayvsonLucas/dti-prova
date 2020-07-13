using System;
using System.Threading.Tasks;
using DTI.Api.Controllers.Base;
using DTI.Application.Interface;
using DTI.Application.ViewModels;
using DTI.Domain.Core.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTI.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : BaseController
    {
        private readonly IProductServices _product;
        public ProductController(INotificationHandler notification,
                                 IProductServices product) : base(notification)
        {
            _product = product;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel product)
        {
            if (!ModelState.IsValid) return Response(ModelState);

            var result = await _product.Add(product);

            if (!result) return Response();

            return Response(result);
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProductViewModel>> Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid) return Response(ModelState);

            var result = await _product.Update(product);

            if (!result) return Response();

            return Response(product);
        }

        [HttpGet("get-by-id/{productId:guid}")]
        public async Task<IActionResult> GetById(Guid productId)
        {
            var result = await _product.GetById(productId);
            return Response(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _product.GetAll();
            return Response(result);
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid productId)
        {
            var result = await _product.Remove(productId);

            if (!result) return Response();

            return Response("Produto excluido com sucesso!");
        }
    }
}