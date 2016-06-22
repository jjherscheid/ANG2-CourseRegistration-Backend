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
    public class CourseDto
    {

        [DataMember(Name = "id", IsRequired = false)]

        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CoursesController : ApiController
    {
        private static List<CourseDto> Courses = new List<CourseDto>
        {
            new CourseDto { Id= 1, Name= "Typescript Course"},
            new CourseDto { Id= 2, Name= "CSharp Course"},
            new CourseDto { Id= 3, Name= "Angular 1.x Course"},
            new CourseDto { Id= 4, Name= "Angular 2 Course"},
            new CourseDto { Id= 5, Name= "Java Course"},
            new CourseDto { Id= 6, Name= "Office 2015 Course"},
            new CourseDto { Id= 7, Name= "Fixing Cars Course" },
        };

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(Courses);
        }

        [HttpPost]
        public IHttpActionResult Post(CourseDto course)
        {
            var courseToAdd = new CourseDto() { Id = Courses.Max(c => c.Id) + 1, Name = course.Name };
            Courses.Add(courseToAdd);

            return Ok(courseToAdd);
        }

        [HttpPut]
        public IHttpActionResult Put([FromUri]int id, CourseDto course)
        {
            var courseToChange = Courses.Single(c => c.Id == id);
            courseToChange.Name = course.Name;

            return Ok(courseToChange);
        }
    }
}
