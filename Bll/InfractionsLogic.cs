using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bll
{
    public class InfractionsLogic
    {

        #region Public Methods

        /// <summary>
        /// Añade una infracción
        /// </summary>
        /// <param name="date">Fecha de la infracción</param>
        /// <param name="licenseplate">Matrícula</param>
        /// <param name="idcard">DNI conductor</param>
        /// <param name="infractiontype">Tipo de infracción</param>
        public void Add (DateTime date, string licenseplate, string idcard, int infractiontype)
        {
            using (var db = new Context ()) {

                var vehicle = db.Vehicles.FirstOrDefault (x => x.LicensePlate.Equals (licenseplate));
                if (vehicle == null) {
                    throw new Exception ("No existe el vehículo");
                }

                Driver driver = default;
                if (string.IsNullOrEmpty (idcard)) {
                    var drivers = db.UsualDrivers.Where (x => x.VehicleID == vehicle.VehicleID).ToList ();
                    if (drivers.Count () == 1) {
                        driver = drivers[0].Driver;
                    }
                } else {
                    driver = db.Drivers.FirstOrDefault (x => x.IdCard.Equals (idcard));
                }

                if (driver == null) {
                    throw new Exception ("No existe el conductor");
                }

                Infraction infraction = new Infraction {
                    Date = date,
                    VehicleID = vehicle.VehicleID,
                    DriverID = driver.DriverID,
                    InfractionTypeID = infractiontype
                };

                db.Infractions.Add (infraction);
                db.SaveChanges ();
            }
        }

        /// <summary>
        /// Obtiene las infracciones de un conductor en concreto
        /// </summary>
        /// <param name="idcard">DNI del conductor</param>
        /// <returns></returns>
        public IEnumerable<Infraction> GetInfractions (string idcard)
        {
            using (var db = new Context ()) {
                var driver = db.Drivers.FirstOrDefault (x => x.IdCard.Equals (idcard));

                if (driver == null) {
                    throw new Exception ("No existe el conductor");
                } else {
                    var result = new List<Infraction> ();
                    return db.Infractions.Where (x => x.DriverID == driver.DriverID).Include (e => e.Vehicle).Include (e => e.InfractionType).OrderBy (x => x.Date).ToList ();
                }
            }
        }

        #endregion

    }
}
