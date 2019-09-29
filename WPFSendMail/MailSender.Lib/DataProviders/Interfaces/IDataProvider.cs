using MailSender.Lib.Data.Linq2SQL;
using MailSender.Lib.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.Lib.DataProviders.Interfaces
{
    public interface IDataProvider<T> where T : BaseEntity
    {
        /// <summary>
        /// Получить все объекты
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        T GetById(int id);
        /// <summary>
        /// Добавление объекта
        /// </summary>
        /// <param name="Entity">Добавляемая сущность</param>
        /// <returns>Возврат идентификатора сущности</returns>
        int Add(T Entity);
        /// <summary>
        /// Запись изменений сущности
        /// </summary>
        /// <param name="id">идентификатор сущности</param>
        /// <param name="Entity">измененная сущность</param>
        /// /// <returns>Возврат true при успешном обновлении</returns>
        void Update(int id, T Entity);
        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="id">идентификатор сущности</param>
        /// <param name="Entity">Удаляемая сущность</param>
        /// <returns>Возврат true при успешном удалении</returns>
        bool Delete(int id, T Entity);
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        void SaveChanges();
    }
}
