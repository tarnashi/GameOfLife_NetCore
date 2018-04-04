using Core.Abstract;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Api
{
    public class GameApiController : BaseApiController
    {
        private readonly IGameService _gameService;
        public GameApiController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public JsonResult GetCurrentField()
        {
            Field field;
            field = HttpContext.Session.Get<Field>("Field");
            return SuccessJsonResponse(field);
        }

        [HttpPost]
        public JsonResult CreateField(int x, int y, bool isBordered)
        {
            Field field = _gameService.GetEmptyField(x, y, isBordered);
            HttpContext.Session.Set<Field>("Field", field);
            return SuccessJsonResponse(field);
        }
    }
}