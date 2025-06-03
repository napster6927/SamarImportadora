using AutoMapper;
using SamarImportadora.Core.DTOs;
using SamarImportadora.Core.Entities;
using SamarImportadora.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarImportadora.Infrastructure.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly IArticuloRepository _articuloRepository;
        private readonly IMapper _mapper;
        public ArticuloService(IArticuloRepository articuloRepository, IMapper mapper)
        {
            _articuloRepository = articuloRepository;
            _mapper = mapper;
        }

        public async Task<Core.Entities.Articulo?> GetByCodigoProducto(string codigo_producto)
        {
            return await _articuloRepository.GetByCodigoProductoAsync(codigo_producto);
        }
        public async Task<bool> UpdateArticuloAsync(string codigo_producto, Core.DTOs.ArticuloDto articuloDto)
        {
            var articuloExistente = await _articuloRepository.GetByCodigoProductoAsync(codigo_producto);
            if (articuloExistente == null) return false;


            _mapper.Map(articuloDto, articuloExistente);


            return await _articuloRepository.UpdateArticuloAsync(articuloExistente);
        }
    }
} // Fin del namespace SamarImportadora.Infrastructure.Services