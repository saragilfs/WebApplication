using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class VehiclesController : ApiController
    {

        #region Public Methods

        /// <summary>
        /// Añade un vehículo
        /// </summary>
        /// <param name="vehicle">Datos del vehículo</param>
        /// <returns></returns>
        public IHttpActionResult PostVehicle (Vehicle vehicle)
        {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            try {
                new VehiclesLogic ().Add (vehicle);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }            
        }

        #endregion
    }
}