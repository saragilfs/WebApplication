using Dal;
using Model;
using System;
using System.Linq;

namespace Bll
{
    public class UsualDriversLogic
    {

        #region Public Methods

        /// <summary>
        /// Añade un conductor habitual a un vehículo
        /// </summary>
        /// <param name="idcard">DNI del conductor</param>
        /// <param name="licenseplate">Matrícula del vehículo</param>
        public void Add (string idcard, string licenseplate)
        {
            using (var db = new Context ()) {
                var vehicle = db.Vehicles.FirstOrDefault (x => x.LicensePlate.Equals (licenseplate));
                if (vehicle == null) {
                    throw new Exception ("No existe el vehículo");
                } else {
                    var driver = db.Drivers.FirstOrDefault (x => x.IdCard.Equals (idcard));
                    if (driver == null) {
                        throw new Exception ("No existe el conductor");
                    } else {
                        var vehicles = db.UsualDrivers.Where (x => x.DriverID == driver.DriverID).Count ();
                        if (vehicles <= 4) {
                            UsualDriver usualdriver = new UsualDriver {
                                VehicleID = vehicle.VehicleID,
                                DriverID = driver.DriverID
                            };
                            db.UsualDrivers.Add (usualdriver);
                            db.SaveChanges ();
                        } else {
                            throw new Exception ("El conductor ya es el conductor habitual de 5 vehículos");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Elimina un conductor habitual
        /// </summary>
        /// <param name="id">Registro a eliminar</param>
        public void Remove (int id)
        {
            using (var db = new Context ()) {
                var vehicle = db.UsualDrivers.Find (id);
                db.UsualDrivers.Remove (vehicle);
                db.SaveChanges ();
            }
        }

        #endregion
    }
}
