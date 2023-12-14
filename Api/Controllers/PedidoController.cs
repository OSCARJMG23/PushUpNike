using Api.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers
{

    public class PedidoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<PedidoDto>>> Get()
        {
            var Pedido = await _unitOfWork.Pedidos.GetAllAsync();
            return _mapper.Map<List<PedidoDto>>(Pedido);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PedidoDto>> Get(int id)
        {
            var Pedido = await _unitOfWork.Pedidos.GetByIdAsync(id);
            return _mapper.Map<PedidoDto>(Pedido);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pedido>> Post(PedidoDto PedidoDto)
        {
            var Pedido = _mapper.Map<Pedido>(PedidoDto);
            _unitOfWork.Pedidos.Add(Pedido);
            await _unitOfWork.SaveAsync();

            if (Pedido == null)
            {
                return BadRequest();
            }

            Pedido.Id = Pedido.Id;
            return CreatedAtAction(nameof(Post), new { id = Pedido.Id }, Pedido);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PedidoDto>> Put(int id, [FromBody]PedidoDto PedidoDto)
        {
            if (PedidoDto == null)
            {
                return NotFound();
            }

            var Pedido = _mapper.Map<Pedido>(PedidoDto);
            _unitOfWork.Pedidos.Update(Pedido);
            await _unitOfWork.SaveAsync();
            return PedidoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PedidoDto>> Delete(int id)
        {
            var Pedido = await _unitOfWork.Pedidos.GetByIdAsync(id);

            if (Pedido == null)
            {
                return NotFound();
            }

            _unitOfWork.Pedidos.Remove(Pedido);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}