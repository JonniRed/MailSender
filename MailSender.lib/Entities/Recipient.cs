using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MailSender.lib.Entities.Base;

namespace MailSender.lib.Entities
{
    public class Recipient : PersonEntity, IDataErrorInfo
    {
        public override string Name
        {
            get => base.Name;
            set
            {
                if (value == "Иванов123") throw new ArgumentException("Иванов123 нам не подходит");
                base.Name = value;
            }
        }
        string IDataErrorInfo.Error => null;
        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch(PropertyName)
                {
                    default: return null;
                    case nameof(Name): var name = Name;
                        if (name is null) return "Пустая ссылка на имя";
                        if (name.Length < 2) return "Имя должно быть длиннее двух символов";
                        if (name.Length > 20) return "Длина имени не должна быть больше 20 символов";
                        return null;
                }
            }
        }
    }
}

