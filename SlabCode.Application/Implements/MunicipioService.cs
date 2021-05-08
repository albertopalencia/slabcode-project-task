namespace PruebaTecnica.Application.Implements
{
	using Microsoft.Extensions.Options;
	using PruebaTecnica.Application.Abstract;
	using PruebaTecnica.Application.DTO.Municipio;
	using PruebaTecnica.Domain.Entities;
	using PruebaTecnica.Infrastructure.Interfaces;
	using PruebaTecnica.Infrastructure.Options;
	using PruebaTecnica.Infrastructure.Pages;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	public class MunicipioService : IMunicipioService
	{
		private readonly IUnitOfWork _unityWork;

		private readonly PaginacionOpcion _paginacionOpcion;

		public MunicipioService(IUnitOfWork unityWork, IOptions<PaginacionOpcion> options)
		{
			_unityWork = unityWork;
			_paginacionOpcion = options.Value;
		}

		public async Task<bool> Actualizar(Municipio municipio)
		{
			_unityWork.MunicipioRepository.Update(municipio); 
			await Task.CompletedTask;
			return true;
		}

		public async Task<Municipio> BuscarPorId(int id)
		{
			return await _unityWork.MunicipioRepository.BuscarPorId(id);
		}

		public async Task<bool> Crear(Municipio municipio)
		{
			_unityWork.MunicipioRepository.Add(municipio);
			await _unityWork.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Eliminar(int municipioId)
		{
			var municipio = await _unityWork.MunicipioRepository.FirstOrDefaultAsync(m => m.Id == municipioId);
			_unityWork.MunicipioRepository.Remove(municipio);
			await _unityWork.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Municipio>> Listar()
		{
			return await _unityWork.MunicipioRepository.Listado();
		}

		public async Task<PagedList<Municipio>> Listar(FiltroConsultaDto filtro)
		{
			filtro.PageNumber = filtro.PageNumber == 0 ? _paginacionOpcion.DefaultPageNumber : filtro.PageNumber;
			filtro.PageSize = filtro.PageSize == 0 ? _paginacionOpcion.DefaultPageSize : filtro.PageSize;


			return await _unityWork.MunicipioRepository.GetPagedCustomAsync(filtro.PageNumber, filtro.PageSize);
		}
	}
}
