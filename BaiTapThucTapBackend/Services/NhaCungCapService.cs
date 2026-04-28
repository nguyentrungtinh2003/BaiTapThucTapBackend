using BaiTapThucTapBackend.DTOs;
using BaiTapThucTapBackend.Models;
using BaiTapThucTapBackend.Repositories.Interface;
using BaiTapThucTapBackend.Services.Interface;

namespace BaiTapThucTapBackend.Services
{
    public class NhaCungCapService : INhaCungCapService
    {
        private readonly INhaCungCapRepository _repo;

        public NhaCungCapService(INhaCungCapRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<NhaCungCapDto>> GetAll()
        {
            var list = await _repo.GetAll();
            return list.Select(x => x.ToDto()).ToList();
        }

        public async Task<NhaCungCapDto> Create(CreateNhaCungCapRequest request)
        {
            if (string.IsNullOrEmpty(request.Ma_NCC))
            {
                throw new Exception("Ma nha cung cap khong duoc rong");
            }
            if (string.IsNullOrEmpty(request.Ten_NCC))
            {
                throw new Exception("Ten nha cung cap khong duoc rong");
            }

            var entity = new NhaCungCap
            {
                Ma_NCC = request.Ma_NCC,
                Ten_NCC = request.Ten_NCC,
                Ghi_Chu = request.Ghi_Chu
            };

            await _repo.Add(entity);
            return entity.ToDto();
        }

        public async Task<NhaCungCapDto> Update(int id, CreateNhaCungCapRequest request)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Khong tim thay");
            }
            entity.Ma_NCC = request.Ma_NCC;
            entity.Ten_NCC = request.Ten_NCC;
            entity.Ghi_Chu = request.Ghi_Chu;

            await _repo.Update(entity);
            return entity.ToDto();
        }

        public async Task Delete(int id)
        {
            var entity = await _repo.GetById(id);
            if(entity == null)
            {
                throw new Exception("Khong tim thay");
            }
            await _repo.Delete(entity);
        }
    }
}
