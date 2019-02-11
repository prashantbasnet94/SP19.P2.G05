using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SP19.P03.Web.Controllers
{
    // ~~~~~~~~~~~~~ dear 383 students, don't muck with this stuff - it isn't broken

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new[] { "value1", "value2" };
        }
    }

    [Route("api/DataContextTests")]
    [ApiController]
    public class DataContextTestsController : ControllerBase
    {
        private readonly IServiceProvider serviceCollection;

        public DataContextTestsController(IServiceProvider serviceCollection)
        {
            this.serviceCollection = serviceCollection;
        }

        [HttpGet]
        [Route("EnsureRegistered")]
        public ActionResult<IEnumerable<string>> EnsureRegistered()
        {
            GetDataContext();
            return ReportOk();
        }

        [HttpGet]
        [Route("EnsureSet/{modelName}")]
        public ActionResult<IEnumerable<string>> EnsureSet(string modelName)
        {
            var dataContext = GetDataContext();

            var subcollectionType = GetSubcollectionType(modelName);
            var method = dataContext.GetType().GetMethod("Set");
            var generic = method.MakeGenericMethod(subcollectionType);
            dynamic collection = generic.Invoke(dataContext, null);
            if (collection == null)
            {
                throw new Exception($"You don't have '{modelName}' in your data context");
            }

            Enumerable.ToList(collection);

            return ReportOk();
        }

        private static Type GetSubcollectionType(string modelName)
        {
            try
            {
                var subcollectionType = typeof(ValuesController).Assembly.GetTypes().Single(x => x.Name == modelName);
                return subcollectionType;
            }
            catch (Exception e)
            {
                throw new Exception($"You don't have '{modelName}' declared at all", e);
            }
        }

        private DbContext GetDataContext()
        {
            try
            {
                var type = typeof(ValuesController).Assembly.GetTypes().Single(x => x.IsSubclassOf(typeof(DbContext)));
                var dataContext = (DbContext)serviceCollection.GetService(type);
                return dataContext;
            }
            catch (Exception e)
            {
                throw new Exception("You don't have the DataContext setup and registered in asp.net core", e);
            }
        }

        private static ActionResult<IEnumerable<string>> ReportOk()
        {
            return new[] { "value1", "value2" };
        }
    }
}
