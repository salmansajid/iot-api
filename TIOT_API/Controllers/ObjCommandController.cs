
using BusinessEntities;
using BusinessServices.ObjCommandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api.Controllers
{
    public class ObjCommandController : ApiController
    {

        private readonly IObjCommandServices _ObjCommandServices;

        public ObjCommandController()
        {
            _ObjCommandServices = new ObjCommandServices();
        }


        // POST api/
        public int Post([FromBody]ObjCommandEntity _objCommandEntity)
        {
            return _ObjCommandServices.CreateObjCommand(_objCommandEntity);
        }

    }
}
