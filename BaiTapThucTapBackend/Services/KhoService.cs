using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class KhoService : IKhoService
    {
        private readonly IKhoRepository _repo;

        public KhoService(IKhoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<KhoDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }
        public async Task<KhoDto> Create(CreateKhoRequest request)
        {
            if (string.IsNullOrEmpty(request.Ten_Kho))
            {
                throw new Exception("Tên kho không được rỗng");
            }

            var entity = new Kho
            {
                Ten_Kho = request.Ten_Kho,
                Ghi_Chu = request.Ghi_Chu,
            };

            await _repo.Add(entity);
            return entity.ToDto();
        }

        public async Task<KhoDto> Update(int id, CreateKhoRequest request)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tịm thấy kho");
            }

            entity.Ten_Kho = request.Ten_Kho;
            entity.Ghi_Chu = request.Ghi_Chu;

            await _repo.Update(entity);
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Không tịm thấy kho");
            }

            await _repo.Delete(entity);
        }
    }
}
