using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Services.Interfaces
{
    /// <summary>
    /// Хранилище объектов универсальное
    /// </summary>
    /// <typeparam name="T">тип хранимого объекта</typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// Получить все объекты
        /// Перечисление объектов
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// получить объект по идентификатору
        /// </summary>
        /// <param name="id">числовой идентификатор в хранилище</param>
        /// <returns></returns>
        T GetById(int id);
        /// <summary>
        /// создать объект (добавить)
        /// </summary>
        /// <param name="item">Создаваемый (добавляемый в хранилище) объект</param>
        /// <returns>Идентификтор, присвоенный хранилищем объекту</returns>
        int Create(T item);
        /// <summary>
        /// Отредактировать объект в хранилище
        /// </summary>
        /// <param name="Id">Идентификатор объекта, который нужно отредактировать</param>
        /// <param name="item">Модель данных, которые надо предать в редактируемый объект</param>
        void Edit(int Id, T item);
        /// <summary>
        /// Удалить объект из хранилища по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор удаляемого объекта</param>
        /// <returns>Удалённый объект, либо пустая ссылка, если объект == null</returns>
        T Remove(int Id);
        /// <summary>
        /// Сохранить сделанные изменения
        /// </summary>
        void SaveChanges();
    }
}
