using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BDPrueba.DataAccess;
using BDPrueba.Models;
using System.Text;
using System.Collections;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BDPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonasController : ControllerBase
    {
        private readonly PruebaContext _context;

        public ZonasController(PruebaContext context)
        {
            _context = context;
        }

        // GET: api/Zonas
        [HttpGet]

        public IActionResult GetZonas()
        {
            DateTime f = DateTime.Now;
            f = f.AddYears(-65);

            List<ConjuntoTable> result = (from d1 in _context.Personas
                                          join d2 in _context.Zonas on d1.CodZona equals d2.CodZona
                                          join d3 in _context.Sectors on d2.CodZona equals d3.CodSector
                                          where d1.FecNac > f
                                          select new ConjuntoTable
                                          {
                                              DesSector = d3.DesSector,
                                              CodZona = d2.CodZona,
                                              DesZona = d2.DesZona,
                                              Sueldo = d1.Sueldo
                                          }).ToList();
            //agrupacion y suma
            var res2 = result.GroupBy(l => l.DesZona).Select(cl => new ConjuntoTable
            {
                DesSector = cl.First().DesSector,//toma el primer valor solamente del grupo 
                CodZona = cl.First().CodZona,  
                DesZona = cl.First().DesZona,
                Sueldo = cl.Sum(c=> c.Sueldo)//suma
            });

            return Ok(res2);
        }
        /*public IActionResult GetZonas()
        {
            DateTime f = DateTime.Now;
            f = f.AddYears(-65);

            var tablaInit = (from d1 in _context.Personas
                             join d2 in _context.Zonas on d1.CodZona equals d2.CodZona
                             join d3 in _context.Sectors on d2.CodZona equals d3.CodSector
                             where d1.FecNac > f  
                             select new ConjuntoTable
                             {
                                 DesSector = d3.DesSector,
                                 CodZona  = d2.CodZona,
                                 DesZona = d2.DesZona,
                                 Sueldo = d1.Sueldo
                             }).ToList();

            

            var groupB = tablaInit.GroupBy(x => x.DesZona);
            

            return Ok(groupB);
        }*/

        // GET: api/Zonas/5
        [HttpGet("{id}")]
        public IEnumerable<Zona> GetZona(int id)
        {
             var resultado =  (from _zonaDesc in _context.Zonas
                                    join _secId in _context.Sectors on _zonaDesc.CodSector equals _secId.CodSector
                                    where _zonaDesc.CodSector == id
                                    select new Zona{
                                        CodZona = _zonaDesc.CodZona,
                                       DesZona = _zonaDesc.DesZona
                                    }).ToList();

            return resultado;
           
        }

        // PUT: api/Zonas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZona(int id, Zona zona)
        {
            if (id != zona.CodZona)
            {
                return BadRequest();
            }

            _context.Entry(zona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Zonas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Zona>> PostZona(Zona zona)
        {
            _context.Zonas.Add(zona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZona", new { id = zona.CodZona }, zona);
        }

        // DELETE: api/Zonas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZona(int id)
        {
            var zona = await _context.Zonas.FindAsync(id);
            if (zona == null)
            {
                return NotFound();
            }

            _context.Zonas.Remove(zona);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZonaExists(int id)
        {
            return _context.Zonas.Any(e => e.CodZona == id);
        }
    }
}
