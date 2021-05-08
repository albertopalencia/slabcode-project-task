namespace PruebaTecnica.Application.Implements
{
	using PruebaTecnica.Application.Abstract;
	using PruebaTecnica.Domain.Entities;
	using PruebaTecnica.Infrastructure.Interfaces;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	public class DepartamentoService : IDepartamentoService
	{
		private readonly IUnitOfWork _unityWork;
		public DepartamentoService(IUnitOfWork unityWork)
		{
			_unityWork = unityWork;
		}

		public async Task<IEnumerable<Departamento>> Listar()
		{
			return await _unityWork.DepartamentoRepository.GetAllAsync();
		}
	}
}
