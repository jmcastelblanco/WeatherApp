using System;
using System.Linq;
using WeatherA.Models;

namespace WeatherA.Class
{
    public class InstallHelper : IDisposable
    {
        private static WeatherAContext db = new WeatherAContext();

        public static void InitialConfiguration()
        {
            AddParameters();
            insSuperadmin();
            AddAlertTypes();
            AddStates();
        }
        public static void AddStates()
        {
            var consulta = db.States.Count();
            if (consulta < 1)
            {
                var state = new State()
                {
                    Name = "New",
                };
                db.States.Add(state);
                state = new State()
                {
                    Name = "Fix",
                };
                db.States.Add(state);
                state = new State()
                {
                    Name = "End",
                };
                db.States.Add(state);
                db.SaveChanges();
            }
        }
        public static void AddAlertTypes()
        {
            var consulta = db.AlertTypes.Count();
            if (consulta < 1)
            {
                var alertType = new AlertType()
                {
                    Description = "CafeIssue",
                };
                db.AlertTypes.Add(alertType);
                db.SaveChanges();
            }
        }
        public static void AddParameters()
        {
            var consulta = db.Parameters.Count();
            if (consulta < 1)
            {
                insParameter("APIKey"
                    , "be06c9df19a94dd986c9df19a92dd9ea"
                    , "API Key de Weather Services");
                insParameter("TimeInterval"
                    , "2"
                    , "Tiempo en minutos para el intervalo en que se ejecuta el servicio windows");
                insParameter("StationID"
                    , "ISANJU36"
                    , "ID de estación");
                insParameter("Units"
                    , "h"
                    , "Unidad de medida para mostrar la data");
                insParameter("humidityMax"
                    , "100"
                    , "Parametro de humedad máximo");
                insParameter("humidityMin"
                    , "30"
                    , "Parametro de humedad minimo");
                insParameter("precipMax"
                    , "60"
                    , "Parametro de precipitación máximo");
                insParameter("precipMin"
                    , "0"
                    , "Parametro de precipitación minimo");
                insParameter("tempMax"
                    , "40"
                    , "Parametro de temperatura máximo");
                insParameter("tempMin"
                    , "10"
                    , "Parametro de temperatura minimo");
                db.SaveChanges();
            }
        }
        public static void insParameter(string codParam, string value, string description)
        {
            var parameter = new Parameters
            {
                CodParam = codParam,
                Value1 = value,
                Description = description,
            };
            db.Parameters.Add(parameter);
            db.SaveChanges();
        }
        public static void InsRol(String rolName)
        {
            var rol = new Rol
            {
                Name = rolName,
            };
            db.Roles.Add(rol);
            db.SaveChanges();
        }
        public static void insSuperadmin()
        {
            var empresaCount = db.Roles.Count();
            if (empresaCount < 1)
            {

                InsRol("SuperAdmin");
                InsRol("Admin");
            }
            empresaCount = db.Users.Count();
            if (empresaCount < 1)
            {
                var user = new User
                {
                    FirstName = "Pablo",
                    SecondName = "Andrés",
                    Phone = "3122683980",
                    Address = "Unknown",
                    CountryID = 1,
                    DocumentTypeID = 1,
                    DocumentNumber = "13088512",
                    DepartmentID = 21,
                    CityID = 801,
                    LastName = "Gómez",
                    RolID = 1,
                    UserName = "soidneo@gmail.com",
                    password = "123456",

                };
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}