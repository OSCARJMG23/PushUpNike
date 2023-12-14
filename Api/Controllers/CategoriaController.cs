using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{

    public class CategoriaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
        {
            var Categoria = await _unitOfWork.Categorias.GetAllAsync();
            return _mapper.Map<List<CategoriaDto>>(Categoria);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Get(int id)
        {
            var Categoria = await _unitOfWork.Categorias.GetByIdAsync(id);
            return _mapper.Map<CategoriaDto>(Categoria);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Categoria>> Post(CategoriaDto CategoriaDto)
        {
            var Categoria = _mapper.Map<Categoria>(CategoriaDto);
            _unitOfWork.Categorias.Add(Categoria);
            await _unitOfWork.SaveAsync();

            if (Categoria == null)
            {
                return BadRequest();
            }

            Categoria.Id = Categoria.Id;
            return CreatedAtAction(nameof(Post), new { id = Categoria.Id }, Categoria);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Put(int id, [FromBody]CategoriaDto CategoriaDto)
        {
            if (CategoriaDto == null)
            {
                return NotFound();
            }

            var Categoria = _mapper.Map<Categoria>(CategoriaDto);
            _unitOfWork.Categorias.Update(Categoria);
            await _unitOfWork.SaveAsync();
            return CategoriaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Delete(int id)
        {
            var Categoria = await _unitOfWork.Categorias.GetByIdAsync(id);

            if (Categoria == null)
            {
                return NotFound();
            }

            _unitOfWork.Categorias.Remove(Categoria);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}