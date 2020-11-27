using Bll;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    public class InfractionTypesController : ApiController
    {

        #region Public Methods

        /// <summary>
        /// Añade un tipo de infracción
        /// </summary>
        /// <param name="infractiontype">Tipo de infracción</param>
        /// <returns></returns>
        public IHttpActionResult PostInfractionType (InfractionType infractiontype)
        {
            if (!ModelState.IsValid) {
                return BadRequest (ModelState);
            }
            try {
                new InfractionTypesLogic ().Add (infractiontype);
                return Ok ();
            } catch (Exception e) {
                return BadRequest (e.Message);
            }            
        }

        /// <summary>
        /// Obtiene los 5 tipos de infracciones más habituales
        /// </summary>
        /// <returns></returns>
        [ResponseType (typeof(IEnumerable<InfractionType>))]
        public IHttpActionResult GetUsuals ()
        {
            try {
                return Ok(new InfractionTypesLogic ().GetUsuals ());
            } catch (Exception e) {
                return BadRequest (e.Message);
            }            
        }

        #endregion

    }
}