using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ANG2_CourseRegistration_Backend.Controllers
{
    [DataContract]
    public class CourseDto {

        [DataMember(Name="id")]
        public int Id { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CoursesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var courses = new List<CourseDto>()
            {
                new CourseDto { Id = 1, Name = "JohansTest" },
                new CourseDto { Id = 2, Name = "PaulsTest" },
            };

            return Ok(courses);
        }
    }
}
