using ExamFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ExamFront.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection con = new SqlConnection("server=localhost\\SQLEXPRESS; database=ACME; user=sauser ; password=sapassword");

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Realizar()
        {
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEncuestas()
        {
            List<Encuesta> data = new List<Encuesta>();

            //database query of all surveys and fields
            DataTable encuestadata = new DataTable();
            string consulta = "SELECT * FROM campos " +
                            "LEFT JOIN encuestas ON encuestas.id_encuesta = campos.id_encuesta " +
                            "ORDER BY encuestas.id_encuesta";

            SqlDataAdapter daencuesta = new SqlDataAdapter(consulta, con);
            daencuesta.Fill(encuestadata);

            if (encuestadata.Rows.Count > 0)
            {
                //set index to run through fields of the same survey
                int idindex = 0;
                Encuesta encuestaindex = new Encuesta();
                foreach (DataRow dr in encuestadata.Rows)
                {
                    if (idindex != int.Parse(dr["id_encuesta"].ToString()))
                    {
                        //if it´s a new survey index, create new survey object
                        idindex = int.Parse(dr["id_encuesta"].ToString());
                        encuestaindex = new Encuesta();
                        encuestaindex.id = idindex;
                        encuestaindex.nombre = dr["nombre1"].ToString();
                        encuestaindex.descripcion = dr["descripcion"].ToString();
                        encuestaindex.preguntas = new List<Pregunta>();
                        data.Add(encuestaindex);
                    }

                    Pregunta campo = new Pregunta();
                    campo.id = int.Parse(dr["id_campo"].ToString());
                    campo.nombre = dr["nombre"].ToString();
                    campo.requerido = int.Parse(dr["requerido"].ToString());
                    campo.tipo = int.Parse(dr["tipo"].ToString());
                    campo.titulo = dr["titulo"].ToString();
                    //add field to current survey
                    encuestaindex.preguntas.Add(campo);
                }
            }

            return Json(data);
        }

        [HttpPost]

        public ActionResult PostEncuestas(string survey)
        {
            Encuesta encuestainput = JsonConvert.DeserializeObject<Encuesta>(survey);
            string resultado = "";

            if (con.State != ConnectionState.Open) con.Open();
            //create survey in DB
            string consulta = "INSERT INTO ENCUESTAS (nombre,descripcion) "
                + "values ('" + encuestainput.nombre
                + "','" + encuestainput.descripcion + "');";
            
            SqlCommand cmd = new SqlCommand(consulta,con);
            cmd.ExecuteNonQuery();
            //get survey id from DB
            DataTable encuestaid = new DataTable();
            consulta = "select top (1) id_encuesta FROM encuestas ORDER BY id_encuesta DESC;";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            da.Fill(encuestaid);
            string id = "";
            if (encuestaid.Rows.Count > 0)
            {
                id = encuestaid.Rows[0]["id_encuesta"].ToString();
            }
            //add all fields
            consulta = "";
            foreach(Pregunta campo in encuestainput.preguntas)
            {
                consulta += "INSERT INTO campos (id_encuesta,nombre,titulo,requerido,tipo) "
                    + "VALUES ('" + id + "','" + campo.nombre
                    + "','" + campo.titulo
                    + "','" + campo.requerido
                    + "','" + campo.tipo + "');";
            }
            //execute query
            cmd = new SqlCommand(consulta,con);
            cmd.ExecuteNonQuery();

            con.Close();
            return Json(resultado);
        }

        [HttpPost]

        public ActionResult DelEncuestas(string id)
        {
            string resultado = "";

            if (con.State != ConnectionState.Open) con.Open();
            string consulta = "DELETE FROM campos WHERE id_encuesta='" + id + "';"
                + "DELETE FROM encuestas where id_encuesta='" + id + "';";
            SqlCommand cmd = new SqlCommand(consulta, con);
            cmd.ExecuteNonQuery();

            con.Close();

            return Json(resultado);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
