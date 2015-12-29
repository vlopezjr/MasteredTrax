﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MasteredTrax.Models;
using System.Net;

namespace MasteredTrax.Controllers.Api
{
    [Route("api/[controller]")]
    public class ArtistController : Controller
    {
        private IArtistRepository _repository;

        public ArtistController(IArtistRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            var results = _repository.GetAll();

            return Json(results);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]Artist artist)
        {
            try {
                if (ModelState.IsValid)
                {
                    _repository.Add(artist);
                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(artist);
                    }
                }
            }
            catch(Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
