using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using System.Web.Mvc;
using WebModel;

namespace WebAPI.Controllers
{
    public class StaffController : ApiController
    {
        StaffDBContext db = new StaffDBContext();

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var staffs = db.Staffs.ToList();
                return Ok(staffs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var staff = db.Staffs.Find(id);
                if (staff == null) return BadRequest("User With id " + id + " Not Found");
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Post([FromBody] Staff staffobj)
        {
            try
            {
                db.Staffs.Add(staffobj);
                db.SaveChanges();
                return Created(Request.RequestUri, staffobj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult Put([FromBody] Staff staffobj)
        {
            try
            {
                db.Staffs.AddOrUpdate(staffobj);
                db.SaveChanges();
                return Ok(staffobj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var staff = db.Staffs.Find(id);
                if (staff == null) return BadRequest("User Not Found");
                db.Staffs.Remove(staff);
                db.SaveChanges();
                return Ok(staff);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
