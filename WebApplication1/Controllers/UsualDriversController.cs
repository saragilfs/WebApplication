using Bll;
using System;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class UsualDriversController : ApiController
    {

        #region Public Methods

        /// <summary>
        /// Añade un conductor habitual a un vehículo
        /// </summary>
        /// <param name="idcard">DNI del conductor</param>
        /// <param name="licenseplate">Matrícula del vehículo</param>
        /// <returns></returns>
        public IHttpActionResult PostUsualDriver (string idcard, string licenseplate)
        {
            try {
                new UsualDriversLogic ().Add (idcard, licenseplate);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }            
        }

        /// <summary>
        /// Elimina un conductor habitual
        /// </summary>
        /// <param name="id">Id del registro</param>
        /// <returns></returns>
        public IHttpActionResult DeleteUsualDriver (int id)
        {
            try {
                new UsualDriversLogic ().Remove (id);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }            
        }

        #endregion 
    }
}