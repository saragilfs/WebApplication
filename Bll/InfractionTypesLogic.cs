using Dal;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace Bll
{
    public class InfractionTypesLogic
    {
        #region Public Methods

        /// <summary>
        /// Añade un tipo de infracción
        /// </summary>
        /// <param name="infractiontype"></param>
        public void Add (InfractionType infractiontype)
        {
            using (var db = new Context ()) {
                db.InfractionTypes.Add (infractiontype);
                db.SaveChanges ();
            }
        }

        /// <summary>
        /// Obtiene las 5 infracciones más usuales
        /// </summary>
        /// <returns></returns>
        public IEnumerable<InfractionType> GetUsuals ()
        {
            using (var db = new Context ()) {
                var infractions = db.Infractions.GroupBy (x => x.InfractionTypeID).OrderByDescending (g => g.Count ()).Take (5).Select (g => g.Key).ToList ();
                var result = new List<InfractionType> ();
                foreach (var infraction in infractions) {
                    result.Add (db.InfractionTypes.Find (infraction));
                }
                return result;
            }
        }

        #endregion

    }
}
