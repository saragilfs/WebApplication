using Dal;
using Model;

namespace Bll
{
    public class VehiclesLogic
    {

        #region Public Methods

        /// <summary>
        /// Añade un vehículo
        /// </summary>
        /// <param name="vehicle">Datos del vehículo</param>
        public void Add (Vehicle vehicle)
        {
            using (var db = new Context ()) {
                db.Vehicles.Add (vehicle);
                db.SaveChanges ();
            }
        }

        #endregion

    }
}
