using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[controller"]) でも同じ結果が得られるが、下記のようなハードコーディグの方がミスが少ない
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()  //show All Villas
        {
            return Ok(VillaStore.villaList);
        }

        [HttpGet("{id:int}")]
        //[ProducesResponseType(200, Type=typeof(VillaDTO)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> GetVilla(int id)   // show Villa by id
        {
            if (id == 0)
            {
                return BadRequest();   // 400 Error
            }

            var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound(); //404 error
            }
            return Ok(villa);
        }

    }
}
