using DAL;
using Entities;
using Logic;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MiCaseCodeGeneratorWebAPI.Controllers
{
    public abstract class BaseController<T> : ApiController where T : BaseEntity
    {
        protected ILogic<T> DecoratorLogic;

        public BaseController()
        {
            var dal = new DALFactory().Create<T>();
            var logic = new LogicFactory().Create<T>(dal);
        }

        [HttpGet]
        public virtual T Get(int id)
        {
            return DecoratorLogic.Get(id);
        }
    }
}
