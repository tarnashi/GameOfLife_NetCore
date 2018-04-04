using Core.Abstract;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Extensions;

namespace Web.Api
{
    [Route("api/game/[action]/{id?}")]
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
            Field field = GetFieldFromSession();
            return SuccessJsonResponse(field);
        }

        [HttpPost]
        public JsonResult CreateField(int x, int y, bool isBordered)
        {
            Field field = _gameService.GetEmptyField(x, y, isBordered);
            HttpContext.Session.Set<Field>("Field", field);
            HttpContext.Session.SetString("FieldType", (field.isBordered) ? "bordered" : "loopback");
            return SuccessJsonResponse(field);
        }

        [HttpGet]
        public JsonResult ClearField()
        {
            Field field = GetFieldFromSession();
            field.Clear();
            HttpContext.Session.Set<Field>("Field", field);
            return SuccessJsonResponse(field);
        }

        [HttpGet]
        public JsonResult GetPlaner()
        {
            Field field = GetFieldFromSession();
            if (field.Width < 3 || field.Height < 3)
            {
                return FailJsonResponse("Поле слишком маленькое :(");
            }
            field.SetPlaner();
            HttpContext.Session.Set<Field>("Field", field);
            return SuccessJsonResponse(field);
        }

        [HttpPost]
        public JsonResult ChangeCell(int x, int y)
        {
            Field field = GetFieldFromSession();
            field.ChangeCell(x, y);
            HttpContext.Session.Set<Field>("Field", field);
            return SuccessJsonResponse(field);
        }

        [HttpGet]
        public JsonResult MakeMove()
        {
            Field field = GetFieldFromSession();
            field.MakeMove();
            HttpContext.Session.Set<Field>("Field", field);
            return SuccessJsonResponse(field);
        }

        #region private
        private Field GetFieldFromSession()
        {
            Field result = null;
            var fieldType = HttpContext.Session.GetString("FieldType");
            if (fieldType == "bordered")
                result = HttpContext.Session.Get<BorderedField>("Field");
            else if (fieldType == "loopback")
                result = HttpContext.Session.Get<LoopbackField>("Field");
            return result;
        }
        #endregion
    }
}