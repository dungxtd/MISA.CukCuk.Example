using MISA.Core.AttributeCustom;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Repository;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity: class
    {
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
    }
        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public MISAEntity GetById(Guid entityId)
        {
            return _baseRepository.GetById(entityId);
        }

        public int Insert(MISAEntity entity)
        {
            Validate(entity);
            return _baseRepository.Insert((entity));
        }
        private void Validate(MISAEntity entity) {
            // Validate dữ liệu
            //Lấy ra tất cả các property của class
            var properties = typeof(MISAEntity).GetProperties();
            foreach (var property in properties)
            {
                var requireProperies = property.GetCustomAttributes(typeof(MISARequired), true);
                var maxLengthProperies = property.GetCustomAttributes(typeof(MISAMaxLength), true);
                if (requireProperies.Length > 0)
                {
                    //Lấy giá trị
                    var propertyValue = property.GetValue(entity);
                    //Kiểm tra giá trị
                    if (propertyValue == null)
                    {
                        throw new Exception($"{property.Name} không được phép để null.");
                    }
                    if (propertyValue != null && string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        var msgError = (requireProperies[0] as MISARequired).MsgError;
                        if (string.IsNullOrEmpty(msgError))
                        {
                            throw new Exception($"{property.Name} không được phép để trống.");
                        }
                        throw new BadRequestException(msgError);
                    }
                }
                if (maxLengthProperies.Length > 0)
                {
                    //Lấy giá trị
                    var propertyValue = property.GetValue(entity);
                    var maxLength = (maxLengthProperies[0] as MISAMaxLength).MaxLength;
                    //Kiểm  tra giá trị
                    if(propertyValue.ToString().Length > maxLength)
                    {
                        var msgError = (maxLengthProperies[0] as MISAMaxLength).MsgError;
                        throw new BadRequestException(msgError);
                    }
                }
            }
            CustomValidate(entity);
        }
        protected virtual void CustomValidate(MISAEntity entity)
        {

        }
        public int Update(MISAEntity entity)
        {
            return _baseRepository.Update(entity);
        }

        public int Delete(Guid entityId)
        {
            return _baseRepository.Delete(entityId);
        }
        public IEnumerable<MISAEntity> GetPaging(int pageIndex, int pageSize)
        {
                //if (pageSize == 0) pageSize = 10;
                if (pageIndex < 0 || pageSize < 0) throw new BadRequestException("Page size và page index phải là số nguyên dương");
                //if (pageIndex.GetType() != typeof(int) || pageSize.GetType() != typeof(int)) throw new BadRequestException("Page size và page index phải là số nguyên");
                var entities = _baseRepository.GetPaging(pageIndex, pageSize);
                return entities;
        }
    }
}
