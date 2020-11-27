using Bll;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    public class PointsController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// Obtiene los puntos de un conductor
        /// </summary>
        /// <param name="idcard">DNI del conductor</param>
        /// <returns></returns>        
        [ResponseType (typeof (int))]
        public IHttpActionResult GetPoints (string idcard)
        {
            try {                
                return Ok (new DriversLogic ().GetPoints (idcard));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }            
        }

        #endregion
    }
}