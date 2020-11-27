using Bll;
using Model;
using System;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class DriversController : ApiController
    {

        #region Public Methods 

        /// <summary>
        /// Añade un conductor
        /// </summary>
        /// <param name="driver">Datos del conductor</param>
        /// <returns></returns>
        public IHttpActionResult PostDriver (Driver driver)
        {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            try {
                new DriversLogic ().Add (driver);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
            
        }

        #endregion

    }
}