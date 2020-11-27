using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    public class InfractionsController : ApiController
    {
        #region Public Methods

        /// <summary>
        /// Añade una infracción
        /// </summary>
        /// <param name="date">Fecha de la infracción</param>
        /// <param name="licenseplate">Matrícula</param>
        /// <param name="idcard">DNI conductor</param>
        /// <param name="infractiontype">Tipo de infracción</param>
        public IHttpActionResult PostInfraction (DateTime infractiondate, string licenseplate, string idcard, int infractiontype)
        {
            try {
                new InfractionsLogic ().Add (infractiondate, licenseplate, idcard, infractiontype);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        /// <summary>
        /// Obtiene las infracciones de un conductor
        /// </summary>
        /// <param name="idcard">DNI del conductor</param>
        /// <returns></returns>
        [ResponseType (typeof (IEnumerable<Infraction>))]
        public IHttpActionResult GetInfractions (string idcard)
        {
            try {
                return Ok (new InfractionsLogic ().GetInfractions (idcard));
            } catch (Exception e) {
                return BadRequest (e.Message);
            }
        }

        #endregion

    }
}