using Dal;
using Model;
using System;
using System.Linq;

namespace Bll
{
    public class DriversLogic
    {

        #region Public Methods

        /// <summary>
        /// Añade un conductor
        /// </summary>
        /// <param name="driver">Datos del conductor</param>
        public void Add (Driver driver)
        {
            using (var db = new Context ()) {
                db.Drivers.Add (driver);
                db.SaveChanges ();
            }
        }                

        /// <summary>
        /// Obtiene los puntos de un conductor
        /// </summary>
        /// <param name="idcard">DNI del conductor</param>
        /// <returns></returns>
        public int GetPoints (string idcard)
        {
            using (var db = new Context ()) {
                var driver = db.Drivers.FirstOrDefault (x => x.IdCard.Equals (idcard));
                if (driver == null) {
                    throw new Exception ("El conductor no existe");
                } else {
                    var points = driver.Points;
                    var infractions = db.Infractions.Where (x => x.DriverID == driver.DriverID).ToList ();
                    foreach (var infraction in infractions) {
                        points -= infraction.InfractionType.Points;
                    }
                    return points;
                }
            }
        }

        #endregion

    }
}
